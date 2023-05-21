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

namespace AirlineTicketReservation
{
    public partial class logareCompanie : Form
    {

        private bool ValidateUser(string username, string password)
        {
            string connectionString = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM UsersCompanie WHERE Username = @username AND Parola = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count > 0);
            }
        }

        public logareCompanie()
        {
            InitializeComponent();
        }

        private void dungeonLabel2_Click(object sender, EventArgs e)
        {
            Form formaa = new inregistrareCompanie();
            formaa.ShowDialog();
            this.Close();
        }

        private void txtUser_Click(object sender, EventArgs e)
        {

        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtParola.Text.Trim();

            if (ValidateUser(username, password))
            {

                Form forma1 = new formaPanel();
                forma1.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Nume de utilizator sau parolă incorecte.");
            }
        }
    }
}
