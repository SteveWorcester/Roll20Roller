namespace CharacterSheet5e.Forms
{
    partial class StartForm
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
            this.RbCloron = new System.Windows.Forms.RadioButton();
            this.RbGil = new System.Windows.Forms.RadioButton();
            this.RbZaag = new System.Windows.Forms.RadioButton();
            this.RbKomazur = new System.Windows.Forms.RadioButton();
            this.BtnImport = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.TxtOther = new System.Windows.Forms.TextBox();
            this.RbOther = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RbCloron
            // 
            this.RbCloron.AutoSize = true;
            this.RbCloron.Location = new System.Drawing.Point(12, 12);
            this.RbCloron.Name = "RbCloron";
            this.RbCloron.Size = new System.Drawing.Size(55, 17);
            this.RbCloron.TabIndex = 3;
            this.RbCloron.TabStop = true;
            this.RbCloron.Text = "Cloron";
            this.RbCloron.UseVisualStyleBackColor = true;
            // 
            // RbGil
            // 
            this.RbGil.AutoSize = true;
            this.RbGil.Location = new System.Drawing.Point(12, 35);
            this.RbGil.Name = "RbGil";
            this.RbGil.Size = new System.Drawing.Size(37, 17);
            this.RbGil.TabIndex = 4;
            this.RbGil.TabStop = true;
            this.RbGil.Text = "Gil";
            this.RbGil.UseVisualStyleBackColor = true;
            // 
            // RbZaag
            // 
            this.RbZaag.AutoSize = true;
            this.RbZaag.Location = new System.Drawing.Point(12, 58);
            this.RbZaag.Name = "RbZaag";
            this.RbZaag.Size = new System.Drawing.Size(50, 17);
            this.RbZaag.TabIndex = 5;
            this.RbZaag.TabStop = true;
            this.RbZaag.Text = "Zaag";
            this.RbZaag.UseVisualStyleBackColor = true;
            // 
            // RbKomazur
            // 
            this.RbKomazur.AutoSize = true;
            this.RbKomazur.Location = new System.Drawing.Point(12, 81);
            this.RbKomazur.Name = "RbKomazur";
            this.RbKomazur.Size = new System.Drawing.Size(66, 17);
            this.RbKomazur.TabIndex = 6;
            this.RbKomazur.TabStop = true;
            this.RbKomazur.Text = "Komazur";
            this.RbKomazur.UseVisualStyleBackColor = true;
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(12, 200);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(100, 23);
            this.BtnImport.TabIndex = 8;
            this.BtnImport.Text = "Import Character";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 104);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(62, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Kohbee";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // TxtOther
            // 
            this.TxtOther.Location = new System.Drawing.Point(91, 151);
            this.TxtOther.Name = "TxtOther";
            this.TxtOther.Size = new System.Drawing.Size(100, 20);
            this.TxtOther.TabIndex = 11;
            // 
            // RbOther
            // 
            this.RbOther.AutoSize = true;
            this.RbOther.Location = new System.Drawing.Point(12, 127);
            this.RbOther.Name = "RbOther";
            this.RbOther.Size = new System.Drawing.Size(129, 17);
            this.RbOther.TabIndex = 12;
            this.RbOther.TabStop = true;
            this.RbOther.Text = "Other (enter ID below)";
            this.RbOther.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(9, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "/profile/UserName/characters/";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(160, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "This Number!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Character ID: ";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 235);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RbOther);
            this.Controls.Add(this.TxtOther);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.RbKomazur);
            this.Controls.Add(this.RbZaag);
            this.Controls.Add(this.RbGil);
            this.Controls.Add(this.RbCloron);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton RbCloron;
        private System.Windows.Forms.RadioButton RbGil;
        private System.Windows.Forms.RadioButton RbZaag;
        private System.Windows.Forms.RadioButton RbKomazur;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox TxtOther;
        private System.Windows.Forms.RadioButton RbOther;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}