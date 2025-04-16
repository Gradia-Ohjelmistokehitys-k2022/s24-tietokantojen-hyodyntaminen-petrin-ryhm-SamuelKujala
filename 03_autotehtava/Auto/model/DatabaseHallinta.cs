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
            bool palaute = false;
            return palaute;

            
        }

        public List<AutonMerkki> getAllAutoMakersFromDatabase()
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                List<AutonMerkki> autonMerkit = new List<AutonMerkki>();
                SqlConnection.Open();
                string query = "select * from AutonMerkki";

                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
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
                return autonMerkit;
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
                    return autonMallit;
                }
                
            }
        }

        public List<Polttoaine> getAutoPolttoaineId(int makerId, int modelID, int variId)
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                SqlConnection.Open();
                List<Polttoaine> polttoaine = new List<Polttoaine>();
                string query = @"select Polttoaine.ID, Polttoaineen_nimi from Auto join Polttoaine on Auto.PolttoaineID = Polttoaine.ID WHERE AutonMerkkiID = @makerId AND AutonMalliID = @modelId and VaritID = @varitID";

                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    cmd.Parameters.AddWithValue("@makerId", makerId);
                    cmd.Parameters.AddWithValue("@modelID", modelID);
                    cmd.Parameters.AddWithValue("@varitID", variId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Polttoaine autonMalli = new Polttoaine()
                            {
                                Id = reader.GetInt32("ID"),
                                Polttoaineen_nimi = reader.GetString("Polttoaineen_nimi")
                            };

                            if (!polttoaine.Any(p => p.Polttoaineen_nimi == autonMalli.Polttoaineen_nimi))
                            {
                                polttoaine.Add(autonMalli);  
                            }
                        }
                    }
                }

                return polttoaine;
            }
        }



        public List<Varit> getAutoVari(int makerId, int modelID)
        {
            using (SqlConnection SqlConnection = new SqlConnection(yhteysTiedot))
            {
                SqlConnection.Open();
                List<Varit> vari_list = new List<Varit>();
                string query = @"select Varit.ID, Varit.Varin_nimi from Auto join Varit on Auto.VaritID = Varit.ID WHERE AutonMerkkiID = @makerId AND AutonMalliID = @modelId";

                using (SqlCommand cmd = new SqlCommand(query, SqlConnection))
                {
                    cmd.Parameters.AddWithValue("@makerId", makerId);
                    cmd.Parameters.AddWithValue("@modelID", modelID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Varit autonMalli = new Varit()
                            {
                                Id = reader.GetInt32("ID"),
                                Varin_nimi = reader.GetString("Varin_nimi")
                            };

                            if (!vari_list.Any(p => p.Varin_nimi == autonMalli.Varin_nimi))
                            {
                                vari_list.Add(autonMalli);
                            }
                        }
                    }
                }

                return vari_list;
            }
        }
    }
}
