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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AirlineTicketReservation
{
    public partial class inregistrareCompanie : Form
    {

        public static bool IsUsernameValid(string username)
        {

            if (username.Length < 3 || username.Length > 20)
            {
                return false;
            }

            return true;
        }


        public static bool IsPasswordValid(string password)
        {


            if (password.Length < 6)
            {
                return false;
            }


            return true;
        }

        public inregistrareCompanie()
        {
            InitializeComponent();
        }

        private void nightForm1_Click(object sender, EventArgs e)
        {

        }

        private void moonLabel2_Click(object sender, EventArgs e)
        {
            Form formaa = new logareCompanie();
            formaa.ShowDialog();
            this.Close();
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            string username;
            string parola;
            username = txtUser.Text;
            parola = txtParola.Text;

            if (IsUsernameValid(username) && IsPasswordValid(parola))
            {
                string connect = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connect);
                cnn.Open();
                string stmt = "insert into UsersCompanie ([Username], [Parola]) values (@n,@p)";
                SqlCommand sc = new SqlCommand(stmt, cnn);
                sc.Parameters.AddWithValue("@n", username);
                sc.Parameters.AddWithValue("@p", parola);
                sc.ExecuteNonQuery();
                cnn.Close();
               // this.DialogResult = DialogResult.OK;
                MessageBox.Show("V-ati inregistrat cu succes!");
                this.Hide();

            }
            else
            {
                MessageBox.Show("Validarea nu a fost corecta");
            }


        }

        private void txtUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username;
            string parola;


            username = txtUser.Text;
            parola = txtParola.Text;

            string connect = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            string stmt = "insert into UsersCompanie ([Username], [Parola]) values (@n,@p)";
            SqlCommand sc = new SqlCommand(stmt, cnn);
            sc.Parameters.AddWithValue("@n", username);
            sc.Parameters.AddWithValue("@p", parola);
            sc.ExecuteNonQuery();
            cnn.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
