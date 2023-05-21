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
    public partial class formaRezevare : Form
    {

        public formaRezevare()
        {
            InitializeComponent();
            numericUpDown1.ValueChanged += ActualizareSuma;
            numericUpDown2.ValueChanged += ActualizareSuma;
        }
        private void ActualizareSuma(object sender, EventArgs e)
        {
            // Calculați suma valorilor din NumericUpDown
            int numarAdulti = (int)numericUpDown1.Value;
            int numarCopii = (int)numericUpDown2.Value;
            int suma = numarAdulti + numarCopii; 

            // Actualizați conținutul Label-ului cu suma calculată
            txtBoxNrLocuri.Text = suma.ToString();
        }
        private void nightHeaderLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nightForm1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void foreverTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void poisonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (poisonCheckBox1.Checked)
            {
                labelDataRevenire.Visible = true;
                dateTimeRevenire.Visible = true;
            }
            else
            {
                labelDataRevenire.Visible = false;
                dateTimeRevenire.Visible = false;
            }
          
        }

        private void poisonDateTime1_ValueChanged(object sender, EventArgs e)
        {

        }

        private bool Verificari()
        {
            if (string.IsNullOrEmpty(txtBoxOrasDestinatie.Text))
            {
                txtBoxOrasDestinatie.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxOrasPlecare.Text))
            {
                txtBoxOrasPlecare.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxClasa.Text))
            {
                txtBoxClasa.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxNrLocuri.Text))
            {
                txtBoxNrLocuri.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(poisonDateTime1.Text))
            {
                poisonDateTime1.Focus();
                return false;
            }

            return true;
        }


        private void nightButton3_Click(object sender, EventArgs e)
        {
            if(Verificari() == true)
            {

                string orasPlecare = txtBoxOrasPlecare.Text;
                string orasSosire = txtBoxOrasDestinatie.Text;
                string connectionString = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";

                string query = "SELECT * FROM ZboruriNou WHERE OrasPlecare = @OrasPlecare AND OrasSosire = @OrasSosire";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrasPlecare", orasPlecare);
                        command.Parameters.AddWithValue("@OrasSosire", orasSosire);

                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dataTable;
                            }
                            else
                            {
                                MessageBox.Show("Nu există curse disponibile între aceste orase.");
                            }
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Datele nu au fost validate, va rugam sa le completati cu atentie!");
            }
        }

       
    }
}
