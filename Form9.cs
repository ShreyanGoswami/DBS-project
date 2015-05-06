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
        String id,owner;
        String[] param=null;
        int x;
        public Form9()
        {
            InitializeComponent();
        }

        public Form9(String[] temp_param,String id, int x,String owner)
        {
            this.id = id;
            this.x = x;
            this.owner = owner;
            InitializeComponent();

            param = new String[temp_param.Length];
            for (int i = 0; i < temp_param.Length; i++)
                this.param[i] = " ";
            for (int i = 0; i < temp_param.Length; i++)
            {
                if(temp_param[i].Equals(""))
                {
                    continue;
                }
                else
                    this.param[i]=temp_param[i];
            }
            switch(x)
            {

            case 1: LoadDetails();
                    break;
            case 2: LoadDetails1();
                    break;
            case 3: LoadDetails2();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            switch(owner)
            {
                case "S":
                    Staff sfrm = new Staff(id);
                    sfrm.Show();
                    break;
                case "T":
                    TeacherForm tfrm = new TeacherForm(id);
                    tfrm.Show();
                    break;
                

            }
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
         private void LoadDetails1() //EDIT QUERIES
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString="Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select * from Teacher where T_ID= ' " + param[0] + "' or T_name='" + param[1] + "'";
            cmd.Connection = conn;
            Console.Write(cmd.CommandText);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        private void LoadDetails2()
        {
            
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString="Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "select * from alumni where S_ID= ' " + param[0] + "' or S_name='" + param[1] + "'";           cmd.Connection = conn;
            Console.Write(cmd.CommandText);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        
        }
        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
