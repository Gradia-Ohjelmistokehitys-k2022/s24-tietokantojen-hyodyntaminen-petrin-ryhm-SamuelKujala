using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Opiskelijat_T2.Models;

namespace Opiskelijat_T2
{
    public partial class Form1 : Form
    {
        string connection = "server=localhost;user=root;database=opiskelit_t2;port=3306;password=";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TestConnection();
            DataToDataGrid();
            DataToComboBox();
        }

        public void TestConnection()
        {
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
                {
                    mySqlConnection.Open();
                    Console.WriteLine("Connection succesfull");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DataToDataGrid()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                List<Opiskelija> opiskelijat = new List<Opiskelija>();
                mySqlConnection.Open();
                string query = "select * from opiskelijat";

                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Opiskelija o = new Opiskelija()
                        {
                            Tunniste = reader.GetInt32("opiskelija_id"),
                            Etunimi = reader.GetString("etunimi"),
                            Sukunimi = reader.GetString("sukunimi"),
                            RyhmaId = reader.GetInt32("ryhma_ID")
                        };
                        opiskelijat.Add(o);
                    }

                    dataGridView1.DataSource = opiskelijat;

                }
            }
        }

        public void DataToComboBox()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                List<Ryhma> ryhmat = new List<Ryhma>();
                mySqlConnection.Open();
                string query = "select * from opiskelijaryhma";

                using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ryhma o = new Ryhma()
                        {
                            Id = reader.GetInt32("opiskelijaryhmä_ID"),
                            ryhmannimi = reader.GetString("nimi")
                        };
                        ryhmat.Add(o);
                    }
                    ryhmat.Insert(0, new Ryhma { Id = -1, ryhmannimi = "--- Valitse ryhmä ---" });
                    comboBox1.DataSource = ryhmat;
                    comboBox1.DisplayMember = "ryhmannimi";  
                    comboBox1.ValueMember = "Id";
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEtunimi.Text) && !string.IsNullOrEmpty(txtSukunimi.Text))
            {
                if ((int)comboBox1.SelectedValue < 0)
                {
                    MessageBox.Show("Valitse Ryhmä luodaksesi oppilaan");
                }
                else
                {
                    using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
                    {
                        // Haetaan valuemember arvo
                        int ryhmaId = (int)comboBox1.SelectedValue;
                        mySqlConnection.Open();
                        string query = "insert opiskelijat(etunimi, sukunimi, ryhma_ID) values (@etunimi, @sukunimi, @ryhma_ID)";

                        using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@etunimi", txtEtunimi.Text);
                            cmd.Parameters.AddWithValue("@sukunimi", txtSukunimi.Text);
                            cmd.Parameters.AddWithValue("@ryhma_ID", ryhmaId);
                            cmd.ExecuteNonQuery();
                        }

                        DataToDataGrid();
                    }
                }
            }

            else
            {
                MessageBox.Show("Syötä etunimi ja sukunimi tekstikenttiin");
            }
        }

        private void btnPoistaOpiskelija_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["tunniste"].Value);

                var confirm = MessageBox.Show("Haluatko varmasti poistaa opiskelijan?", "Vahvista poisto", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
                    {
                        mySqlConnection.Open();

                        string query = "delete from opiskelijat where opiskelija_id = @id";
                        using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Opiskelija poistettu.");
                    DataToDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Valitse opiskelija, joka poistetaan");
            }
        }
    }
}
