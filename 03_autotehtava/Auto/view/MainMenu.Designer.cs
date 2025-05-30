﻿namespace Autokauppa.view
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSeuraava = new System.Windows.Forms.Button();
            gbAuto = new System.Windows.Forms.GroupBox();
            lblMittariLukema = new System.Windows.Forms.Label();
            lblTilavuus = new System.Windows.Forms.Label();
            lblPaivamaara = new System.Windows.Forms.Label();
            lblHinta = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            cbPolttoaine = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            cbVari = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            cbMalli = new System.Windows.Forms.ComboBox();
            dtpPaiva = new System.Windows.Forms.DateTimePicker();
            tbMittarilukema = new System.Windows.Forms.TextBox();
            tbTilavuus = new System.Windows.Forms.TextBox();
            tbHinta = new System.Windows.Forms.TextBox();
            tbId = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            cbMerkki = new System.Windows.Forms.ComboBox();
            btnEdellinen = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            testaaTietokantaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnLisaa = new System.Windows.Forms.Button();
            btnPoista = new System.Windows.Forms.Button();
            btnClearInput = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            gbAuto.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSeuraava
            // 
            btnSeuraava.Location = new System.Drawing.Point(111, 291);
            btnSeuraava.Name = "btnSeuraava";
            btnSeuraava.Size = new System.Drawing.Size(78, 31);
            btnSeuraava.TabIndex = 17;
            btnSeuraava.Text = "Seuraava";
            btnSeuraava.UseVisualStyleBackColor = true;
            btnSeuraava.Click += btnSeuraava_Click;
            // 
            // gbAuto
            // 
            gbAuto.Controls.Add(label5);
            gbAuto.Controls.Add(lblMittariLukema);
            gbAuto.Controls.Add(lblTilavuus);
            gbAuto.Controls.Add(lblPaivamaara);
            gbAuto.Controls.Add(lblHinta);
            gbAuto.Controls.Add(label4);
            gbAuto.Controls.Add(cbPolttoaine);
            gbAuto.Controls.Add(label3);
            gbAuto.Controls.Add(cbVari);
            gbAuto.Controls.Add(label2);
            gbAuto.Controls.Add(cbMalli);
            gbAuto.Controls.Add(dtpPaiva);
            gbAuto.Controls.Add(tbMittarilukema);
            gbAuto.Controls.Add(tbTilavuus);
            gbAuto.Controls.Add(tbHinta);
            gbAuto.Controls.Add(tbId);
            gbAuto.Controls.Add(label1);
            gbAuto.Controls.Add(cbMerkki);
            gbAuto.Location = new System.Drawing.Point(10, 27);
            gbAuto.Name = "gbAuto";
            gbAuto.Size = new System.Drawing.Size(281, 258);
            gbAuto.TabIndex = 18;
            gbAuto.TabStop = false;
            gbAuto.Text = "Auton tiedot";
            // 
            // lblMittariLukema
            // 
            lblMittariLukema.AutoSize = true;
            lblMittariLukema.Location = new System.Drawing.Point(15, 197);
            lblMittariLukema.Name = "lblMittariLukema";
            lblMittariLukema.Size = new System.Drawing.Size(81, 15);
            lblMittariLukema.TabIndex = 33;
            lblMittariLukema.Text = "Mittarilukema";
            // 
            // lblTilavuus
            // 
            lblTilavuus.AutoSize = true;
            lblTilavuus.Location = new System.Drawing.Point(15, 149);
            lblTilavuus.Name = "lblTilavuus";
            lblTilavuus.Size = new System.Drawing.Size(105, 15);
            lblTilavuus.TabIndex = 32;
            lblTilavuus.Text = "Moottorin tilavuus";
            // 
            // lblPaivamaara
            // 
            lblPaivamaara.AutoSize = true;
            lblPaivamaara.Location = new System.Drawing.Point(13, 105);
            lblPaivamaara.Name = "lblPaivamaara";
            lblPaivamaara.Size = new System.Drawing.Size(115, 15);
            lblPaivamaara.TabIndex = 31;
            lblPaivamaara.Text = "Rekisteri päivämäärä";
            // 
            // lblHinta
            // 
            lblHinta.AutoSize = true;
            lblHinta.Location = new System.Drawing.Point(15, 58);
            lblHinta.Name = "lblHinta";
            lblHinta.Size = new System.Drawing.Size(36, 15);
            lblHinta.TabIndex = 30;
            lblHinta.Text = "Hinta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(160, 197);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 15);
            label4.TabIndex = 29;
            label4.Text = "Polttoaine";
            // 
            // cbPolttoaine
            // 
            cbPolttoaine.FormattingEnabled = true;
            cbPolttoaine.Location = new System.Drawing.Point(160, 215);
            cbPolttoaine.Name = "cbPolttoaine";
            cbPolttoaine.Size = new System.Drawing.Size(106, 23);
            cbPolttoaine.TabIndex = 28;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(160, 149);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(26, 15);
            label3.TabIndex = 27;
            label3.Text = "Väri";
            // 
            // cbVari
            // 
            cbVari.FormattingEnabled = true;
            cbVari.Location = new System.Drawing.Point(160, 169);
            cbVari.Name = "cbVari";
            cbVari.Size = new System.Drawing.Size(106, 23);
            cbVari.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(158, 105);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 15);
            label2.TabIndex = 25;
            label2.Text = "Malli";
            // 
            // cbMalli
            // 
            cbMalli.FormattingEnabled = true;
            cbMalli.Location = new System.Drawing.Point(158, 123);
            cbMalli.Name = "cbMalli";
            cbMalli.Size = new System.Drawing.Size(106, 23);
            cbMalli.TabIndex = 24;
            cbMalli.SelectedIndexChanged += cbMalli_SelectedIndexChanged;
            // 
            // dtpPaiva
            // 
            dtpPaiva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpPaiva.Location = new System.Drawing.Point(15, 123);
            dtpPaiva.Name = "dtpPaiva";
            dtpPaiva.Size = new System.Drawing.Size(113, 23);
            dtpPaiva.TabIndex = 23;
            // 
            // tbMittarilukema
            // 
            tbMittarilukema.Location = new System.Drawing.Point(15, 215);
            tbMittarilukema.Name = "tbMittarilukema";
            tbMittarilukema.Size = new System.Drawing.Size(113, 23);
            tbMittarilukema.TabIndex = 22;
            // 
            // tbTilavuus
            // 
            tbTilavuus.Location = new System.Drawing.Point(15, 169);
            tbTilavuus.Name = "tbTilavuus";
            tbTilavuus.Size = new System.Drawing.Size(113, 23);
            tbTilavuus.TabIndex = 21;
            // 
            // tbHinta
            // 
            tbHinta.Location = new System.Drawing.Point(15, 76);
            tbHinta.Name = "tbHinta";
            tbHinta.Size = new System.Drawing.Size(113, 23);
            tbHinta.TabIndex = 20;
            // 
            // tbId
            // 
            tbId.Location = new System.Drawing.Point(78, 22);
            tbId.Name = "tbId";
            tbId.ReadOnly = true;
            tbId.Size = new System.Drawing.Size(113, 23);
            tbId.TabIndex = 19;
            tbId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(158, 58);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(69, 15);
            label1.TabIndex = 18;
            label1.Text = "Automerkki";
            // 
            // cbMerkki
            // 
            cbMerkki.FormattingEnabled = true;
            cbMerkki.Location = new System.Drawing.Point(158, 76);
            cbMerkki.Name = "cbMerkki";
            cbMerkki.Size = new System.Drawing.Size(106, 23);
            cbMerkki.TabIndex = 17;
            cbMerkki.SelectedIndexChanged += cbMerkki_SelectedIndexChanged;
            // 
            // btnEdellinen
            // 
            btnEdellinen.Location = new System.Drawing.Point(10, 291);
            btnEdellinen.Name = "btnEdellinen";
            btnEdellinen.Size = new System.Drawing.Size(81, 31);
            btnEdellinen.TabIndex = 19;
            btnEdellinen.Text = "Edellinen";
            btnEdellinen.UseVisualStyleBackColor = true;
            btnEdellinen.Click += btnEdellinen_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(319, 24);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem1 });
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            exitToolStripMenuItem.Text = "Tiedosto";
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            exitToolStripMenuItem1.Text = "Poistu";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { testaaTietokantaaToolStripMenuItem });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            aboutToolStripMenuItem.Text = "Muuta...";
            // 
            // testaaTietokantaaToolStripMenuItem
            // 
            testaaTietokantaaToolStripMenuItem.Name = "testaaTietokantaaToolStripMenuItem";
            testaaTietokantaaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            testaaTietokantaaToolStripMenuItem.Text = "Testaa tietokantaa";
            testaaTietokantaaToolStripMenuItem.Click += testaaTietokantaaToolStripMenuItem_Click;
            // 
            // btnLisaa
            // 
            btnLisaa.Location = new System.Drawing.Point(214, 291);
            btnLisaa.Name = "btnLisaa";
            btnLisaa.Size = new System.Drawing.Size(78, 31);
            btnLisaa.TabIndex = 21;
            btnLisaa.Text = "Lisää";
            btnLisaa.UseVisualStyleBackColor = true;
            btnLisaa.Click += btnLisaa_Click;
            // 
            // btnPoista
            // 
            btnPoista.Location = new System.Drawing.Point(130, 341);
            btnPoista.Name = "btnPoista";
            btnPoista.Size = new System.Drawing.Size(85, 31);
            btnPoista.TabIndex = 22;
            btnPoista.Text = "Poista";
            btnPoista.UseVisualStyleBackColor = true;
            btnPoista.Click += btnPoista_Click;
            // 
            // btnClearInput
            // 
            btnClearInput.Location = new System.Drawing.Point(10, 341);
            btnClearInput.Name = "btnClearInput";
            btnClearInput.Size = new System.Drawing.Size(105, 33);
            btnClearInput.TabIndex = 23;
            btnClearInput.Text = "Tyhjennä kentät";
            btnClearInput.UseVisualStyleBackColor = true;
            btnClearInput.Click += btnClearInput_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(52, 26);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(20, 15);
            label5.TabIndex = 34;
            label5.Text = "Id:";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(319, 426);
            Controls.Add(btnClearInput);
            Controls.Add(btnPoista);
            Controls.Add(btnLisaa);
            Controls.Add(btnEdellinen);
            Controls.Add(gbAuto);
            Controls.Add(btnSeuraava);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4);
            Name = "MainMenu";
            Text = "MainMenu";
            gbAuto.ResumeLayout(false);
            gbAuto.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnSeuraava;
        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPolttoaine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMalli;
        private System.Windows.Forms.DateTimePicker dtpPaiva;
        private System.Windows.Forms.TextBox tbMittarilukema;
        private System.Windows.Forms.TextBox tbTilavuus;
        private System.Windows.Forms.TextBox tbHinta;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMerkki;
        private System.Windows.Forms.Button btnEdellinen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testaaTietokantaaToolStripMenuItem;
        private System.Windows.Forms.Button btnLisaa;
        private System.Windows.Forms.Button btnPoista;
        private System.Windows.Forms.Button btnClearInput;
        private System.Windows.Forms.Label lblMittariLukema;
        private System.Windows.Forms.Label lblTilavuus;
        private System.Windows.Forms.Label lblPaivamaara;
        private System.Windows.Forms.Label lblHinta;
        private System.Windows.Forms.Label label5;
    }
}