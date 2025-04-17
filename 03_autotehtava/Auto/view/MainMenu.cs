using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Autokauppa.controller;
using Auto.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Autokauppa.model;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace Autokauppa.view
{
    public partial class MainMenu : Form
    {
        public int currentAutoIndex = -1;

        KaupanLogiikka registerHandler;

        public MainMenu()
        {
            registerHandler = new KaupanLogiikka();
            InitializeComponent();
            LoadAllDataToCbMerkki();

            tbId.ReadOnly = true;
            tbId.Enabled = false;
        }

        private void testaaTietokantaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registerHandler.TestDatabaseConnection();
        }

        public void LoadAllDataToCbMerkki()
        {
            int id = 0;
            List<AutonMerkki> auto = registerHandler.getAllAutoMakers();
            auto.Insert(0, new AutonMerkki { Id = -1, merkkiNimi = "Valitse merkki" });
            cbMerkki.DataSource = auto;
            cbMerkki.DisplayMember = "merkkiNimi";
            cbMerkki.ValueMember = "Id";
        }

        private void cbMerkki_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMerkki.SelectedIndex > 0)
            {
                int merkkiId = cbMerkki.SelectedIndex;
                List<AutonMalli> auto = registerHandler.getAutoModels(merkkiId);

                auto.Insert(0, new AutonMalli { Id = -1, malliNimi = "Valitse malli" });
                cbMalli.DataSource = auto;
                cbMalli.DisplayMember = "malliNimi";
                cbMalli.ValueMember = "Id";
            }



        }

        private void cbMalli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMalli.SelectedIndex > 0)
            {
                List<Varit> vari = registerHandler.getAutoVari();
                List<Polttoaine> polttoaine = registerHandler.getAutoPolttoaine();


                vari.Insert(0, new Varit { Id = -1, Varin_nimi = "Valitse Väri" });
                polttoaine.Insert(0, new Polttoaine { Id = -1, Polttoaineen_nimi = "Valitse Polttoaine" });
                cbVari.DataSource = vari;
                cbVari.DisplayMember = "Varin_nimi";
                cbVari.ValueMember = "Id";
                cbPolttoaine.DataSource = polttoaine;
                cbPolttoaine.DisplayMember = "Polttoaineen_nimi";
                cbPolttoaine.ValueMember = "Id";

            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {

            RemoveText();
        }

        private void btnLisaa_Click(object sender, EventArgs e)
        {
            if (TextInputs() == true)
            {
                model.Auto auto = new model.Auto()
                {
                    Hinta = decimal.Parse(tbHinta.Text),
                    Rekisteri_paivamaara = DateTime.Parse(dtpPaiva.Text),
                    Moottorin_tilavuus = decimal.Parse(tbTilavuus.Text.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Mittarilukema = int.Parse(tbMittarilukema.Text),
                    AutonMerkkiID = Convert.ToInt32(cbMerkki.SelectedValue),
                    AutonMalliID = Convert.ToInt32(cbMalli.SelectedValue),
                    VaritID = Convert.ToInt32(cbVari.SelectedValue),
                    PolttoaineID = Convert.ToInt32(cbPolttoaine.SelectedValue)
                };

                if (registerHandler.saveAuto(auto) == true)
                {
                    MessageBox.Show("Auto lisätty onnistuneesti");
                    RemoveText();
                }

                else
                {
                    MessageBox.Show("Virhe autoa lisätessä");
                }

            }

            else
            {
                MessageBox.Show("Täytä kaikki kentät lisätäksesi auton");
            }
        }


        private void btnPoista_Click(object sender, EventArgs e)
        {
            if (TextInputs() == true)
            {
                model.Auto auto = new model.Auto()
                {
                    Hinta = decimal.Parse(tbHinta.Text),
                    Rekisteri_paivamaara = DateTime.Parse(dtpPaiva.Text),
                    Moottorin_tilavuus = decimal.Parse(tbTilavuus.Text.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Mittarilukema = int.Parse(tbMittarilukema.Text),
                    AutonMerkkiID = Convert.ToInt32(cbMerkki.SelectedValue),
                    AutonMalliID = Convert.ToInt32(cbMalli.SelectedValue),
                    VaritID = Convert.ToInt32(cbVari.SelectedValue),
                    PolttoaineID = Convert.ToInt32(cbPolttoaine.SelectedValue)
                };

                if (registerHandler.CheckCar(auto) == true)
                {
                    if (registerHandler.DeleteAuto(auto) == true)
                    {
                        MessageBox.Show("Auto poistettu onnistuneesti");
                    }
                    else
                    {
                        MessageBox.Show("Ei poistettu autoa");
                    }
                }

                else
                {
                    MessageBox.Show("Autoa ei löytynyt");
                }

            }
            else
            {
                MessageBox.Show("Antamallasi tiedoilla löyty liian monta autoa. Annan enemmän tietoa autosta");
            }
        }




        public void RemoveText()
        {
            cbMalli.ResetText();
            cbVari.ResetText();
            cbPolttoaine.ResetText();
            tbHinta.Clear();
            tbId.Clear();
            tbMittarilukema.Clear();
            tbTilavuus.Clear();

            LoadAllDataToCbMerkki();
        }


        public bool TextInputs()
        {
            if (!string.IsNullOrEmpty(tbHinta.Text) && !string.IsNullOrEmpty(tbTilavuus.Text) && !string.IsNullOrEmpty(tbMittarilukema.Text))
            {
                if (cbMerkki.SelectedIndex > 0 && cbMalli.SelectedIndex > 0 && cbVari.SelectedIndex > 0 && cbPolttoaine.SelectedIndex > 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private void btnEdellinen_Click(object sender, EventArgs e)
        {
            currentAutoIndex--;

            NextAndPrevious();
        }

        private void btnSeuraava_Click(object sender, EventArgs e)
        {
            currentAutoIndex++;
            NextAndPrevious();
        }

        public void NextAndPrevious()
        {
            List<model.Auto> auto = registerHandler.GetAllAuto();

            if (currentAutoIndex < 0)
            {
                currentAutoIndex = auto.Count - 1;
            }
            else if (currentAutoIndex >= auto.Count)
            {
                currentAutoIndex = 0;
            }

            var item = auto[currentAutoIndex];

            List<AutonMerkki> AutonMerkki = registerHandler.getAllAutoMakers();
            List<Polttoaine> polttoaine = registerHandler.getAutoPolttoaine();
            List<Varit> varit = registerHandler.getAutoVari();
            List<AutonMalli> AutonMalli = registerHandler.GetModelsByID(item.AutonMalliID);

            var MerkkiNimi = AutonMerkki.FirstOrDefault(m => m.Id == item.AutonMerkkiID);
            var MalliNimi = AutonMalli.FirstOrDefault(m => m.Id == item.AutonMalliID);
            var Polttoaine = polttoaine.FirstOrDefault(m => m.Id == item.PolttoaineID);
            var Vari = varit.FirstOrDefault(m => m.Id == item.VaritID);

            tbId.Text = item.Id.ToString();
            tbHinta.Text = item.Hinta.ToString();
            tbMittarilukema.Text = item.Mittarilukema.ToString();
            tbTilavuus.Text = item.Moottorin_tilavuus.ToString();
            dtpPaiva.Text = item.Rekisteri_paivamaara.ToString();
            cbMerkki.Text = MerkkiNimi.merkkiNimi;
            cbMalli.Text = MalliNimi.malliNimi;
            cbPolttoaine.Text = Polttoaine.Polttoaineen_nimi;
            cbVari.Text = Vari.Varin_nimi;
        }



    }
}
