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
    public partial class TaskEase : Form
    {
        public TaskEase()
        {
            InitializeComponent();
        }



        private void SignupForms_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSignup_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection("Data Source=DESKTOP-6PACUJB\\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True");
            conn1.Open();
            SqlCommand comm = new SqlCommand("insert into Login_new2 values('"+TextUserName1.Text+"','"+TextPassword1.Text+"','"+TextFirstName.Text+"','"+TextLastName.Text+"','"+dateTimePicker1.Value+"')",conn1);

            SqlCommand cmd = new SqlCommand("select Email from Login_new2 where Email='" + TextUserName1.Text + "'", conn1);
            SqlDataAdapter un = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            un.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Email" + " " + TextUserName1.Text + " " + "already been used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextUserName1.Focus();
                TextUserName1.Clear();
            }

            else if (TextFirstName.Text == "")
            {
                MessageBox.Show("Please Fill in the necessary field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextFirstName.Focus();

            }

            else if (TextLastName.Text == "")
            {
                MessageBox.Show("Please Fill in the necessary field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextLastName.Focus();

            }
            
            else if (TextUserName1.Text == "")
            {
                MessageBox.Show("Please Fill in the necessary field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextUserName1.Focus();

            }
            else if (TextPassword1.Text == "")
            {
                MessageBox.Show("Please Fill in the necessary field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TextPassword1.Focus();

            }
            
            else
            {
                comm.ExecuteNonQuery();

                MessageBox.Show("Sign Up Successful!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //page that needed to be load next
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();

            }

          
            
        }



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

       

        private void fgtpw_Click(object sender, EventArgs e)
        {
            TextFirstName.Clear();
            TextLastName.Clear();
            TextUserName1.Clear();
            TextPassword1.Clear();
            CP1.Clear();

                TextUserName1.Text = "Email";
                TextUserName1.ForeColor = Color.Silver;
            

            
                TextPassword1.Text = "Password";
                TextPassword1.ForeColor = Color.Silver;
                TextPassword1.UseSystemPasswordChar = false;
            

            
                CP1.Text = "Confirm Password";
                CP1.ForeColor = Color.Silver;
                CP1.UseSystemPasswordChar = false;
            

            
            
                TextLastName.Text = "Last Name";
                TextLastName.ForeColor = Color.Silver;
            

            
            
                TextFirstName.Text = "First Name";
                TextFirstName.ForeColor = Color.Silver;
            

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you wish to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (TextPassword1.UseSystemPasswordChar)
            {
                TextPassword1.UseSystemPasswordChar = false;
            }

            else
            {
                TextPassword1.UseSystemPasswordChar = true;
            }
        }

        private void TextUserName1_Enter(object sender, EventArgs e)
        {
            if (TextUserName1.Text == "Email")
            {
                TextUserName1.Text = "";
                TextUserName1.ForeColor = Color.Black;
            }
        }

        private void TextUserName1_Leave(object sender, EventArgs e)
        {
            if (TextUserName1.Text == "")
            {
                TextUserName1.Text = "Email";
                TextUserName1.ForeColor = Color.Silver;
            }
        }

        private void TextPassword1_Enter(object sender, EventArgs e)
        {
            if (TextPassword1.Text == "Password")
            {
                TextPassword1.Text = "";
                TextPassword1.ForeColor = Color.Black;
                TextPassword1.UseSystemPasswordChar = true;
            }
        }

        private void TextPassword1_Leave(object sender, EventArgs e)
        {
            if (TextPassword1.Text == "")
            {
                TextPassword1.Text = "Password";
                TextPassword1.ForeColor = Color.Silver;
                TextPassword1.UseSystemPasswordChar = false;
            }
        }

        private void CP1_Enter(object sender, EventArgs e)
        {
            if (CP1.Text == "Confirm Password")
            {
                CP1.Text = "";
                CP1.ForeColor = Color.Black;
                CP1.UseSystemPasswordChar = true;
            }
        }

        private void CP1_Leave(object sender, EventArgs e)
        {
            if (CP1.Text == "")
            {
                CP1.Text = "Confirm Password";
                CP1.ForeColor = Color.Silver;
                CP1.UseSystemPasswordChar = false;
            }
        }

        private void TextLastName_Enter(object sender, EventArgs e)
        {
            if (TextLastName.Text == "Last Name")
            {
                TextLastName.Text = "";
                TextLastName.ForeColor = Color.Black;
            }
        }

        private void TextLastName_Leave(object sender, EventArgs e)
        {
            if (TextLastName.Text == "")
            {
                TextLastName.Text = "Last Name";
                TextLastName.ForeColor = Color.Silver;
            }
        }

        private void TextFirstName_Enter(object sender, EventArgs e)
        {
            if (TextFirstName.Text == "First Name")
            {
                TextFirstName.Text = "";
                TextFirstName.ForeColor = Color.Black;
            }
        }

        private void TextFirstName_Leave(object sender, EventArgs e)
        {
            if (TextFirstName.Text == "")
            {
                TextFirstName.Text = "First Name";
                TextFirstName.ForeColor = Color.Silver;
            }
        }
    }
}
