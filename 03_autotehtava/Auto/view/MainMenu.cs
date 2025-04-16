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


namespace Autokauppa.view
{
    public partial class MainMenu : Form
    {


        KaupanLogiikka registerHandler;

        public MainMenu()
        {
            registerHandler = new KaupanLogiikka();
            InitializeComponent();
            LoadAllDataToCbMerkki();
        }

        private void testaaTietokantaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registerHandler.TestDatabaseConnection();
        }

        public void LoadAllDataToCbMerkki()
        {
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
                int malliId = (int)cbMalli.SelectedValue;
                int merkkiId = (int)cbMerkki.SelectedValue;

                List<Varit> vari = registerHandler.getAutoVari(merkkiId, malliId);

                vari.Insert(0, new Varit { Id = -1, Varin_nimi = "Valitse Väri" });
                cbVari.DataSource = vari;
                cbVari.DisplayMember = "Varin_nimi";
                cbVari.ValueMember = "Id";

            }
        }

        private void cbVari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVari.SelectedIndex > 0)
            {
                int malliId = (int)cbMalli.SelectedValue;
                int merkkiId = (int)cbMerkki.SelectedValue;
                int variID = (int)cbVari.SelectedValue;

                List<Polttoaine> polttoaine = registerHandler.getAutoPolttoaine(merkkiId, malliId, variID);

                polttoaine.Insert(0, new Polttoaine { Id = -1, Polttoaineen_nimi = "Valitse Polttoaine" });
                cbPolttoaine.DataSource = polttoaine;
                cbPolttoaine.DisplayMember = "Polttoaineen_nimi";
                cbPolttoaine.ValueMember = "Id";
            }
        }

        private void btnClearInput_Click(object sender, EventArgs e)
        {
            cbMerkki.ResetText();
            cbMalli.ResetText();
            cbVari.ResetText();
            cbPolttoaine.ResetText();
            tbHinta.Clear();
            tbId.Clear();
            tbMittarilukema.Clear();
            tbTilavuus.Clear(); 

            cbMerkki.Text = "Valitse merkki";
        }
    }
}
