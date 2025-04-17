using Auto.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Autokauppa.view;
using Autokauppa.controller;



namespace Autokauppa.model
{
    public class DatabaseHallinta
    {
        string yhteysTiedot;
        SqlConnection dbYhteys;

        public DatabaseHallinta()
        {
            dbYhteys = new SqlConnection();
            yhteysTiedot = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Autokauppa;Integrated Security=True;";

        }

        public bool connectDatabase()
        {
            if (dbYhteys.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                dbYhteys.ConnectionString = yhteysTiedot;

                try
                {
                    dbYhteys.Open();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Virheilmoitukset:" + e);
                    dbYhteys.Close();
                    return false;

                }
            }            
        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool saveAutoIntoDatabase(Auto newAuto)
        {
            try
            {
                using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
                {
                    SqlConnection.Open();
                    string query = "insert into Auto(Hinta, Rekisteri_paivamaara, Moottorin_tilavuus, Mittarilukema, AutonMerkkiID, AutonMalliID, VaritID, PolttoaineID) " +
                        "values (@Hinta, @Rekisteri_paivamaara, @Moottorin_tilavuus, @Mittarilukema, @AutonMerkkiID, @AutonMalliID, @VaritID, @PolttoaineID)";

                    using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@Hinta", newAuto.Hinta);
                        cmd.Parameters.AddWithValue("@Rekisteri_paivamaara", newAuto.Rekisteri_paivamaara.Date);
                        cmd.Parameters.AddWithValue("@Moottorin_tilavuus", newAuto.Moottorin_tilavuus);
                        cmd.Parameters.AddWithValue("@Mittarilukema", newAuto.Mittarilukema);
                        cmd.Parameters.AddWithValue("@AutonMerkkiID", newAuto.AutonMerkkiID);
                        cmd.Parameters.AddWithValue("@AutonMalliID", newAuto.AutonMalliID);
                        cmd.Parameters.AddWithValue("@VaritID", newAuto.VaritID);
                        cmd.Parameters.AddWithValue("@PolttoaineID", newAuto.PolttoaineID);
                        cmd.ExecuteNonQuery();

                        disconnectDatabase();
                        return true;
                    }

                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Virhe tallennettaessa autoa: " + ex.Message);
            }
            return false;

        }

        public List<AutonMerkki> getAllAutoMakersFromDatabase()
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                List<AutonMerkki> autonMerkit = new List<AutonMerkki>();
                SqlConnection.Open();

                string query = "select * from AutonMerkki";


                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AutonMerkki autonMerkki = new AutonMerkki()
                            {
                                Id = reader.GetInt32("ID"),
                                merkkiNimi = reader.GetString("Merkki")
                            };
                            autonMerkit.Add(autonMerkki);
                        }
                    }
                    disconnectDatabase();
                    return autonMerkit;
                }
                
            }
        }

        

        public List<AutonMalli> getAutoModelsByMakerId(int makerId) 
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                List<AutonMalli> autonMallit = new List<AutonMalli>();
                SqlConnection.Open();

                string query = $"select * from AutonMallit where AutonMerkkiID = @makerId";
                
                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    cmd.Parameters.AddWithValue("@makerId", makerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AutonMalli autonMalli = new AutonMalli()
                            {
                                Id = reader.GetInt32("ID"),
                                malliNimi = reader.GetString("Auton_mallin_nimi"),
                                merkkiId = reader.GetInt32("AutonMerkkiID")
                            };
                            autonMallit.Add(autonMalli);
                        }
                    }
                    disconnectDatabase();
                    return autonMallit;
                }
                
            }
        }

        public List<Polttoaine> getAutoPolttoaineId()
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                SqlConnection.Open();
                List<Polttoaine> polttoaine = new List<Polttoaine>();

                string query = "select * from polttoaine";

                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Polttoaine autonMalli = new Polttoaine()
                            {
                                Id = reader.GetInt32("ID"),
                                Polttoaineen_nimi = reader.GetString("Polttoaineen_nimi")
                            };

                            polttoaine.Add(autonMalli);  
                            
                        }
                    }
                }
                disconnectDatabase();
                return polttoaine;
            }
        }



        public List<Varit> getAutoVari()
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                SqlConnection.Open();
                List<Varit> vari_list = new List<Varit>();
                string query = "select * from varit";

                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Varit autonMalli = new Varit()
                            {
                                Id = reader.GetInt32("ID"),
                                Varin_nimi = reader.GetString("Varin_nimi")
                            };

                            vari_list.Add(autonMalli);
                            
                        }
                    }
                }
                disconnectDatabase();
                return vari_list;
            }
        }

        public bool RemoveAutoFromDatabase(Auto auto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(yhteysTiedot))
            {
                try
                {
                    sqlConnection.Open();

                    string query = "delete from Auto where Hinta = @Hinta and Rekisteri_paivamaara = @Rekisteri_paivamaara and Moottorin_tilavuus = @Moottorin_tilavuus and Mittarilukema = @Mittarilukema " +
                                   "and AutonMerkkiID = @AutonMerkkiID and AutonMalliID = @AutonMalliID and VaritID = @VaritID and PolttoaineID = @PolttoaineID";

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@Hinta", auto.Hinta);
                        cmd.Parameters.AddWithValue("@Rekisteri_paivamaara", auto.Rekisteri_paivamaara.Date);
                        cmd.Parameters.AddWithValue("@Moottorin_tilavuus", auto.Moottorin_tilavuus);
                        cmd.Parameters.AddWithValue("@Mittarilukema", auto.Mittarilukema);
                        cmd.Parameters.AddWithValue("@AutonMerkkiID", auto.AutonMerkkiID);
                        cmd.Parameters.AddWithValue("@AutonMalliID", auto.AutonMalliID);
                        cmd.Parameters.AddWithValue("@VaritID", auto.VaritID);
                        cmd.Parameters.AddWithValue("@PolttoaineID", auto.PolttoaineID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        disconnectDatabase();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool CheckIfAutoExist(Auto auto)
        {
            try
            {
                using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
                {
                    SqlConnection.Open();
                    string query = "select * from auto WHERE Hinta = @Hinta AND Rekisteri_paivamaara = @Rekisteri_paivamaara AND Moottorin_tilavuus = @Moottorin_tilavuus AND Mittarilukema = @Mittarilukema AND AutonMerkkiID = @AutonMerkkiID AND AutonMalliID = @AutonMalliID AND VaritID = @VaritID AND PolttoaineID = @PolttoaineID";

                    using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@Hinta", auto.Hinta);
                        cmd.Parameters.AddWithValue("@Rekisteri_paivamaara", auto.Rekisteri_paivamaara.Date);
                        cmd.Parameters.AddWithValue("@Moottorin_tilavuus", auto.Moottorin_tilavuus);
                        cmd.Parameters.AddWithValue("@Mittarilukema", auto.Mittarilukema);
                        cmd.Parameters.AddWithValue("@AutonMerkkiID", auto.AutonMerkkiID);
                        cmd.Parameters.AddWithValue("@AutonMalliID", auto.AutonMalliID);
                        cmd.Parameters.AddWithValue("@VaritID", auto.VaritID);
                        cmd.Parameters.AddWithValue("@PolttoaineID", auto.PolttoaineID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows == true) 
                            {
                                disconnectDatabase();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                            
                        }
                    }
                }
            }

            catch (Exception ex) 
            {
                return false;
            }

        }

        public List<model.Auto> GetallAutoFromDatabase()
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                SqlConnection.Open();
                List<model.Auto> Auto = new List<model.Auto>();
                string query = "select * from auto order by Hinta";

                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Auto autonMalli = new Auto()
                            {
                                Id = reader.GetInt32("ID"),
                                Hinta = reader.GetDecimal("Hinta"),
                                Rekisteri_paivamaara = reader.GetDateTime("Rekisteri_paivamaara"),
                                Moottorin_tilavuus = reader.GetDecimal("Moottorin_tilavuus"),
                                Mittarilukema = reader.GetInt32("Mittarilukema"),
                                AutonMerkkiID = reader.GetInt32("AutonMerkkiID"),
                                AutonMalliID = reader.GetInt32("AutonMalliID"),
                                VaritID = reader.GetInt32("VaritID"),
                                PolttoaineID = reader.GetInt32("PolttoaineID")
                            };

                            Auto.Add(autonMalli);

                        }
                    }
                }
                disconnectDatabase();
                return Auto;
            }
        }

        public List<AutonMalli> getAutoModelsById(int Id)
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                List<AutonMalli> autonMallit = new List<AutonMalli>();
                SqlConnection.Open();

                string query = $"select * from AutonMallit where ID = @makerId";

                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    cmd.Parameters.AddWithValue("@makerId", Id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AutonMalli autonMalli = new AutonMalli()
                            {
                                Id = reader.GetInt32("ID"),
                                malliNimi = reader.GetString("Auton_mallin_nimi"),
                                merkkiId = reader.GetInt32("AutonMerkkiID")
                            };
                            autonMallit.Add(autonMalli);
                        }
                    }
                    disconnectDatabase();
                    return autonMallit;
                }

            }
        }
    }
}
