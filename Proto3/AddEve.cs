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
    public partial class AddEve : Form
    {
        //Create a connectionstring
        String connString = @"Data Source=DESKTOP-6PACUJB\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True";


        public AddEve()
        {
            InitializeComponent();
        }

        private void AddEve_Load(object sender, EventArgs e)
        {
            //Call the static variable that has been declared
            txdate.Text =Form2.static_month+"/"+ UserControlDays.static_day + "/" + Form2.static_year;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            String sql = "INSERT into tbl_Calendar(Date,Event,Time)values(@Date,@Event,@Time)";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("Date",txdate.Text);
            cmd.Parameters.AddWithValue("Event", txevent.Text);
            cmd.Parameters.AddWithValue("Time", txtime.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");
            cmd.Dispose();
            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
