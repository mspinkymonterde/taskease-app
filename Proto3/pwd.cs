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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Proto3
{
    public partial class pwd : Form
    {
        public pwd()
        {
            InitializeComponent();
        }


        private void TxEM_Enter(object sender, EventArgs e)
        {
            if (TxEM.Text == "New Password")
            {
                TxEM.Text = "";
                TxEM.ForeColor = Color.Black;
            }
        }

        private void TxEM_Leave(object sender, EventArgs e)
        {
            if (TxEM.Text == "")
            {
                TxEM.Text = "New Password";
                TxEM.ForeColor = Color.Silver;
            }
        }

        private void TxVC_Enter(object sender, EventArgs e)
        {
            if (TxVC.Text == "Confirm Password")
            {
                TxVC.Text = "";
                TxVC.ForeColor = Color.Black;
            }
        }

        private void TxVC_Leave(object sender, EventArgs e)
        {
            if (TxVC.Text == "")
            {
                TxVC.Text = "Confirm Password";
                TxVC.ForeColor = Color.Silver;
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6PACUJB\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True");
        private void ButtonNext_Click(object sender, EventArgs e)
        {
           
            if (TxEM.Text == TxVC.Text)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Login_new2 set password=@password", con);
                cmd.Parameters.AddWithValue("password", TxVC.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Password has been successfully changed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();

            }


            else if (TxVC.Text != TxEM.Text)
            {
                MessageBox.Show("Password does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else 
            {
                MessageBox.Show("Please input the necessary fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Forge form7 = new Forge();
            form7.Show();
            this.Hide();
        }
    }
}
