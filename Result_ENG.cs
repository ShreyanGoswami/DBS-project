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
    public partial class Result_ENG : Form
    {
        /*Class variables required to establish connection with database
         *conn is used to connect to database
         *id is used to fetch the result of the student with the particular id
         *dr is used to read the data from the table
         *cmd is used to pass MySQL query to the database
         */
        private MySqlConnection conn;
        private String id;
        private MySqlDataReader dr;
        private MySqlCommand cmd;

        private String sub1,sub2,sub3;

        public Result_ENG()
        {
            InitializeComponent();
        }

        public Result_ENG(String id)
        {
            this.id = id;
            ID.Text = id;
            InitializeComponent();
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
        }

        private void Result_ENG_Load(object sender, EventArgs e)
        {

        }
    }
}
