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
    public partial class Form8 : Form
    {
        Form1 conn = new Form1();

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = true;
            conn.sqlC1.Open();
            string query = "Select Location,SDay,Sfrom,STo from Azam ";
            SqlDataAdapter da = new SqlDataAdapter(query, conn.sqlC1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.sqlC1.Close();
        }
    }
}
