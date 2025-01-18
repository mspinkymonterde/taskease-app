using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.IO;

namespace Proto3
{
    public partial class Forge : Form
    {
        static int vCode = 1000;
        string code = vCode.ToString();
        public Forge()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-6PACUJB\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True");

        private void closebtn_Click(object sender, EventArgs e)
        {
            Form1 form5 = new Form1();
            form5.Show();
            this.Hide();
        }

        
        private void BtnCode_Click(object sender, EventArgs e)
        {


            string email;


            try
            {
                
                String querry = "SELECT * FROM Login_new2 WHERE Email = '" + TxEM.Text + "'";
                
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                

                if(dtable.Rows.Count > 0)
                {
                    email = TxEM.Text;
                    //Verification Code
                    
                    MessageBox.Show("The code is:" + " " + code, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string filepath = "integer_date.txt";
                    WriteIntegerToFile(filepath, code);

                    
                    

                    TxVC.Enabled = true;
                    ButtonNext.Enabled = true;
                    

                }


                else if (TxEM.Text == "")
                {
                    MessageBox.Show("Please Input your email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MessageBox.Show("Email doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   


            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }


        }

        private void WriteIntegerToFile(string filepath, string data)
        {
            TextWriter text1 = new StreamWriter(filepath);
            text1.Write(code);
            text1.Close();
        }


        private void ButtonNext_Click(object sender, EventArgs e)
        {
           
            if (TxVC.Text == code)
            {
                pwd form3 = new pwd();
                form3.Show();
                this.Hide();
            }

            else if (TxVC.Text != code)
            {
                MessageBox.Show("Verification Code does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timvcode_Tick(object sender, EventArgs e)
        {
            vCode += 10;
            if(vCode == 9999)
            {
                vCode = 1000;
            }
        }

        private void TxEM_Enter(object sender, EventArgs e)
        {
            if (TxEM.Text == "Email")
            {
                TxEM.Text = "";
                TxEM.ForeColor = Color.Black;
            }
        }

        private void TxEM_Leave(object sender, EventArgs e)
        {
            if (TxEM.Text == "")
            {
                TxEM.Text = "Email";
                TxEM.ForeColor = Color.Silver;
            }
        }

        private void TxVC_Enter(object sender, EventArgs e)
        {
            if (TxVC.Text == "Verification Code")
            {
                TxVC.Text = "";
                TxVC.ForeColor = Color.Black;
            }
        }

        private void TxVC_Leave(object sender, EventArgs e)
        {
            if (TxVC.Text == "")
            {
                TxVC.Text = "Verification Code";
                TxVC.ForeColor = Color.Silver;
            }
        }

       
    }
}
