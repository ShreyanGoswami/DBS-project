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
    public partial class Form9 : Form
    {
        String tid;
        String[] param=new String[5];
        public Form9()
        {
            InitializeComponent();
        }

        public Form9(String[] temp_param,String tid)
        {
            this.tid = tid;
            InitializeComponent();
           

            for (int i = 0; i < 5; i++)
                this.param[i] = " ";
            for (int i = 0; i < 5; i++)
            {
                if(temp_param[i].Equals(""))
                {
                    continue;
                }
                else
                    this.param[i]=temp_param[i];
            }
            LoadDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            TeacherForm tfrm = new TeacherForm(tid);
            tfrm.Show();
        }

        private void LoadDetails()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString="Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select * from student where S_ID= ' " + param[0] + "' or S_name='" + param[1] + "' or C_Type=' " + param[2] + "' or sem='" + param[4]+"'";
            cmd.Connection = conn;
            Console.Write(cmd.CommandText);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
