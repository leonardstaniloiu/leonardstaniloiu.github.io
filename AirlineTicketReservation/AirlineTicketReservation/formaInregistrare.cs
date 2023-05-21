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
    public partial class formaInregistrare : Form
    {

        public static bool IsUsernameValid(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return false;
            }

            if (username.Length < 3 || username.Length > 20)
            {
                return false;
            }

            if (!username.All(char.IsLetterOrDigit))
            {
                return false;
            }

            return true;
        }


        public static bool IsPasswordValid(string password)
        {


            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (password.Length < 8)
            {
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        public static bool IsEmailValid(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool isCheckBoxChecked(CheckBox checkBox)
        {
            if (checkBox.Checked)
                return true;
            return false;
        }


        public formaInregistrare()
        {
            InitializeComponent();
        }

        private void formaInregistrare_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string username;
            string parola;
            string email;

            username = textBox1.Text;
            parola = textBox2.Text;
            email = textBox3.Text;

            if (IsUsernameValid(username) && isCheckBoxChecked(checkBox1) && IsEmailValid(email) && IsPasswordValid(parola))
            {
                string connect = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connect);
                cnn.Open();
                string stmt = "insert into Users ([Username], [Parola], [Email]) values (@n,@p,@e)";
                SqlCommand sc = new SqlCommand(stmt, cnn);
                sc.Parameters.AddWithValue("@n", username);
                sc.Parameters.AddWithValue("@p", parola);
                sc.Parameters.AddWithValue("@e", email);
                sc.ExecuteNonQuery();
                cnn.Close();

                const string message =
                    "Contul a fost creat cu succes, apasa ok pentru a te intoarce la logare!";
                const string caption = "Success";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    this.Hide();
                    Form formaLogin = new Form1();
                    formaLogin.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Validarea nu este corecta");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
