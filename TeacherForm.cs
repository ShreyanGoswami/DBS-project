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
    public partial class TeacherForm : Form
    {
        private MySqlConnection conn;
        private MySqlDataReader dr;
        private MySqlCommand cmd;

        String tid, tname,tadd,tsalary,tdob,tcontact;

        public TeacherForm()
        {
            InitializeComponent();
        }

        public TeacherForm(String tid)
        {
            InitializeComponent();
            this.tid = tid;
            DisplayInfo();
            LoadFinance();
        }

        private void Connect()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();
        }

        private void Disconnect()
        {
            //dr.Close();
            //conn.Close();
        }

        private void DisplayInfo()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from teacher where T_ID=" + tid;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            //to load profile information
            if (dr.Read())
            {
                tid = dr.GetString(0);
                tname = dr.GetString(1);
                tadd = dr.GetString(2);
                tdob = dr.GetString(3);
                tcontact = dr.GetString(4);
            }
            id.Text = tid;
            name.Text = tname;
            address.Text = tadd;
            dob.Text = tdob;
            contact.Text = tcontact;
            sal.Text = tsalary;
            //Disconnect();
            dr.Close();
            conn.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn newForm = new LogIn();
            newForm.Show();

        }

        private void LoadFinance()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select bonus_perc from teacher_finance where T_ID=" + tid;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                f_id.Text = tid;
                price.Text = tsalary;
                paid.Text=dr.GetString(0) ;
            }

            //Disconnect();
            dr.Close();
            conn.Close();
        }


        private void TeacherForm_Load(object sender, EventArgs e)
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "SELECT C_Name FROM course NATURAL JOIN teaches WHERE teaches.T_ID =" + tid;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString(0));
            }

            dr.Close();
            //LoadSec();
            LoadSem();
            
        }

        

        private void LoadSem()
        {
            cmd = new MySqlCommand();
            cmd.CommandText = "SELECT sem FROM course NATURAL JOIN teaches WHERE teaches.T_ID =" + tid;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr.GetString(0));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Console.Write("Chosen");
            Connect();
            String[] text = {textBox1.Text,textBox3.Text,textBox5.Text,textBox6.Text,textBox7.Text};
            String cmdText = null;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals(""))
                {
                    continue;
                }
                else
                    cmdText+="'"+text[i]+"'";
            }
            Console.Write(cmdText);
            cmd=new MySqlCommand();
            //cmd.CommandText= "Select "+cmdText+" from student

        }
    }
}
