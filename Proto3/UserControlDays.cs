using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proto3
{
    public partial class UserControlDays : UserControl
    {
        
        String ConnString = @"Data Source=DESKTOP-6PACUJB\SQLEXPRESS;Initial Catalog=Prot;Integrated Security=True";

        //Create another static variable

        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            lbdays.Text = numday+"";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
          
            timer1.Start();

            AddEve eventform = new AddEve();
            eventform.Show();

        }

        //Create a new method to display event
        private void displayEvent()
        {
            SqlConnection Con = new SqlConnection(ConnString);
            Con.Open();
            String sql = "SELECT * FROM tbl_Calendar where Date = @Date";
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("Date", Form2.static_year + "/" + Form2.static_month + "/" + lbdays.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lbevent.Text = reader["Event"].ToString();

            }
            reader.Dispose();
            cmd.Dispose();
            Con.Close();

        }

        //Create a timer for auto display event if new event is added

        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        }
    }
}
