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
    public partial class Form16 : Form
    {
        Form1 conn = new Form1();
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            string[] Gender = { "Male", "Female" };
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Gender);
            this.panel4.Visible = false;
            this.panel1.Visible = false;
            conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select S_ID from Staf", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            while (dd.Read())
            {
                
                comboBox4.Items.Add(dd["S_ID"]).ToString();


            }
            conn.sqlC1.Close();

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.panel4.Visible = false;
            this.panel1.Visible = true;
            this.comboBox1.Text = "";

            conn.sqlC1.Open();
            int lp = 0;

            SqlCommand cmd1 = new SqlCommand("select count(S_ID) from Staf", conn.sqlC1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                lp = Convert.ToInt32(dr1[0]);
                lp++;
               
            }

            textBox1.Text = "ST" + lp.ToString() + "-" + System.DateTime.Today.Year;
            conn.sqlC1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlC1.Open();
            SqlCommand cmd = new SqlCommand("insert into Staf(S_ID,S_Full_Name,S_Desingnation,S_Ttiming_Hours,Gender) values(@S_ID,@S_Full_Name,@S_Desingnation,@S_Ttiming_Hours,@Gender)", conn.sqlC1);
            cmd.Parameters.AddWithValue("@S_ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@S_Full_Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@S_Desingnation", textBox3.Text);
            cmd.Parameters.AddWithValue("@S_Ttiming_Hours",textBox4.Text);
            cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
          
            cmd.ExecuteNonQuery();
            conn.sqlC1.Close();
            MessageBox.Show("Record has been inserted", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel4.Visible = false;
            conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select S_ID from Staf", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            while (dd.Read())
            {
                comboBox3.Items.Add(dd["S_ID"]).ToString();
                
            }
            conn.sqlC1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select *from Staf where S_ID ='" + comboBox3.Text + "' ", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {
                //S_ID,S_Full_Name,S_Desingnation,S_Ttiming_Hours,Gender

                textBox5.Text = dd["S_Full_Name"].ToString();
                textBox6.Text = dd["S_Desingnation"].ToString();
                textBox7.Text = dd["S_Ttiming_Hours"].ToString();
                textBox8.Text = dd["Gender"].ToString();
               
            }
            conn.sqlC1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlC1.Open();
                
                //S_ID,S_Full_Name,S_Desingnation,S_Ttiming_Hours,Gender
                SqlCommand cmd = new SqlCommand("Update Staf set S_Full_Name=@S_Full_Name,S_Desingnation=@S_Desingnation,S_Ttiming_Hours=@S_Ttiming_Hours,Gender=@Gender where S_ID   = '" + comboBox3.Text + "'", conn.sqlC1);

                cmd.Parameters.AddWithValue("@S_Full_Name", textBox5.Text);
                cmd.Parameters.AddWithValue("@S_Desingnation", textBox6.Text);
                cmd.Parameters.AddWithValue("@S_Ttiming_Hours",textBox7.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox8.Text);
                cmd.ExecuteNonQuery();
                conn.sqlC1.Close();
                MessageBox.Show("Information has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel4.Visible = true;
            try
            {

                //dataGridView1.Visible = true;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from Staf ", conn.sqlC1);
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
            Form15 f2 = new Form15();
            f2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                //dataGridView1.Visible = true;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from Staf where S_ID ='" + comboBox4.Text + "' ", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }
    }
}
