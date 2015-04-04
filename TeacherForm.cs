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

        String tid, tname,tadd,tsalary;

        public TeacherForm()
        {
            InitializeComponent();
        }

        public TeacherForm(String tid)
        {
            InitializeComponent();
            this.tid = tid;
        }

        private void Connect()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
