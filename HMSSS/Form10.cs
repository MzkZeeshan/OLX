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
    public partial class Form10 : Form
    {
        Form1 conn = new Form1();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            try
            {
                textBox5.ReadOnly = true;
                comboBox1.Text = "--Please Select--";
                comboBox4.Text = "--Please Select--";
                string[] ctry = { "Pakistan", "Afghanistan", "Africa", "America", "Iran", "India" };
                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(ctry);

                string[] Gender = { "Male", "Female" };
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(Gender);

                MaximizeBox = false;
                MinimizeBox = false;

                int c = 0;
                conn.sqlC1.Open();
                SqlCommand cmd1 = new SqlCommand("select count(MRNo) from Patientinfo ", conn.sqlC1);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    c = Convert.ToInt32(dr1[0]);
                    c++;
                }

                textBox5.Text = "PO" + c.ToString(); //+ "-" + System.DateTime.Today.Year; 

                conn.sqlC1.Close();




                conn.sqlC1.Open();
                SqlCommand cmd = new SqlCommand("Select DrSpeciality from Doctor ", conn.sqlC1);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["DrSpeciality"]).ToString();
                }
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.sqlC1.Open();

                SqlCommand cm = new SqlCommand("Select *from Doctor where DrSpeciality = '" + comboBox2.Text.ToString() + "' ", conn.sqlC1);
                SqlDataReader dd = cm.ExecuteReader();
                if (dd.Read())
                {
                    comboBox3.Items.Clear();
                    comboBox3.Items.Add(dd["DRName"]).ToString();
                }
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string status = "SFA";
            try
            {
                conn.sqlC1.Open();
                SqlCommand cmd = new SqlCommand("insert into Patientinfo(MRNo,P_FName,P_MidName,P_LName,DOB,Gender,Pmobile,PPh#,Contry,PEmail,DrName,Disease,P_Status) values(@MRNo,@P_FName,@P_MidName,@P_LName,@DOB,@Gender,@Pmobile,@PPh#,@Contry,@PEmail,@DrName,@Disease,@P_Status)", conn.sqlC1);
                //MRNo,P_FName,P_MidName,P_LName,DOB
                //,Gender,Pmobile,PPh#,Contry,PEmail,DrName,Disease,P_Status
                cmd.Parameters.AddWithValue("@MRNo", textBox5.Text);
                cmd.Parameters.AddWithValue("@P_FName", textBox1.Text);
                cmd.Parameters.AddWithValue("@P_MidName", textBox2.Text);
                cmd.Parameters.AddWithValue("@P_LName", textBox3.Text);
                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text);

                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Pmobile", textBox4.Text);
                cmd.Parameters.AddWithValue("@PPh#", textBox7.Text);
                cmd.Parameters.AddWithValue("@Contry", comboBox4.Text);
                cmd.Parameters.AddWithValue("@PEmail", textBox8.Text);
                cmd.Parameters.AddWithValue("@DrName", comboBox3.Text);
                cmd.Parameters.AddWithValue("@Disease", comboBox2.Text);
                cmd.Parameters.AddWithValue("@P_Status", "SFA");
                cmd.ExecuteNonQuery();

                conn.sqlC1.Close();

                MessageBox.Show("Thank you for choosing The Aga Khan University Hospital to meet your healthcare needs. We have received your appointment request and will get back to you soon.");

                this.Hide();
                Form11 f11 = new Form11();
                f11.Show();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        

        }

        private void label33_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f3 = new Form2();
            f3.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
