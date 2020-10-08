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
    public partial class Form13 : Form
    {
        Form1 conn = new Form1();
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            this.comboBox5.Text = "--Select MR_NO--";
            this.panel1.Visible = false;
            this.panel6.Visible = false;
            this.panel7.Visible = false;
            string[] Gender = {"Male","Female"};
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Gender);

             string[] Ward = {"General","Emergency"};
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(Ward);

             string[] Room = {"Normal","Medium","VIP"};
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(Room);

            conn.sqlC1.Open();
            SqlCommand cmd1 = new SqlCommand("select MR_No from InPatient", conn.sqlC1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox5.Items.Add(dr1["MR_No"]).ToString();
                comboBox7.Items.Add(dr1["MR_No"]).ToString();  
            }

           
            conn.sqlC1.Close();

           


        }

        private void label33_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 f3 = new Form15();
            f3.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox10.Text = "";
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.comboBox3.Text = "";
            this.comboBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox10.Text = "";
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.comboBox3.Text = "";
            this.comboBox4.Text = "";


            this.panel1.Visible = true;
            this.panel6.Visible = false;
            this.panel7.Visible = false;
             conn.sqlC1.Open();
            int lp = 0;

            SqlCommand cmd1 = new SqlCommand("select count(MR_No) from InPatient", conn.sqlC1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                lp = Convert.ToInt32(dr1[0]);
                lp++;
               
            }

            textBox1.Text = "IDP" + lp.ToString()+ "-" + System.DateTime.Today.Year; 
            conn.sqlC1.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
             try
            {
                conn.sqlC1.Open();
                SqlCommand cmd = new SqlCommand("insert into InPatient (MR_No,P_FULL_Name,F_H_Name,P_Ph#, P_Address,P_Age,Gender,Ward,Room_No, Room_type,Bed_no,Admit_Date,Dicharge_Date) values(@MR_No,@P_FULL_Name,@F_H_Name,@P_Ph#,@P_Address,@P_Age,@Gender,@Ward,@Room_No,@Room_type,@Bed_no,@Admit_Date,@Dicharge_Date)", conn.sqlC1);
                 //@Admit_Date,@Dicharge_Date
                cmd.Parameters.AddWithValue("@MR_No", textBox1.Text);
                cmd.Parameters.AddWithValue("@P_FULL_Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@F_H_Name", textBox3.Text);
                cmd.Parameters.AddWithValue("@P_Ph#",Convert.ToInt32(textBox4.Text));
                cmd.Parameters.AddWithValue("@P_Address", textBox5.Text);
                cmd.Parameters.AddWithValue("@P_Age", Convert.ToInt32(textBox6.Text));
                cmd.Parameters.AddWithValue("@Gender",comboBox1.Text);
                cmd.Parameters.AddWithValue("@Ward",comboBox2.Text);
                cmd.Parameters.AddWithValue("@Room_No", Convert.ToInt32(comboBox4.Text));
                cmd.Parameters.AddWithValue("@Room_type", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Bed_no", Convert.ToInt32(textBox10.Text));
                cmd.Parameters.AddWithValue("@Admit_Date", dateTimePicker1.Text);
                 cmd.Parameters.AddWithValue("@Dicharge_Date","---");

                cmd.ExecuteNonQuery();
                conn.sqlC1.Close();
                MessageBox.Show("Patient record enrolled thank you !","",MessageBoxButtons.OK,MessageBoxIcon.Information);
          
            }
             catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
             string[] Roomno = {"1","02","03","04","05","06","07","08","09","10","11","12"};
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(Roomno);
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel6.Visible = true;
            this.panel7.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel6.Visible = true;
            this.panel7.Visible = false;
            conn.sqlC1.Open();
            SqlDataAdapter sd = new SqlDataAdapter("Select *from InPatient ", conn.sqlC1);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.sqlC1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.sqlC1.Open();
            SqlDataAdapter sd = new SqlDataAdapter("Select *from InPatient where MR_No = '"+comboBox5.Text+"'", conn.sqlC1);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.sqlC1.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select *from InPatient where MR_No ='" + comboBox7.Text + "' ", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {
                //MR_No,P_FULL_Name,F_H_Name,P_Ph#,P_Age,Gender,Ward,Room_No, Room_type,Bed_no,Admit_Date,Dicharge_Date
                textBox7.Text = dd["P_FULL_Name"].ToString();
                textBox8.Text = dd["F_H_Name"].ToString();
                textBox11.Text = dd["P_Ph#"].ToString();
                textBox9.Text = dd["P_Age"].ToString();
                textBox12.Text = dd["Gender"].ToString();
                textBox13.Text = dd["Ward"].ToString();
                textBox15.Text = dd["Room_No"].ToString();
                textBox14.Text = dd["Room_type"].ToString();
                textBox16.Text = dd["Bed_no"].ToString();
                textBox17.Text = dd["Admit_Date"].ToString();
               
                  
            }
            conn.sqlC1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
            conn.sqlC1.Open();
             
            SqlCommand cmd = new SqlCommand("Update InPatient set P_FULL_Name=@P_FULL_Name,F_H_Name=@F_H_Name,P_Ph#=@P_Ph#,P_Age=@P_Age,Gender=@Gender,Ward=@Ward,Room_No=@Room_No,Room_type=@Room_type,Bed_no=@Bed_no,Admit_Date=@Admit_Date,Dicharge_Date=@Dicharge_Date where MR_No  = '" + comboBox7.Text + "'", conn.sqlC1);
            
            cmd.Parameters.AddWithValue("@P_Full_Name", textBox7.Text);
            cmd.Parameters.AddWithValue("@F_H_Name", textBox8.Text);
            cmd.Parameters.AddWithValue("@P_Ph#", Convert.ToInt32(textBox11.Text));
            cmd.Parameters.AddWithValue("@P_Age", Convert.ToInt32(textBox9.Text));
            cmd.Parameters.AddWithValue("@Gender", textBox12.Text);
            cmd.Parameters.AddWithValue("@Ward", textBox13.Text);
            cmd.Parameters.AddWithValue("@Room_No", Convert.ToInt32(textBox15.Text));
            cmd.Parameters.AddWithValue("@Room_type", textBox14.Text);
            cmd.Parameters.AddWithValue("@Bed_no", Convert.ToInt32(textBox16.Text));
            cmd.Parameters.AddWithValue("@Admit_Date", textBox17.Text);
            cmd.Parameters.AddWithValue("@Dicharge_Date",dateTimePicker4.Text);
           

            cmd.ExecuteNonQuery();
            conn.sqlC1.Close();
            MessageBox.Show("Please contact to payment counter!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }
    }
}
