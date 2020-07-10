namespace CharacterSheet5e.Forms
{
    partial class CharacterForm
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
            this.RbAdvantage = new System.Windows.Forms.RadioButton();
            this.RbNormal = new System.Windows.Forms.RadioButton();
            this.RbDisadvantage = new System.Windows.Forms.RadioButton();
            this.LblCharacterName = new System.Windows.Forms.Label();
            this.DdlSkills = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSkillRoll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RbAdvantage
            // 
            this.RbAdvantage.AutoSize = true;
            this.RbAdvantage.Location = new System.Drawing.Point(17, 25);
            this.RbAdvantage.Name = "RbAdvantage";
            this.RbAdvantage.Size = new System.Drawing.Size(77, 17);
            this.RbAdvantage.TabIndex = 0;
            this.RbAdvantage.TabStop = true;
            this.RbAdvantage.Text = "Advantage";
            this.RbAdvantage.UseVisualStyleBackColor = true;
            // 
            // RbNormal
            // 
            this.RbNormal.AutoSize = true;
            this.RbNormal.Location = new System.Drawing.Point(17, 48);
            this.RbNormal.Name = "RbNormal";
            this.RbNormal.Size = new System.Drawing.Size(58, 17);
            this.RbNormal.TabIndex = 1;
            this.RbNormal.TabStop = true;
            this.RbNormal.Text = "Normal";
            this.RbNormal.UseVisualStyleBackColor = true;
            // 
            // RbDisadvantage
            // 
            this.RbDisadvantage.AutoSize = true;
            this.RbDisadvantage.Location = new System.Drawing.Point(17, 71);
            this.RbDisadvantage.Name = "RbDisadvantage";
            this.RbDisadvantage.Size = new System.Drawing.Size(91, 17);
            this.RbDisadvantage.TabIndex = 2;
            this.RbDisadvantage.TabStop = true;
            this.RbDisadvantage.Text = "Disadvantage";
            this.RbDisadvantage.UseVisualStyleBackColor = true;
            // 
            // LblCharacterName
            // 
            this.LblCharacterName.Location = new System.Drawing.Point(0, 0);
            this.LblCharacterName.Name = "LblCharacterName";
            this.LblCharacterName.Size = new System.Drawing.Size(158, 23);
            this.LblCharacterName.TabIndex = 7;
            this.LblCharacterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DdlSkills
            // 
            this.DdlSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DdlSkills.FormattingEnabled = true;
            this.DdlSkills.Location = new System.Drawing.Point(12, 118);
            this.DdlSkills.Name = "DdlSkills";
            this.DdlSkills.Size = new System.Drawing.Size(121, 21);
            this.DdlSkills.TabIndex = 4;
            this.DdlSkills.SelectedIndexChanged += new System.EventHandler(this.DdlSkills_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Skill";
            // 
            // BtnSkillRoll
            // 
            this.BtnSkillRoll.Location = new System.Drawing.Point(12, 145);
            this.BtnSkillRoll.Name = "BtnSkillRoll";
            this.BtnSkillRoll.Size = new System.Drawing.Size(132, 23);
            this.BtnSkillRoll.TabIndex = 6;
            this.BtnSkillRoll.Text = "Copy Roll To Clipboard";
            this.BtnSkillRoll.UseVisualStyleBackColor = true;
            this.BtnSkillRoll.Click += new System.EventHandler(this.BtnSkillRoll_Click);
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 180);
            this.Controls.Add(this.BtnSkillRoll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DdlSkills);
            this.Controls.Add(this.LblCharacterName);
            this.Controls.Add(this.RbDisadvantage);
            this.Controls.Add(this.RbNormal);
            this.Controls.Add(this.RbAdvantage);
            this.Name = "CharacterForm";
            this.Text = "Skills";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RbAdvantage;
        private System.Windows.Forms.RadioButton RbNormal;
        private System.Windows.Forms.RadioButton RbDisadvantage;
        private System.Windows.Forms.Label LblCharacterName;
        private System.Windows.Forms.ComboBox DdlSkills;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSkillRoll;
    }
}