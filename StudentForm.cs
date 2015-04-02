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
        private MySqlConnection conn;
        private String id = "1234";
        private MySqlDataReader dr;
        private MySqlCommand cmd;

        public StudentForm()
        {
            InitializeComponent();
        }

        public StudentForm(String id)
        {
            this.id = id;
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
                ID.Text = dr.GetString(0);
                name.Text = dr.GetString(1);
                address.Text = dr.GetString(2);

                dob.Text = dr.GetString(3);
                contact.Text = dr.GetString(4);
                email.Text = dr.GetString(5);
                course.Text = dr.GetString(6);
                sec.Text = dr.GetString(7);
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
    }
}
