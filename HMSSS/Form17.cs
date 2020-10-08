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
    public partial class Form17 : Form
    {
        Form1 conn = new Form1();
        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select DRID from Doctor", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            while (dd.Read())
            {
                comboBox1.Items.Add(dd["DRID"]).ToString();


            }
            conn.sqlC1.Close();
        }

        private void label33_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form15 f2 = new Form15();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // this.panel1.Visible = true;
            this.panel3.Visible = true;
            this.panel4.Visible = false;
            conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select DRID from Doctor", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            while (dd.Read())
            {
                comboBox4.Items.Add(dd["DRID"]).ToString();


            }
            conn.sqlC1.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel4.Visible = false;
            this.panel3.Visible = false;

            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";

            int Drid = 0;
            conn.sqlC1.Open();
            SqlCommand cmd1 = new SqlCommand("select count(DRID) from Doctor", conn.sqlC1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                Drid = Convert.ToInt32(dr1[0]);
                Drid++;
                
            }

            textBox1.Text = "DR" + Drid.ToString() + "-" + System.DateTime.Today.Year;
            conn.sqlC1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //DRID,DRName ,DRLastname ,DrSpeciality ,Post,Qualification ,PID 
            conn.sqlC1.Open();
            SqlCommand cmd = new SqlCommand("insert into Doctor(DRID,DRName,DRLastname,DrSpeciality,Post,Qualification) values(@DRID,@DRName,@DRLastname,@DrSpeciality,@Post,@Qualification)", conn.sqlC1);
            cmd.Parameters.AddWithValue("@DRID", textBox1.Text);
            cmd.Parameters.AddWithValue("@DRName", textBox2.Text);
            cmd.Parameters.AddWithValue("@DRLastname", textBox3.Text);
            cmd.Parameters.AddWithValue("@DrSpeciality", textBox4.Text);
            cmd.Parameters.AddWithValue("@Post", textBox5.Text);
            cmd.Parameters.AddWithValue("@Qualification", textBox6.Text);
            cmd.ExecuteNonQuery();
            conn.sqlC1.Close();
            MessageBox.Show("Record has been inserted", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
     
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            conn.sqlC1.Open();
            SqlCommand cm = new SqlCommand("Select *from Doctor where DRID ='" + comboBox4.Text + "' ", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {
                //DRID,DRName ,DRLastname ,DrSpeciality ,Post,Qualification 

                textBox7.Text = dd["DRName"].ToString();
                textBox8.Text = dd["DRLastname"].ToString();
                textBox9.Text = dd["DrSpeciality"].ToString();
                textBox10.Text = dd["Post"].ToString();
                textBox11.Text = dd["Qualification"].ToString();


            }
            conn.sqlC1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.sqlC1.Open();
                // P_Full_Name,Pass,
               // DRID,DRName,DRLastname,DrSpeciality,Post,Qualification 
                SqlCommand cmd = new SqlCommand("Update Doctor set DRName=@DRName,DRLastname=@DRLastname,DrSpeciality=@DrSpeciality,Post=@Post,Qualification=@Qualification where DRID = '" + comboBox4.Text + "'", conn.sqlC1);

                cmd.Parameters.AddWithValue("@DRName", textBox7.Text);
                cmd.Parameters.AddWithValue("@DRLastname", textBox8.Text);
                cmd.Parameters.AddWithValue("@DrSpeciality", textBox9.Text);
                cmd.Parameters.AddWithValue("@Post", textBox10.Text);
                cmd.Parameters.AddWithValue("@Qualification", textBox11.Text);


                cmd.ExecuteNonQuery();
                conn.sqlC1.Close();
                MessageBox.Show("Information has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
       
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox7.Text = "";
            this.textBox8.Text = "";
            this.textBox9.Text = "";
            this.textBox10.Text = "";
            this.textBox11.Text = "";
            //comboBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
             this.panel1.Visible = true;
            this.panel3.Visible = true;
            this.panel4.Visible = true;
            try
            {

                dataGridView1.Visible = true;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from Doctor", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.Visible = true;
                conn.sqlC1.Open();
                SqlDataAdapter sd = new SqlDataAdapter("Select *from Doctor where DRID =  '" + comboBox1.Text + "' ", conn.sqlC1);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.sqlC1.Close();
            }
            catch { MessageBox.Show("Please Insert Correct Information", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        
        
        }
    }
}
