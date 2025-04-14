using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Opiskelijat_T2.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Opiskelijat_T2
{
    public partial class Form1 : Form
    {
        string connection = "server=localhost;user=root;database=opiskelit_t2;port=3306;password=";
        public Form1()
        {
            InitializeComponent();
            ItemsToDataGrid();
            ItemsToComboBoxRyhma();
        }


        public void ItemsToDataGrid()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                List<Opiskelija> opiskelijat = new List<Opiskelija>();
                conn.Open();
                string query = "select * from opiskelijat";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Opiskelija o = new Opiskelija
                        {
                            Id = reader.GetInt32("opiskelija_id"),
                            Etunimi = reader.GetString("etunimi"),
                            Sukunimi = reader.GetString("sukunimi"),
                            RyhmaId = reader.GetInt32("ryhma_ID")
                        };
                        opiskelijat.Add(o);
                    }

                }
                dataGridView1.DataSource = opiskelijat;
            }
        }

        public void ItemsToComboBoxRyhma()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                List<Opiskelija> opiskelijat = new List<Opiskelija>();
                conn.Open();
                string query = "select * from opiskelijaryhma";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ryhma o = new Ryhma
                        {
                            Id = reader.GetInt32("opiskelijaryhmä_ID"),
                            Nimi = reader.GetString("nimi"),
                        };
                        comboBox1.Items.Add(o.Nimi);
                    }

                }
            }
        }
        
            public void DataGridRemove()
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string etunimi = dataGridView1.Rows[selectedRowIndex].Cells["etunimi"].Value.ToString();
                string sukunimi = dataGridView1.Rows[selectedRowIndex].Cells["sukunimi"].Value.ToString();
                int ryhma_ID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ryhma_ID"].Value);

            using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = "delete from opiskelijat where etunimi = @etunimi and sukunimi = @sukunimi and ryhma_ID = @ryhma_ID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@etunimi", etunimi);
                        cmd.Parameters.AddWithValue("@sukunimi", sukunimi);
                        cmd.Parameters.AddWithValue("@ryhma_ID", ryhma_ID);
                        cmd.ExecuteNonQuery();
                    }
                    dataGridView1.Rows.RemoveAt(selectedRowIndex);
                    ItemsToDataGrid();
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "insert into opiskelijat(etunimi, sukunimi, ryhma_ID) values(@etunimi, @sukunimi, @ryhma_ID)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@etunimi", txt_etunimi.Text);
                    cmd.Parameters.AddWithValue("@sukunimi", txt_sukunimi.Text);
                    cmd.Parameters.AddWithValue("@ryhma_ID", txt_ryhmaID.Text);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "delete from opiskelijat where etunimi = @etunimi and sukunimi = @sukunimi and ryhma_ID = @ryhma_ID";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@etunimi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@sukunimi", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ryhma_ID", textBox3.Text);
                    cmd.ExecuteNonQuery();
                }

                ItemsToDataGrid();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                string opiskelijaryhma = string.Empty;
                List<Opiskelija> opiskelijat = new List<Opiskelija>();
                conn.Open();
                string query = "select * from opiskelijaryhma where nimi = @nimi";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nimi", comboBox1.SelectedItem.ToString());
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Assuming there's only one result
                        {
                            opiskelijaryhma = reader["opiskelijaryhmä_ID"].ToString();
                        }
                    }
                }

                
                string query2 = "select * from opiskelijat where ryhma_ID = @ID";
                using (MySqlCommand cmd2 = new MySqlCommand(query2, conn))
                {
                    cmd2.Parameters.AddWithValue("@ID", opiskelijaryhma);
                    using (MySqlDataReader reader2 = cmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            Opiskelija o = new Opiskelija
                            {
                                Id = reader2.GetInt32("opiskelija_id"),
                                Etunimi = reader2.GetString("etunimi"),
                                Sukunimi = reader2.GetString("sukunimi"),
                                RyhmaId = reader2.GetInt32("ryhma_ID")
                            };
                            opiskelijat.Add(o);
                        }

                    }

                    dataGridView2.DataSource = opiskelijat;
                }
                
            }
        }
    }
}
