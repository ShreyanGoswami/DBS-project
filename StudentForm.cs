using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace coaching
{
    public partial class StudentForm : Form
    {
        /*class variables for connecting to the MySQL Database
         * *conn is used to connect to database
         *id is used to fetch the result of the student with the particular id
         *dr is used to read the data from the table
         *cmd is used to pass MySQL query to the database
         */
        private MySqlConnection conn;
        private MySqlDataReader dr;
        private MySqlCommand cmd;

        /*class variables to store the student information
         */
        String sid, sname, sloc,sdob,scontact,smail,scourse,ssec,ssem,scentre;

        public StudentForm()
        {
            InitializeComponent();
        }

        public StudentForm(String sid)
        {
            this.sid = sid;
            InitializeComponent();
            DispayInfo();
            LoadFinance();
            LoadLocation();
            LoadDays();
            LoadTimetable();
        }

        private void Connect()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();
        }

        private void DispayInfo()
        {
            Connect();
            Console.Write("Displaying general info");
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from student where S_ID=" + sid;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            //to load profile information
            if (dr.Read())
            {
                
                sname = dr.GetString(1);
                sloc = dr.GetString(2);
                sdob = dr.GetString(3);
                scontact = dr.GetString(4);
                smail = dr.GetString(5);
                scourse = dr.GetString(6);
                //ssec = dr.GetString(7);
                ssem = dr.GetString(7);

                ID.Text = sid;
                name.Text = sname;
                address.Text = sloc;

                dob.Text = sdob;
                contact.Text = scontact;
                email.Text = smail;
                course.Text = scourse;
                //sec.Text = ssec;
                sem.Text = ssem;
            }

            //fill the Result tab
            SID.Text = sid;
            lscourse.Text = scourse;
            //close connection and reader
            dr.Close();
            conn.Close();
            
        }

        private void LoadFinance()
        {
            Connect();
            int pending;
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from student_finance where S_ID=" + sid;
            Console.Write(cmd.CommandText);
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                f_id.Text = dr.GetString(0);
                price.Text = dr.GetString(1);
                paid.Text = dr.GetString(2);
                pending = int.Parse(price.Text) - int.Parse(paid.Text);
                pend.Text = ""+pending;
                Console.Write("Fetched data");
            }
            else Console.Write("No data");
        }

        private void LoadLocation()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from student_location where S_ID=" + sid;
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ssec = dr.GetString(1);
                scentre = dr.GetString(2);
                sec.Text = ssec;
            }
            else Console.Write("No data");
            
        }

        //loads the days where the student has classes and fills the combo box
        private void LoadDays()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText =" SELECT distinct (DAY) FROM timetable where timetable.Sec='"+ssec +"' and timetable.C_Address= '"+scentre+"'";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr.GetString(0));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (scourse == "ENG")
            {
                Result_ENG result = new Result_ENG(sid);
                result.Show();
                //close the current form or hide it?
                this.Close();
            }
            else if (scourse == "ENG_BIO")
            {
                Result_ENGBIO result = new Result_ENGBIO(sid);
                result.Show();
                //close the current form or hide it?
                this.Close();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LogIn newForm = new LogIn();
            newForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from student_location where S_ID=" + sid;
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
        }

        private void LoadTimetable()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText= "select day, max(firstclass) as 'First-Class',max(secondclass) as 'Second-Class',max(thirdclass) as 'Third-Class',max(fourthclass) as 'Fourth-Class',max(fifthclass) as 'Fifth-Class' from (select day,sec, if(time = '9:00:00', c_name, '--') as firstclass, if(time = '11:00:00', c_name, '--') as secondclass, if(time = '14:00:00', c_name, '--') as thirdclass, if(time = '16:00:00', c_name, '--') as fourthclass, if(time = '18:00:00', c_name, '--') as fifthclass from (SELECT day,time,c_name,sec FROM timetable as tt inner join teaches as t on tt.t_id = t.t_id inner join course as c on t.c_id = c.c_id where sem="+ssem+") as a) as b where sec ='"+ssec+"' group by day ORDER BY FIELD(day, 'Monday', 'Tuesday', 'Wednesday', 'Thursday','Friday','Saturday')";
            cmd.Connection = conn;
           // MySqlDataAdapter da=new MySqlDataAdapter(cmd);
           // DataSet ds=new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.Write(dr.GetString(0) + " " + dr.GetString(1) + " " + dr.GetString(2) + " " + dr.GetString(3) + " " + dr.GetString(4) + " " + dr.GetString(5) + "\n");
                String[] row1 = { dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5) };
                dataGridView1.Rows.Add(row1);
            }
        }
    }
}
