namespace Opiskelijat_T2
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtEtunimi = new System.Windows.Forms.TextBox();
            this.txtSukunimi = new System.Windows.Forms.TextBox();
            this.lblEtunimi = new System.Windows.Forms.Label();
            this.lblSukunimi = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnPoistaOpiskelija = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(62, 205);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(669, 201);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(62, 119);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // txtEtunimi
            // 
            this.txtEtunimi.Location = new System.Drawing.Point(62, 60);
            this.txtEtunimi.Name = "txtEtunimi";
            this.txtEtunimi.Size = new System.Drawing.Size(106, 26);
            this.txtEtunimi.TabIndex = 3;
            // 
            // txtSukunimi
            // 
            this.txtSukunimi.Location = new System.Drawing.Point(210, 60);
            this.txtSukunimi.Name = "txtSukunimi";
            this.txtSukunimi.Size = new System.Drawing.Size(106, 26);
            this.txtSukunimi.TabIndex = 4;
            // 
            // lblEtunimi
            // 
            this.lblEtunimi.AutoSize = true;
            this.lblEtunimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtunimi.Location = new System.Drawing.Point(72, 20);
            this.lblEtunimi.Name = "lblEtunimi";
            this.lblEtunimi.Size = new System.Drawing.Size(83, 25);
            this.lblEtunimi.TabIndex = 7;
            this.lblEtunimi.Text = "Etunimi";
            // 
            // lblSukunimi
            // 
            this.lblSukunimi.AutoSize = true;
            this.lblSukunimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSukunimi.Location = new System.Drawing.Point(210, 20);
            this.lblSukunimi.Name = "lblSukunimi";
            this.lblSukunimi.Size = new System.Drawing.Size(101, 25);
            this.lblSukunimi.TabIndex = 11;
            this.lblSukunimi.Text = "Sukunimi";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudent.Location = new System.Drawing.Point(361, 48);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(156, 46);
            this.btnAddStudent.TabIndex = 13;
            this.btnAddStudent.Text = "Lisää oppilas";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnPoistaOpiskelija
            // 
            this.btnPoistaOpiskelija.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoistaOpiskelija.Location = new System.Drawing.Point(554, 48);
            this.btnPoistaOpiskelija.Name = "btnPoistaOpiskelija";
            this.btnPoistaOpiskelija.Size = new System.Drawing.Size(197, 46);
            this.btnPoistaOpiskelija.TabIndex = 14;
            this.btnPoistaOpiskelija.Text = "Poista Opiskelija";
            this.btnPoistaOpiskelija.UseVisualStyleBackColor = true;
            this.btnPoistaOpiskelija.Click += new System.EventHandler(this.btnPoistaOpiskelija_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPoistaOpiskelija);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.lblSukunimi);
            this.Controls.Add(this.lblEtunimi);
            this.Controls.Add(this.txtSukunimi);
            this.Controls.Add(this.txtEtunimi);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtEtunimi;
        private System.Windows.Forms.TextBox txtSukunimi;
        private System.Windows.Forms.Label lblEtunimi;
        private System.Windows.Forms.Label lblSukunimi;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnPoistaOpiskelija;
    }
}

