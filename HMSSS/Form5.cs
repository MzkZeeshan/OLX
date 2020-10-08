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
    public partial class Form5 : Form
    {
        Form1 conn = new Form1();
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            comboBox6.Text = "--PLEASE SELECT--";
            comboBox7.Text = "--PLEASE SELECT--";


            string[] City = { "Abbottabad", "Hyderabad", "Mirpure Khas", "Karachi", "Lahore", "Peshawar", "Quetta" };

            string[] Service = { "LABORATORY", "PHARMACY", "HOSPITAL", "MEDICAL CENTERS" };
            comboBox7.Items.Clear();
            comboBox7.Items.AddRange(City);

            
            comboBox6.Items.Clear();
            comboBox6.Items.AddRange(Service);
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "Abbottabad" && comboBox6.Text == "LABORATORY")
            {
                label1.Text = "";
                label1.Text += "Number of results are:"+Environment.NewLine+" Link Road Laboratory Collection Unit"+Environment.NewLine+" Time Square Plaza Laboratory Collection Unit"+Environment.NewLine;
            
            }
            if (comboBox7.Text == "Abbottabad")
            
            {
                if((comboBox6.Text == "PHARMACY") || (comboBox6.Text== "HOSPITAL")|| (comboBox6.Text=="MEDICAL CENTERS" ))
                {
                    label1.Text = "";
                MessageBox.Show("! This service is currently not available at the selected location", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            if (comboBox7.Text == "Hyderabad" && comboBox6.Text == "LABORATORY")
            {
                label1.Text = "";
                label1.Text += "Aga Khan Hospital Hyd Laboratory Collection Unit"+Environment.NewLine;
                label1.Text += "Auto Bahan Road Laboratory Collection Unit;"+Environment.NewLine;
                label1.Text += "Latifabad 6 Laboratory Collection Unit"+Environment.NewLine;
                label1.Text += "Latifabad 7 Laboratory Collection Unit"+Environment.NewLine;
                label1.Text += "Market Road Laboratory Collection Unit"+Environment.NewLine;

                //MessageBox.Show("RESULTS ARE", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
            }
            else if (comboBox7.Text == "Hyderabad" && comboBox6.Text == "PHARMACY")
            {
                label1.Text = "";
                label1.Text = "Pharmacy Medical Centre, Market Road Hyderabad (Off-Campus";
            }
            else if (comboBox7.Text == "Hyderabad" && comboBox6.Text == "HOSPITAL")
            {
                label1.Text = "";
            label1.Text = "AKUH, Hyderabad";

            }
             else if (comboBox7.Text == "Hyderabad" && comboBox6.Text == "MEDICAL CENTERS")
            {
            label1.Text = "";
                 MessageBox.Show("! This service is currently not available at the selected location","",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

            }
            if (comboBox7.Text == "Mirpure Khas")
            {
                if ((comboBox6.Text == "PHARMACY") || (comboBox6.Text == "HOSPITAL") || (comboBox6.Text == "MEDICAL CENTERS"))
                {
                    label1.Text = "";
                    
                    MessageBox.Show("! This service is currently not available at the selected location", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (comboBox6.Text == "LABORATORY")
                {
                    
                    label1.Text = "";
                    label1.Text = "Mirpurkhas Laboratory Collection Unit";
                }


            }
            if (comboBox7.Text == "Quetta")
            {
                if ((comboBox6.Text == "PHARMACY") || (comboBox6.Text == "HOSPITAL") || (comboBox6.Text == "MEDICAL CENTERS"))
                {
                    label1.Text = "";

                    MessageBox.Show("! This service is currently not available at the selected location", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (comboBox6.Text == "LABORATORY")
                {
                  
                    label1.Text = "";
                    label1.Text += "Brewery Road Laboratory Collection Unit" +  Environment.NewLine+"Saleem Complex Laboratory Collection Unit"+Environment.NewLine+"Zarghoon Road Laboratory Collection Unit"+Environment.NewLine;
                    

                }


            }

            if (comboBox7.Text == "Peshawar")
            {
                if ((comboBox6.Text == "PHARMACY") || (comboBox6.Text == "HOSPITAL") || (comboBox6.Text == "MEDICAL CENTERS"))
                {
                    label1.Text = "";

                    MessageBox.Show("! This service is currently not available at the selected location", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (comboBox6.Text == "LABORATORY")
                {
                   
                    label1.Text = "";
                    label1.Text += "Dabgari Garden Laboratory Collection Unit" + Environment.NewLine + "Hayatabad Laboratory Collection Unit" + Environment.NewLine + "Lady Reading Hospital Laboratory Collection Unit" + Environment.NewLine;

                }


            }
            if (comboBox7.Text == "Lahore")
            {
                if ((comboBox6.Text == "HOSPITAL") || (comboBox6.Text == "MEDICAL CENTERS"))
                {
                    label1.Text = "";

                    MessageBox.Show("! This service is currently not available at the selected location", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (comboBox6.Text == "LABORATORY")
                {
                    
                    label1.Text = "";
                    label1.Text += " Akbar Chowk Laboratory Collection Unit" + Environment.NewLine +  "Allama Iqbal Town Laboratory Collection Unit" + Environment.NewLine + "Defence Main Boulevard Laboratory Collection Unit" + Environment.NewLine;
                 

                }
                else if (comboBox6.Text == "PHARMACY")
                {
                    label1.Text = "";
                    label1.Text += "Pharmacy Medical Centre Baharia Town Lahore (Off-Campus)"+ Environment.NewLine;

                    label1.Text +="Pharmacy Medical Centre Emporium Mall (Nishat) Lahore (Off-Campus)"+ Environment.NewLine;

                    label1.Text +="Pharmacy Medical Centre Jail Road Lahore (Off-Campus)"+ Environment.NewLine;

                    label1.Text +="Pharmacy Medical Centre Johar Town Lahore (Off-Campus)"+ Environment.NewLine;

                    label1.Text += "Pharmacy Medical Centre Shahra-e-Noor Jahan Lahore (Off-Campus)" + Environment.NewLine;
                }


            }




            if (comboBox7.Text == "Karachi" && comboBox6.Text == "MEDICAL CENTERS")
            {
               
                label1.Text = "";
                label1.Text += "Clifton Medical Services"+Environment.NewLine;
 
                label1.Text += "Clifton Teen Talwar Medical Center"+Environment.NewLine;


                label1.Text += "Medical Center, Abul Hassan Isphani Road, Karachi"+Environment.NewLine;

                label1.Text += "Medical Center, Baldia Town, Karachi"+Environment.NewLine;

                label1.Text += "Medical Center, Gulshan-e-Iqbal, Karachi"+Environment.NewLine;

                label1.Text += "Medical Center, Korangi, Karachi"+Environment.NewLine;

                label1.Text += "Medical Center, Malir, Karachi" + Environment.NewLine;

                

            }
            else if (comboBox7.Text == "Karachi" && comboBox6.Text == "PHARMACY")
            {
                label1.Text = "";
                label1.Text += "Garden- Pharmacy"+Environment.NewLine;

                label1.Text +="Hyderabad- Pharmacy"+Environment.NewLine;

                label1.Text +="Karimabad- Pharmacy"+Environment.NewLine;

                label1.Text +="Kharadar- Pharmacy"+Environment.NewLine;

                label1.Text +="PHARMACY ACB (On-Campus)"+Environment.NewLine;

                label1.Text +="PHARMACY CC (On-Campus)"+Environment.NewLine;

                label1.Text += "PHARMACY CHC (On-Campus)" + Environment.NewLine;

                label1.Text +="Pharmacy Clifton Medical Services (Off-Campus)";
            }
            else if (comboBox7.Text == "Karachi" && comboBox6.Text == "HOSPITAL")
            {
                label1.Text = "";
                label1.Text += "AKUH, Garden"+Environment.NewLine;
                label1.Text += "AKUH, Karimabad"+Environment.NewLine;
                label1.Text += "AKUH, Kharadar"+Environment.NewLine;
                label1.Text += "AKUH, Main Campus" + Environment.NewLine;

            }
            else if (comboBox7.Text == "Karachi" && comboBox6.Text == "LABORATORY")
            {
                label1.Text = "";
                label1.Text += "Abdullah College Collection Unit" + Environment.NewLine;
                label1.Text += "Abul Hasan Isphani Road Collection Unit" + Environment.NewLine;
                label1.Text += "Al-Sehat Collection Unit" + Environment.NewLine;
                label1.Text += "APWA Collection Unit" + Environment.NewLine;
                label1.Text += "Baldia Town Medical Centre" + Environment.NewLine;

                label1.Text += "Bufferzone Collection Unit" + Environment.NewLine;
                label1.Text += "Clifton Collection Unit" + Environment.NewLine;
                label1.Text += "Clifton Medical Services" + Environment.NewLine;
            }
           
            
            //,  "Karachi", "Lahore");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    //Mirpurkhas Laboratory Collection Unit
}
