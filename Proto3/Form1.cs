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

namespace Proto3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-6PACUJB\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            TextUsername.Focus();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username = TextUsername.Text;
            user_password = TextPassword.Text;

            try
            {
                String querry = "SELECT * FROM Login_new2 WHERE Email = '"+TextUsername.Text+"' AND password = '"+TextPassword.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    username = TextUsername.Text;
                    user_password = TextPassword.Text;
                    
                    //page that needed to be load next
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TextUsername.Clear();
                    TextPassword.Clear();

                    //to focus on username textbox
                    TextUsername.Focus();
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

        


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Page to Signup form
            TaskEase form3 = new TaskEase();
            form3.Show();
            this.Hide();
        }


        private void TextUsername_Enter(object sender, EventArgs e)
        {
            if (TextUsername.Text == "Email")
            {
                TextUsername.Text = "";
                TextUsername.ForeColor = Color.Black;
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you wish to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void TextUsername_Leave(object sender, EventArgs e)
        {
            if (TextUsername.Text == "")
            {
                TextUsername.Text = "Email";
                TextUsername.ForeColor = Color.Silver;
            }
        }

        private void TextPassword_Leave(object sender, EventArgs e)
        {
            if (TextPassword.Text == "")
            {
                TextPassword.Text = "Password";
                TextPassword.ForeColor = Color.Silver;
                TextPassword.UseSystemPasswordChar = false;
            }
        }

        private void TextPassword_Enter(object sender, EventArgs e)
        {
            if (TextPassword.Text == "Password")
            {
                TextPassword.Text = "";
                TextPassword.ForeColor = Color.Black;
                TextPassword.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (TextPassword.UseSystemPasswordChar)
            {
                TextPassword.UseSystemPasswordChar = false;
            }

            else
            {
                TextPassword.UseSystemPasswordChar = true;
            }
        }

        private void fgtpw_Click(object sender, EventArgs e)
        {
            Forge form5 = new Forge();
            form5.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
