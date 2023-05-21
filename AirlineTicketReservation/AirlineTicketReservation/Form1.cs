
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


    public partial class Form1 : Form
    {

        private bool ValidateUser(string username, string password)
        {
            string connectionString = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Parola = @password";

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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelContNou_Click(object sender, EventArgs e)
        {
            Form forma = new formaInregistrare();
            forma.ShowDialog();
            this.Close();
        }

    

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

           // if (ValidateUser(username, password))
          //  {

                Form formaa1 = new formaRezevare();
                formaa1.ShowDialog();
                this.Hide();

           // }
          //  else
           // {
           //     MessageBox.Show("Nume de utilizator sau parolă incorecte.");
//}
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form formaa = new inregistrareCompanie();
            formaa.ShowDialog();

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form formaLogareCompanie = new logareCompanie();
            formaLogareCompanie.ShowDialog();
   
        }
    }
}
