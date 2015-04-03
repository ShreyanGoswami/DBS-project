﻿using System;
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
    public partial class LogIn : Form
    {
        String name, pwd;
        public LogIn()
        {
            InitializeComponent();
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            Console.Write("Log in initialised");
            name = username.Text;
            pwd = password.Text;
            Console.Write("Name Obtained");
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=localhost;Database=Coaching institute;uid=root;pwd=;";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            Console.Write("Connection established");
            cmd.CommandText = "select * from user where uname='" + name + "' and pwd='" + pwd + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                char c = name[0];

                switch (c)
                {
                    case 'S':
                        // MessageBox.Show("Login success");
                        String id = name.Substring(1);
                        StudentForm f2 = new StudentForm(id);
                        f2.Show();
                        this.Close();
                        break;

                    case 'T':
                        //load teacher form
                        break;

                }
            }
            else
                MessageBox.Show("Invalid login");

        }
    }
}
