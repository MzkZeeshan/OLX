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
    public partial class Form12 : Form
    {
        Form1 conn = new Form1();

        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            this.panel6.Visible = true;
            dataGridView1.Visible = false;
            this.button2.Visible = false;
        }

        private void label33_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlC1.Open();//userid,pass
                SqlCommand cmd = new SqlCommand("Select *from Lab where PID = '" + textBox1.Text + "' and pass ='" + textBox2.Text + "'", conn.sqlC1);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Login Successfully Please press Reports button ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //this.panel6.Visible = false;
                    button2.Visible = true;
                     

                }
                else if (textBox1.Text == "" & textBox2.Text == "")
                {
                    MessageBox.Show("PLEASE ENTER LOGINID AND PASSWORD");
                }
                else
                {
                    MessageBox.Show("PASSWORD IS NOT CORRECT");
                }
                conn.sqlC1.Close();
            }
           catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
          //  catch{ Exception ex;
          //MessageBox.Show(ex);
          //  }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.Visible = true;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from Lab where P_Status = 'Close' and PID =  '" + textBox1.Text + "' ", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }
    }
}
