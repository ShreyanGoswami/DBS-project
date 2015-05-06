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
    public partial class Staff : Form
    {

        private MySqlConnection conn;
        private MySqlDataReader dr;
        private MySqlCommand cmd;
        private String stid, stname, stadd, stdob, stsal, stcnt, stcen, ctype, cid, cname, sem;
        private String tid, tname, tadd, tdob, tcnt, tsem="1", tcors, tsec, tfee, tpaid, tpend, tmail, cadd;
        private String zid, znam, zadd, zdob, zcnt, zsal, zbns, zcors; 
        private String alid, alnam, alrnk, alyrp, alcnt;
        public String exid, etid, edate, ecid, estid, emrks;
        public Staff()
        {
            InitializeComponent();
        }

        public Staff(String id)
        {
            InitializeComponent();
            stid = id;
            //Console.Write(stid);
            load_prof();
            load_prof1();
        }
        private void Connect()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "Datasource=localhost;Database=Coaching institute;uid=root;pwd=;Convert Zero Datetime=True";
            conn.Open();
        }

        private void load_prof()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from staff where ID=" + stid;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                stname = dr.GetString(1);
                stadd = dr.GetString(2);
                stsal = dr.GetString(3);
                stcnt = dr.GetString(4);
            }
            id.Text = stid;
            name.Text = stname;
            address.Text = stadd;
            contact.Text = stcnt;
            salary.Text = stsal;

        }
        private void load_prof1()
        {
             Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select C_Address from center where ID=" + stid;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                stcen = dr.GetString(0);
            }
            center.Text = stcen;

         }
        private void stu_search()
        {
            Connect();

            String[] text = { tb1.Text, tb2.Text, tb3.Text, tb4.Text, tb5.Text };
            String cmdText = null;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals(""))
                {
                    cmdText += " ";
                }
                else
                {
                    cmdText += text[i] + " ";
                }
            }
            Console.Write(cmdText);
            String[] param = new string[5];
            param = cmdText.Split(' ');
            for (int i = 0; i < param.Length; i++)
                Console.Write(param[i] + ",");
            Form9 frm = new Form9(param, stid,1,"S");
            this.Hide();
            frm.Show();
        }
        private void teach_search()
        {
            Connect();

            String[] text = { txt1.Text, txt2.Text};
            String cmdText = null;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals(""))
                {
                    cmdText += " ";
                }
                else
                {
                    cmdText += text[i] + " ";
                }
            }
            Console.Write(cmdText);
            String[] param = new string[2];
            param = cmdText.Split(' ');
            for (int i = 0; i < param.Length; i++)
                Console.Write(param[i] + ",");
            Form9 frm = new Form9(param, stid, 2, "S");
            this.Hide();
            frm.Show();
        }
        private void alumni_search()
        {
         
            Connect();

            String[] text = { txb1.Text, txb2.Text };
            String cmdText = null;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Equals(""))
                {
                    cmdText += " ";
                }
                else
                {
                    cmdText += text[i] + " ";
                }
            }
            Console.Write(cmdText);
            String[] param = new string[2];
            param = cmdText.Split(' ');
            for (int i = 0; i < param.Length; i++)
                Console.Write(param[i] + ",");
            Form9 frm = new Form9(param, stid, 3, "S");
            this.Hide();
            frm.Show();
        }

        private void cors_search()
        {
            ctype = ctyp.Text;
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from course where C_Type='" + ctype+"'";
            cmd.Connection = conn;
           // MySqlDataReader dr = cmd.ExecuteReader();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
          
        }
        private void new_stud()
        {
            tid = uid.Text;
            tname = uname.Text;
            tadd = uadd.Text;
            tdob = udob.Text;
            tcnt = ucnt.Text;
            tmail = umail.Text;
            tcors = ucors.Text;
            tsec = usec.Text;
            tfee = ufee.Text;
            tpaid = upaid.Text;
            tpend = upend.Text;
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "insert into student values("+tid+", '"+ tname+ "' , '"+tadd+"' , '"+tdob+"' ,  "+tcnt+", '"+tmail+"' , '"+tcors+"' , "+tsem+ ")";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            st_finan();
            st_loc();
            cmd.CommandText = "insert into user values('" + "S" + tid + "','" + tid + "')";
            
        }
        private void caddress()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "select C_Address from center where ID = " + stid;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cadd = dr.GetString(0);
            }
            

        }
        private void st_loc()
        {
            caddress();
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "insert into student_location values(" + tid + ", '" + tsec + "' , '" + stadd + "' )";// , '" + tdob + "' ,  " + tcnt + ", '" + tmail + "' , '" + tcors + "' , " + tsem;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            
       
        }
        private void st_finan()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "insert into student_finance values(" + tid + ", " + tfee + ", " + tpaid + " )";// , '" + tdob + "' ,  " + tcnt + ", '" + tmail + "' , '" + tcors + "' , " + tsem;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            int f = Convert.ToInt32(tfee);
            int p = Convert.ToInt32(tpaid);
            int pending = f - p;
            upend.Text = Convert.ToString(pending);
        }

        private void new_teach()
        {
            zid = vid.Text;
            znam = vname.Text;
            zadd = vadd.Text;
            zcnt = vcnt.Text;
            zdob = vdob.Text;
            zsal = vsal.Text;
            zbns = vbns.Text;
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "insert into teacher values(" + zid + ", '" + znam + "' , '" + zadd + "' , '"+ zdob +"' , '"+ zcnt+"' , '"+ stadd +"' )";// , '" + tdob + "' ,  " + tcnt + ", '" + tmail + "' , '" + tcors + "' , " + tsem;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            tch_finan();
            tch_course();
            cmd.CommandText = "insert into user values('" + "T" + zid + "','" + zid + zid + zid+zid+ "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("New teacher added");
        }
        private void tch_finan()
        {
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "insert into teacher_finance values(" + zid + ", " + zsal + " , " + zbns +  " )";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            Console.Write("Teacher financial entered");
        }

        private void tch_course()
        {
            Connect();
            String[] select = new String[4];
            int index = 0;
            
            foreach (object itemChecked in vcors.CheckedItems)
            {

                
                select[index++] = itemChecked.ToString();
            }

            for (int i = 0; i < index; i++)
                Console.Write(select[i]+" ");



            cmd = new MySqlCommand();
            String cid;
            for (int i = 0; i < index; i++)
            {
                
                cmd.CommandText = "insert into teaches values(" + zid + ",'" + select[i] + "')";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
            
        }
        private void new_alum()
        {
            alid = gid.Text;
            alnam = gnam.Text;
            alrnk = grnk.Text;
            alyrp = gyr.Text;
            alcnt = gcnt.Text;
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "insert into alumni values(" + alid + ", '" + alnam + "' , " + alcnt + " , " + alrnk + " , " + alyrp + " )";// , '" + tdob + "' ,  " + tcnt + ", '" + tmail + "' , '" + tcors + "' , " + tsem;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
        }

        private void exam()
        {
            exid = pxid.Text;
            ecid = pcid.Text;
            edate = pdate.Text;
            etid = ptid.Text;
            Connect();
            cmd = new MySqlCommand();
            cmd.CommandText = "insert into exam values(" + exid + ", " + ecid + " , '" + edate + "' , " + etid + " )";// , '" + tdob + "' ,  " + tcnt + ", '" + tmail + "' , '" + tcors + "' , " + tsem;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("New exam created");
            
        }
        
        private void Staff_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            LogIn frm = new LogIn();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stu_search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            teach_search();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            alumni_search();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cors_search();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new_stud();
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new_teach();
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            new_alum();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            exam();
        }
    }
}
