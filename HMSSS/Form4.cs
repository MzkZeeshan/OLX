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
    public partial class Form4 : Form
    {
        Form1 conn = new Form1();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            this.dataGridView1.ReadOnly = true;
            // var a = comboBox1.Text;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            this.dataGridView1.ReadOnly = true;

            conn.sqlC1.Open();
             SqlCommand cmd = new SqlCommand("Select DrSpeciality from Doctor ", conn.sqlC1);
             SqlDataReader dr = cmd.ExecuteReader();
             while (dr.Read())
             {
                 comboBox1.Items.Add(dr["DrSpeciality"]).ToString();
             }
             conn.sqlC1.Close();
           


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.sqlC1.Open();
            string query = "Select DRName,DRLastname,DrSpeciality,Post,Qualification from Doctor where DRName = '" + comboBox2.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn.sqlC1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.sqlC1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            conn.sqlC1.Open();
           
            SqlCommand cm = new SqlCommand("Select *from Doctor where DrSpeciality = '" + comboBox1.Text.ToString() + "' ", conn.sqlC1);
            SqlDataReader dd = cm.ExecuteReader();
            if (dd.Read())
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add(dd["DRName"]).ToString();
            }
            conn.sqlC1.Close();
           


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Zafar")
            {
               // this.Hide();
                Form6 f3 = new Form6();
                f3.Show();
            }

            if (comboBox2.Text == "Waqas")
            {
                //this.Hide();
                Form7 f3 = new Form7();
                f3.Show();
            }

            if (comboBox2.Text == "Azam")
            {
                //this.Hide();
                Form8 f3 = new Form8();
                f3.Show();
            }
            if (comboBox2.Text == "Ameen")
            {
               // this.Hide();
                Form9 f3 = new Form9();
                f3.Show();
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {


           this.Hide();
            Form10 f10 = new Form10();
            f10.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    
}}

