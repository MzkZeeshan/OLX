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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            //textBox1.Text = "user";
            //textBox2.Text = "123";
            this.ShowIcon = false;
            pictureBox4.Visible = false;
            pictureBox3.Visible = false;
            panel1.Enabled = false;
            pictureBox2.Enabled = false;
            menuStrip1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 conn = new Form1();
            
             conn.sqlC1.Open();//userid,pass
                SqlCommand cmd = new SqlCommand("Select *from LOGIN where userid = '" + textBox1.Text + "' and pass ='" + textBox2.Text + "'", conn.sqlC1);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("WELCOME TO AGA KHAN UNIVERSITY HOSPITAL ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Hide();
                    //Form3 f3 = new Form3();
                    //f3.Show();
                    panel5.Visible = false;
                    panel6.Visible = false;
                    panel3.Visible = false;
                    panel1.Enabled = true;
                    //pictureBox1.Enabled = true;
                    //pictureBox2.Enabled = true;
                    //pictureBox3.Enabled = true;
                    //pictureBox4.Enabled = true;
                    //pictureBox5.Enabled = true;
                   menuStrip1.Enabled = true;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void hOSPITALsINPAKISTANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox3.Visible = true;

            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;

            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox1.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = false; ;
            Form1 conn = new Form1();

            conn.sqlC1.Open();//userid,pass
            SqlCommand cmd = new SqlCommand("Select *from Admin where id = '" + textBox1.Text + "' and pass ='" + textBox2.Text + "'", conn.sqlC1);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("WELCOME TO AGA KHAN UNIVERSITY HOSPITAL ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form15 f3 = new Form15();
                f3.Show();
                //panel5.Visible = false;
                //panel6.Visible = false;
                //panel3.Visible = false;
                //panel1.Enabled = true;
                //pictureBox1.Enabled = true;
                //pictureBox2.Enabled = true;
                //pictureBox3.Enabled = true;
                //pictureBox4.Enabled = true;
                //pictureBox5.Enabled = true;
                //menuStrip1.Enabled = true;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button4.Visible = false;
                button3.Visible = false;
                button1.Visible = true;
                
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button4.Visible = false;
                button1.Visible = false;
                button3.Visible = true;
                
            }
        }

       
        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Please Select Admin or User");
        }
    }
}
