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
    public partial class formaPanel : Form
    {
        
        public formaPanel()
        {
            InitializeComponent();
        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void formaPanel_Load(object sender, EventArgs e)
        {
             
            string connectionString = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";

            string query = "SELECT * FROM Zboruri";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

        }

        private void nightForm1_Click(object sender, EventArgs e)
        {

        }

        private void nightButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void nightButton2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";

            string query = "SELECT * FROM Zboruri";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }   
        }

        private void nightButton3_Click(object sender, EventArgs e)
        {
            string t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, dataPlecare, dataSosire;

                t1 = textBox1.Text;
                t2 = textBox2.Text;
                t3 = textBox3.Text;
                t4 = textBox4.Text;
                t5 = textBox5.Text;
                t6 = textBox6.Text;
                t7 = textBox7.Text;
                t8 = textBox8.Text;
                t9 = textBox9.Text;
                t10 = textBox10.Text;
                string connect = @"Data Source=DESKTOP-0A21C4G\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connect);
                cnn.Open();
                string stmt = "insert into ZboruriNou ([Cod], [TipAvion], [NrLocuri1],[NrLocuri2],[NrLocuri3],[PretClasaI],[PretClasaII],[PretClasaIII],[OrasPlecare], [OrasSosire], [DataPlecare], [DataSosire]) values (@t1,@t2,@t3,@t4,@t5,@t6,@t7,@t8,@t9,@t10,@dataPlecare,@dataSosire)";
                SqlCommand sc = new SqlCommand(stmt, cnn);
                sc.Parameters.AddWithValue("@t1", t1);
                sc.Parameters.AddWithValue("@t2", t2);
                sc.Parameters.AddWithValue("@t3", t3);
                sc.Parameters.AddWithValue("@t4", t4);
                sc.Parameters.AddWithValue("@t5", t5);
                sc.Parameters.AddWithValue("@t6", t6);
                sc.Parameters.AddWithValue("@t7", t7);
                sc.Parameters.AddWithValue("@t8", t8);
                sc.Parameters.AddWithValue("@t9", t9);
                sc.Parameters.AddWithValue("@t10", t10);

            sc.Parameters.AddWithValue("@dataPlecare", dateTimePlecare.Value);
            sc.Parameters.AddWithValue("@dataSosire", dateTimeRevenire.Value);

            sc.ExecuteNonQuery();
            cnn.Close();
    
            MessageBox.Show("Cursa a fost adaugata!");
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            textBox6.ResetText();
            textBox7.ResetText();
            textBox8.ResetText();
            textBox9.ResetText();
            textBox10.ResetText();
            dateTimePlecare.ResetText();
            dateTimeRevenire.ResetText();


        }

        private void nightButton1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["PretClasaI"], ListSortDirection.Ascending);
        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void crownLabel12_Click(object sender, EventArgs e)
        {

        }

        private void poisonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(poisonCheckBox1.Checked)
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

       
    }
}
