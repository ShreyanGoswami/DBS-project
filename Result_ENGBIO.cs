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
    public partial class Result_ENGBIO : Form
    {
        /*Class variables required to establish connection with database
        *conn is used to connect to database
        *id is used to fetch the result of the student with the particular id
        *dr is used to read the data from the table
        *cmd is used to pass MySQL query to the database
        */
        private MySqlConnection conn;
       // private String id;
        private MySqlDataReader dr;
        private MySqlCommand cmd;

        private String sub, cname = "Medical", sem;

        private String sid;
        public Result_ENGBIO()
        {
            InitializeComponent();
        }

        public Result_ENGBIO(String sid)
        {
            InitializeComponent();
            this.sid = sid;
        }

        //call this function to establish a connection with the database
        private void Connect()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();
        }

        //call this function at the end of any function which uses the connect function
        private void Disconenct()
        {
            dr.Close();
            conn.Close();

        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn frm = new LogIn();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
            String cid = null;
            cmd = new MySqlCommand();
            sub = comboBox2.GetItemText(this.comboBox1.SelectedItem);
            sem = comboBox1.GetItemText(this.comboBox2.SelectedItem);
            if (sub.Equals("Physics"))
            {

                cid = sem + "01";
            }
            else if (sub.Equals("Chemistry"))
            {
                cid = sem + "03";
            }
            else if (sub.Equals("Biology"))
            {
                cid = sem + "02";
            }
            else
            {
                MessageBox.Show("Please choose valid subject and semester");
            }
            Console.Write(cid);
            cmd.CommandText = "select marks from exam natural join result where s_id='" + sid + "' and exam.c_id='" + cid + "'";
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MarksLBL.Text = dr.GetString(0);
            }
            else
                MessageBox.Show("Invalid details");
            dr.Close();
        }
    }
}
