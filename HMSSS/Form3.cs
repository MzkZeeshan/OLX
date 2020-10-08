using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HMSSS
{
    public partial class Form3 : Form
    {
        Form1 conn = new Form1();
        int[] payment = new int[50];
        string[] ttype = new string[50];
        string[] rresult = new string[50];
        int counter = 0;
             
        public Form3()
        {
            
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ////try{
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = false;
            this.textBox6.ScrollBars = ScrollBars.Both;
            this.textBox10.ScrollBars = ScrollBars.Both;
            this.comboBox1.Text = "--Select Please--";
            dataGridView2.ReadOnly = true;
            this.comboBox2.Text = "--Select Please--";
            this.comboBox4.Text = "--Select Patient ID--";

            conn.sqlC1.Open();

            SqlCommand cm = new SqlCommand("Select TestType from Test  ", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            while (dd.Read())
            {

                comboBox1.Items.Add(dd["TestType"]).ToString();
            }
            conn.sqlC1.Close();

            conn.sqlC1.Open();
            SqlCommand sq = new SqlCommand("Select DRName from Doctor  ", conn.sqlC1);
            SqlDataReader sd = sq.ExecuteReader();
            while (sd.Read())
            {
                
                comboBox2.Items.Add(sd["DRName"]).ToString();
            }
            conn.sqlC1.Close();
            //conn.sqlC1.Open();
            //int lp = 0;
            
            //SqlCommand cmd1 = new SqlCommand("select count(PID) from Lab", conn.sqlC1);
            //SqlDataReader dr1 = cmd1.ExecuteReader();
            //if (dr1.Read())
            //{
            //    lp = Convert.ToInt32(dr1[0]);
            //    lp++;
            //   // comboBox2.Items.Add(sd["DRName"]).ToString();
            //}

            //textBox2.Text = "LP0" + lp.ToString(); //+ "-" + System.DateTime.Today.Year; 
            //conn.sqlC1.Close();
            conn.sqlC1.Open();

            SqlCommand cmd11 = new SqlCommand("select PID from Lab", conn.sqlC1);
            SqlDataReader dr11 = cmd11.ExecuteReader();
            while (dr11.Read())
            {
                comboBox3.Items.Add(dr11["PID"]).ToString();
            }

            conn.sqlC1.Close();
        //}
        //catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



              }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                conn.sqlC1.Open();
                SqlCommand cm = new SqlCommand("Select *from Test where TestType ='" + comboBox1.Text + "' ", conn.sqlC1);
                SqlDataReader dd = cm.ExecuteReader();
                if (dd.Read())
                {

                    textBox5.Text = dd["fees"].ToString();

                }
                conn.sqlC1.Close();
            //}
            //catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        

        }

        private void label33_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form15 f3 = new Form15();
            f3.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.sqlC1.Open();
                //TestType,PID,P_Full_Name,Pass,Dr_Name,P_Status,Payment
                //int s = 0;
                //foreach (int p in payment)
                //{
                //    s = p + s;

                //}
                SqlCommand cmd1 = new SqlCommand("insert into LabBill(PID,P_Full_Name,Total_Payment,P_Status) values(@PID,@P_Full_Name,@Total_Payment,@P_Status)", conn.sqlC1);
                cmd1.Parameters.AddWithValue("@PID", textBox2.Text);
                cmd1.Parameters.AddWithValue("@P_Full_Name", textBox1.Text + " " + textBox3.Text);
                cmd1.Parameters.AddWithValue("@Total_Payment", Convert.ToInt32(textBox7.Text));
                cmd1.Parameters.AddWithValue("@P_Status", "SFC");
                cmd1.ExecuteNonQuery();
                for (int i = 0; i < counter; i++)
                {

                    SqlCommand cmd = new SqlCommand("insert into Lab(TestType,PID,P_Full_Name,Pass,Dr_Name,P_Status,Reports_Result,Payment) values(@TestType,@PID,@P_Full_Name,@Pass,@Dr_Name,@P_Status,@Reports_Result,@Payment)", conn.sqlC1);
                    cmd.Parameters.AddWithValue("@TestType", ttype[i]);
                    cmd.Parameters.AddWithValue("@PID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@P_Full_Name", textBox1.Text + " " + textBox3.Text);
                    cmd.Parameters.AddWithValue("@Pass", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Dr_Name", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@P_Status", "SFC");
                    cmd.Parameters.AddWithValue("@Reports_Result", "SFC");
                    cmd.Parameters.AddWithValue("@Payment", payment[i]);
                    //cmd.Parameters.AddWithValue("@Payment", Convert.ToInt32(textBox5.Text));

                    cmd.ExecuteNonQuery();

                }
                conn.sqlC1.Close();

                MessageBox.Show("Thank you for choosing The Aga Khan University Hospital . After two days you can check reports online", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox6.Text = "";
                this.textBox7.Text = "";
                //this.panel2.Visible = 
                comboBox1.Text  = "";
                comboBox2.Text = "";
                ttype[counter] = "0";
                payment[counter] = 0;
                counter++;
            }
            catch { MessageBox.Show("Please Insert fiels Correctly ", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // textBox6.Text += "*********************";
            textBox6.Text += label5.Text + " : " + comboBox1.Text+Environment.NewLine;
            textBox6.Text += label8.Text + "  : " + textBox5.Text + Environment.NewLine;

            payment[counter] = Convert.ToInt32(textBox5.Text);
            ttype[counter] = comboBox1.Text;
            counter++;
           int tp = 0;
           foreach (int p in payment)
           {

               tp = p + tp;
               
           }
           textBox7.Text = "";
           textBox7.Text += tp.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = false;
            conn.sqlC1.Open();
            int lp = 0;

            SqlCommand cmd1 = new SqlCommand("select count(PID) from Lab", conn.sqlC1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                lp = Convert.ToInt32(dr1[0]);
                lp++;
                // comboBox2.Items.Add(sd["DRName"]).ToString();
            }

            textBox2.Text = "LP0" + lp.ToString(); //+ "-" + System.DateTime.Today.Year; 
            conn.sqlC1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           //// conn
           // try
           // {
                this.panel2.Visible = false;
                this.panel3.Visible = true;
                //this.panel4.Visible = false;
                this.panel6.Visible = false;
               // this.panel5.Visible = true;
                this.dataGridView1.ReadOnly = true;
                // this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from Lab ", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;

                conn.sqlC1.Close();
            //}
            //catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
                this.dataGridView1.ReadOnly = true;
                // this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from Lab where PID = '" + comboBox3.Text + "'", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;

                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Not right method", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
           
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Reports uplod
            //try
            //{
                this.panel4.Visible = true;
                conn.sqlC1.Open();

               
                SqlCommand sc = new SqlCommand("select PID from LabBill where P_Status = 'SFC' ", conn.sqlC1);
                 SqlDataReader sd1 = sc.ExecuteReader();
            while (sd1.Read())
                {
                    comboBox4.Items.Add(sd1["PID"]).ToString();
                }

                conn.sqlC1.Close();
            //}
            //catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Text = "";

            comboBox5.Items.Clear();
            //try
            //{
               conn.sqlC1.Open();

                SqlCommand sc = new SqlCommand("select *from Lab where PID = '" + comboBox4.Text + "' ", conn.sqlC1);
                SqlDataReader sd1 = sc.ExecuteReader();
                if (sd1.Read())
                {
                    
                    textBox8.Text = sd1["P_Full_Name"].ToString();
                    textBox9.Text = sd1["Pass"].ToString();
                    comboBox5.Items.Add(sd1["TestType"]).ToString();
                }

                conn.sqlC1.Close();
            //}
            //catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        


            //conn.sqlC1.Open();

            //SqlCommand sqc = new SqlCommand("select TestType from Lab where PID = '" + comboBox4.Text + "' ", conn.sqlC1);
            //SqlDataReader sqd1 = sqc.ExecuteReader();
            //while (sd1.Read())
            //{
                
                

            //}

            //conn.sqlC1.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                this.panel5.Visible = true;
                conn.sqlC1.Open();
                //LabBill, Lab
                SqlCommand sc = new SqlCommand("select PID from Lab ", conn.sqlC1);
                SqlDataReader sd1 = sc.ExecuteReader();
                while (sd1.Read())
                {
                    comboBox6.Items.Add(sd1["PID"]).ToString();
                }

                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
                conn.sqlC1.Open();
                SqlCommand sc = new SqlCommand("select *from Lab where PID = '" + comboBox6.Text + "' ", conn.sqlC1);
                SqlDataReader sd1 = sc.ExecuteReader();
                if (sd1.Read())
                {
                    textBox11.Text = sd1["P_Full_Name"].ToString();
                    textBox12.Text = sd1["Pass"].ToString();
                }

                conn.sqlC1.Close();
            //}
            //catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //try
            //{
                conn.sqlC1.Open();
                // P_Full_Name,Pass,

                SqlCommand cmd = new SqlCommand("Update Lab set P_Full_Name=@P_Full_Name,Pass=@Pass where PID  = '" + comboBox1.Text + "'", conn.sqlC1);

                cmd.Parameters.AddWithValue("@P_Full_Name", textBox11.Text);
                cmd.Parameters.AddWithValue("@Pass", textBox12.Text);

                cmd.ExecuteNonQuery();
                conn.sqlC1.Close();
                MessageBox.Show("Information has been updated");
            //}
            //catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            rresult[counter] = textBox10.Text;
            counter++;
            MessageBox.Show("Reports are Added");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //conn.sqlC1.Open();
            //TestType, P_Status
            //try
            //{
                for (int i = 0; i < counter; i++)
                {
                    conn.sqlC1.Open();
                    SqlCommand cmd = new SqlCommand("Update Lab set P_Status = @P_Status,Reports_Result = @Reports_Result where PID  = '" + comboBox4.Text + "'", conn.sqlC1);

                    cmd.Parameters.AddWithValue("@P_Status", "Close");
                    cmd.Parameters.AddWithValue("@Reports_Result", rresult[i]);

                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("Update LabBill set P_Status = @P_Status where PID  = '" + comboBox4.Text + "'", conn.sqlC1);

                    cmd1.Parameters.AddWithValue("@P_Status", "Close");
                    cmd1.ExecuteNonQuery();
                    conn.sqlC1.Close();
                }
                MessageBox.Show("Reports are Been Uploaded", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rresult[counter] = "0";
                counter++;
            //}
            //catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{
                this.panel2.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel5.Visible = false;
                this.panel6.Visible = true;

                this.dataGridView2.ReadOnly = true;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from Test ", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView2.DataSource = dt;

                conn.sqlC1.Close();
            //}
            //catch { MessageBox.Show("ERROR","",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlC1.Open();
                SqlCommand cmd = new SqlCommand("insert into Test(TestType,fees) values(@TestType,@fees)", conn.sqlC1);

                cmd.Parameters.AddWithValue("@TestType", textBox13.Text);
                cmd.Parameters.AddWithValue("@fees", Convert.ToInt32(textBox14.Text));

                cmd.ExecuteNonQuery();
                conn.sqlC1.Close();
                MessageBox.Show("Types are added thank you !","",MessageBoxButtons.OK,MessageBoxIcon.Information);
           // }
            //catch
            //{
            //    Exception ex;
            //    {
            //        MessageBox.Show(Exception.ex);
            //    }

            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           // comboBox4.Text= "";
        }

       
        
    }
}
