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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection (@"Data Source=DESKTOP-6PACUJB\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update tbl_Calendar set Event=@Event, Time=@Time where Date=@Date",con);
            cmd.Parameters.AddWithValue("Date", txDate.Text);
            cmd.Parameters.AddWithValue("Event", txEvent.Text);
            cmd.Parameters.AddWithValue("Time", txTime.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Update Successful!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6PACUJB\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete tbl_Calendar where Event=@Event",con);
           
            cmd.Parameters.AddWithValue("Event", txEvent.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Delete Successful!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6PACUJB\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tbl_Calendar where Date=@Date",con);
            cmd.Parameters.AddWithValue("Date", txDate.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
