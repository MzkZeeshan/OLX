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
    public partial class Form2 : Form
    {
        Form1 conn = new Form1();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            pictureBox5.Visible = false;
            pictureBox8.Visible = false;
            menuStrip1.Cursor = Cursors.Arrow;
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            button4.Cursor = Cursors.Hand;
           // this.Cursor = Cursors.Hand;
            pictureBox7.Cursor = Cursors.Arrow;
            //pictureBox7.Cursor = Cursors.Arrow;
            //pictureBox7.Cursor = Cursors.Arrow;
            //pictureBox7.Cursor = Cursors.Arrow;
            //pictureBox7.Cursor = Cursors.Arrow;
            //pictureBox7.Cursor = Cursors.Arrow;
            //pictureBox7.Cursor = Cursors.Arrow;
          //  MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f4 = new Form10();
            f4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
            
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f4 = new Form5();
            f4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f4 = new Form5();
            f4.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 f4 = new Form10();
            f4.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void requestLaboratoryReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void requestDiagnosticReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pictureBox6.Visible == true)
            {
                pictureBox6.Visible = false;
                pictureBox5.Visible = true;

            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Visible = false;
                pictureBox8.Visible = true;

            }
           else if (pictureBox8.Visible == true)
            {
                pictureBox8.Visible = false;
                pictureBox6.Visible = true;

            }
        }

        private void label33_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void hOSPITALsINPAKISTANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.hOSPITALsINPAKISTANToolStripMenuItem.ForeColor = Color.White;
        }

        private void contactUsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
           // this.contactUsToolStripMenuItem.ForeColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form13 f3 = new Form13();
            f3.Show();
        }
    }
}
