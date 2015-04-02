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
        private MySqlConnection conn
        private MySqlDataReader dr;
        private MySqlCommand cmd;

        /*class variables to store the student information
         */
        String sid, sname, sloc,sdob,scontact,smail,scourse,ssec,ssem;

        public StudentForm()
        {
            InitializeComponent();
        }

        public StudentForm(String sid)
        {
            this.sid = sid;
            InitializeComponent();
            Dispay();
            LoadFinance();
        }

        private void Connect()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();
        }

        private void Dispay()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from student where S_ID=" + id;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            //to load profile information
            if (dr.Read())
            {
                sid = 
                sname = dr.GetString(1);
                sloc = dr.GetString(2);
                sdob = dr.GetString(3);
                scontact = dr.GetString(4);
                smail = dr.GetString(5);
                scourse = dr.GetString(6);
                ssec = dr.GetString(7);
                ssem = dr.GetString(8);

                ID.Text = sid;
                name.Text = sname;
                address.Text = sloc;

                dob.Text = sdob;
                contact.Text = scontact;
                email.Text = smail;
                course.Text = scourse;
                sec.Text = ssec;
                sem.Text = ssem;
            }
            //close connection and reader
            dr.Close();
            conn.Close();
            //to load financial details



        }

        private void LoadFinance()
        {
            Connect();
            int pending;
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from student_finance where S_ID=" + id;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
