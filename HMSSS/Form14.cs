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
    public partial class Form14 : Form
    {
        Form1 conn = new Form1();
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.comboBox1.Text = "--Select Please--";
            this.comboBox2.Text = "--Select Please--";
            this.comboBox3.Text = "--Select Please--";
            this.comboBox4.Text = "--Select Please--";
            string[] Gender = { "Male", "Female" };
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(Gender);

            string[] Ward = { "General", "Emergency" };
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Ward);
            conn.sqlC1.Open();

            SqlCommand cm = new SqlCommand("Select N_ID from NurseInf", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            while (dd.Read())
            {
                comboBox4.Items.Add(dd["N_ID"]).ToString();


            }
            conn.sqlC1.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel4.Visible = false;
           // this.panel3.Visible = false;

            textBox1.Text = "";
            textBox3.Text = "";
            textBox9.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            int nid = 0;
            conn.sqlC1.Open();
            SqlCommand cmd1 = new SqlCommand("select count(N_ID) from NurseInf", conn.sqlC1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                nid = Convert.ToInt32(dr1[0]);
                nid++;
                // comboBox2.Items.Add(sd["DRName"]).ToString();
            }

            textBox1.Text = "NID" + nid.ToString() + "-" + System.DateTime.Today.Year;
            conn.sqlC1.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            conn.sqlC1.Open();
            SqlCommand cmd = new SqlCommand("insert into NurseInf(N_ID,N_full_Name,N_Shift,Contact,Ward,Gender) values(@N_ID,@N_full_Name,@N_Shift,@Contact,@Ward,@Gender)", conn.sqlC1);
            cmd.Parameters.AddWithValue("@N_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@N_full_Name", textBox2.Text);
             cmd.Parameters.AddWithValue("@N_Shift", textBox3.Text);
             cmd.Parameters.AddWithValue("@Contact", Convert.ToInt32(textBox9.Text));
            cmd.Parameters.AddWithValue("@Ward", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox2.Text);
            cmd.ExecuteNonQuery();
            conn.sqlC1.Close();
            MessageBox.Show("Record has been inserted","",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // this.panel1.Visible = ;
            this.panel4.Visible = false;
            this.panel3.Visible = true;
             conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select N_ID from NurseInf", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            while (dd.Read())
            {
                comboBox3.Items.Add(dd["N_ID"]).ToString();
                

            }
            conn.sqlC1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select *from NurseInf where N_ID ='" + comboBox3.Text + "' ", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {
                //N_ID   N_full_Name  N_Shift Contact  Ward Gender 

                textBox4.Text = dd["N_full_Name"].ToString();
                textBox5.Text = dd["N_Shift"].ToString();
                textBox6.Text = dd["Contact"].ToString();
                textBox7.Text = dd["Ward"].ToString();
                textBox8.Text = dd["Gender"].ToString();
                

            }
            conn.sqlC1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try{
            conn.sqlC1.Open();
            // P_Full_Name,Pass,
            //N_ID   N_full_Name  N_Shift Contact  Ward Gender 
            SqlCommand cmd = new SqlCommand("Update NurseInf set N_full_Name=@N_full_Name,N_Shift=@N_Shift,Contact=@Contact,Ward=@Ward,Gender=@Gender where N_ID   = '" + comboBox3.Text + "'", conn.sqlC1);

            cmd.Parameters.AddWithValue("@N_full_Name", textBox4.Text);
            cmd.Parameters.AddWithValue("@N_Shift", textBox5.Text);
            cmd.Parameters.AddWithValue("@Contact", Convert.ToInt32(textBox6.Text));
            cmd.Parameters.AddWithValue("@Ward", textBox7.Text);
            cmd.Parameters.AddWithValue("@Gender",textBox8.Text);


            cmd.ExecuteNonQuery();
            conn.sqlC1.Close();
            MessageBox.Show("Information has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
       
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = true;
            try
            {

                dataGridView1.Visible = true;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from NurseInf", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.Visible = true;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from NurseInf where N_ID =  '" + comboBox4.Text + "' ", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void label33_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 f3 = new Form15();
            f3.Show();
        }
    }
}
