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
    public partial class Form11 : Form
    {
        Form1 conn = new Form1();
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                MaximizeBox = false;
                MinimizeBox = false;

                conn.sqlC1.Open();
                SqlCommand cmd = new SqlCommand("Select MRNo from Patientinfo where P_Status = 'SFA'", conn.sqlC1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["MRNo"]).ToString();
                }
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.sqlC1.Open();
                SqlCommand cmd = new SqlCommand("Select *from Patientinfo where MRNo = '" + comboBox1.Text + "'", conn.sqlC1);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    textBox1.Text = dr["P_FName"].ToString();
                    textBox2.Text = dr["P_MidName"].ToString();
                    textBox3.Text = dr["P_LName"].ToString();
                    textBox4.Text = dr["Disease"].ToString();
                    textBox5.Text = dr["DrName"].ToString();
                }
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlC1.Open();

                SqlCommand cmd = new SqlCommand("Update Patientinfo set P_Status=@P_Status where MRNo = '" + comboBox1.Text + "'", conn.sqlC1);

                cmd.Parameters.AddWithValue("@P_Status", "APPROVED");
                cmd.ExecuteNonQuery();
                conn.sqlC1.Close();

                conn.sqlC1.Open();
                SqlCommand cm1 = new SqlCommand("Insert into Doctor(PID) values(@PID) where DRName = '" + textBox5.Text + "' ", conn.sqlC1);
                cmd.Parameters.AddWithValue("@PID", comboBox1.Text);
                cmd.ExecuteNonQuery();

                conn.sqlC1.Close();
                MessageBox.Show("APPOINTMENT CONFIRMED PLEASE CHECK YOUR EMAIL", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
