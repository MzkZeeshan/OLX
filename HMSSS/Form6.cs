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
    public partial class Form6 : Form
    {
        Form1 conn = new Form1();
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = true;
            conn.sqlC1.Open();
            string query = "Select Location,SDay,Sfrom,STo from Sedule ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn.sqlC1);
             DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.sqlC1.Close();
        }
    }
}
