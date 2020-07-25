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
            this.BtnSkillRoll = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnInitiative = new System.Windows.Forms.Button();
            this.LblSelectToken = new System.Windows.Forms.Label();
            this.GrpAttacks = new System.Windows.Forms.GroupBox();
            this.BtnAttack2 = new System.Windows.Forms.Button();
            this.BtnAttack1 = new System.Windows.Forms.Button();
            this.GrpSavingThrows = new System.Windows.Forms.GroupBox();
            this.BtnSavingThrowCha = new System.Windows.Forms.Button();
            this.BtnSavingThrowWis = new System.Windows.Forms.Button();
            this.BtnSavingThrowInt = new System.Windows.Forms.Button();
            this.BtnSavingThrowCon = new System.Windows.Forms.Button();
            this.BtnSavingThrowDex = new System.Windows.Forms.Button();
            this.BtnSavingThrowStr = new System.Windows.Forms.Button();
            this.GrpSkills = new System.Windows.Forms.GroupBox();
            this.GrpInitiative = new System.Windows.Forms.GroupBox();
            this.CbTopmost = new System.Windows.Forms.CheckBox();
            this.LblTopmost = new System.Windows.Forms.Label();
            this.GrpAttacks.SuspendLayout();
            this.GrpSavingThrows.SuspendLayout();
            this.GrpSkills.SuspendLayout();
            this.GrpInitiative.SuspendLayout();
            this.SuspendLayout();
            // 
            // RbAdvantage
            // 
            this.RbAdvantage.AutoSize = true;
            this.RbAdvantage.Location = new System.Drawing.Point(12, 26);
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
            this.RbNormal.Location = new System.Drawing.Point(133, 26);
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
            this.RbDisadvantage.Location = new System.Drawing.Point(234, 26);
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
            this.DdlSkills.Location = new System.Drawing.Point(6, 19);
            this.DdlSkills.Name = "DdlSkills";
            this.DdlSkills.Size = new System.Drawing.Size(132, 21);
            this.DdlSkills.TabIndex = 4;
            this.DdlSkills.SelectedIndexChanged += new System.EventHandler(this.DdlSkills_SelectedIndexChanged);
            // 
            // BtnSkillRoll
            // 
            this.BtnSkillRoll.Location = new System.Drawing.Point(6, 46);
            this.BtnSkillRoll.Name = "BtnSkillRoll";
            this.BtnSkillRoll.Size = new System.Drawing.Size(132, 23);
            this.BtnSkillRoll.TabIndex = 6;
            this.BtnSkillRoll.Text = "Copy Skill Roll";
            this.BtnSkillRoll.UseVisualStyleBackColor = true;
            this.BtnSkillRoll.Click += new System.EventHandler(this.BtnSkillRoll_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Red;
            this.BtnExit.Location = new System.Drawing.Point(3, 222);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(39, 31);
            this.BtnExit.TabIndex = 8;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnInitiative
            // 
            this.BtnInitiative.Location = new System.Drawing.Point(6, 32);
            this.BtnInitiative.Name = "BtnInitiative";
            this.BtnInitiative.Size = new System.Drawing.Size(155, 29);
            this.BtnInitiative.TabIndex = 9;
            this.BtnInitiative.Text = "Roll Initiative!";
            this.BtnInitiative.UseVisualStyleBackColor = true;
            this.BtnInitiative.Click += new System.EventHandler(this.BtnInitiative_Click);
            // 
            // LblSelectToken
            // 
            this.LblSelectToken.AutoSize = true;
            this.LblSelectToken.Location = new System.Drawing.Point(6, 16);
            this.LblSelectToken.Name = "LblSelectToken";
            this.LblSelectToken.Size = new System.Drawing.Size(93, 13);
            this.LblSelectToken.TabIndex = 10;
            this.LblSelectToken.Text = "Select your token!";
            // 
            // GrpAttacks
            // 
            this.GrpAttacks.Controls.Add(this.BtnAttack2);
            this.GrpAttacks.Controls.Add(this.BtnAttack1);
            this.GrpAttacks.Location = new System.Drawing.Point(164, 127);
            this.GrpAttacks.Name = "GrpAttacks";
            this.GrpAttacks.Size = new System.Drawing.Size(155, 103);
            this.GrpAttacks.TabIndex = 11;
            this.GrpAttacks.TabStop = false;
            this.GrpAttacks.Text = "Attacks";
            // 
            // BtnAttack2
            // 
            this.BtnAttack2.Location = new System.Drawing.Point(6, 62);
            this.BtnAttack2.Name = "BtnAttack2";
            this.BtnAttack2.Size = new System.Drawing.Size(143, 36);
            this.BtnAttack2.TabIndex = 1;
            this.BtnAttack2.Text = "BtnAttack2";
            this.BtnAttack2.UseVisualStyleBackColor = true;
            this.BtnAttack2.Click += new System.EventHandler(this.BtnAttack2_Click);
            // 
            // BtnAttack1
            // 
            this.BtnAttack1.Location = new System.Drawing.Point(6, 20);
            this.BtnAttack1.Name = "BtnAttack1";
            this.BtnAttack1.Size = new System.Drawing.Size(143, 36);
            this.BtnAttack1.TabIndex = 0;
            this.BtnAttack1.Text = "BtnAttack1";
            this.BtnAttack1.UseVisualStyleBackColor = true;
            this.BtnAttack1.Click += new System.EventHandler(this.BtnAttack1_Click);
            // 
            // GrpSavingThrows
            // 
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowCha);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowWis);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowInt);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowCon);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowDex);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowStr);
            this.GrpSavingThrows.Location = new System.Drawing.Point(3, 49);
            this.GrpSavingThrows.Name = "GrpSavingThrows";
            this.GrpSavingThrows.Size = new System.Drawing.Size(155, 72);
            this.GrpSavingThrows.TabIndex = 12;
            this.GrpSavingThrows.TabStop = false;
            this.GrpSavingThrows.Text = "Saving Throws";
            // 
            // BtnSavingThrowCha
            // 
            this.BtnSavingThrowCha.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSavingThrowCha.Location = new System.Drawing.Point(109, 46);
            this.BtnSavingThrowCha.Name = "BtnSavingThrowCha";
            this.BtnSavingThrowCha.Size = new System.Drawing.Size(40, 23);
            this.BtnSavingThrowCha.TabIndex = 5;
            this.BtnSavingThrowCha.Text = "Cha";
            this.BtnSavingThrowCha.UseVisualStyleBackColor = true;
            this.BtnSavingThrowCha.Click += new System.EventHandler(this.BtnSavingThrowCha_Click);
            // 
            // BtnSavingThrowWis
            // 
            this.BtnSavingThrowWis.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSavingThrowWis.Location = new System.Drawing.Point(63, 46);
            this.BtnSavingThrowWis.Name = "BtnSavingThrowWis";
            this.BtnSavingThrowWis.Size = new System.Drawing.Size(40, 23);
            this.BtnSavingThrowWis.TabIndex = 4;
            this.BtnSavingThrowWis.Text = "Wis";
            this.BtnSavingThrowWis.UseVisualStyleBackColor = true;
            this.BtnSavingThrowWis.Click += new System.EventHandler(this.BtnSavingThrowWis_Click);
            // 
            // BtnSavingThrowInt
            // 
            this.BtnSavingThrowInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSavingThrowInt.Location = new System.Drawing.Point(17, 46);
            this.BtnSavingThrowInt.Name = "BtnSavingThrowInt";
            this.BtnSavingThrowInt.Size = new System.Drawing.Size(40, 23);
            this.BtnSavingThrowInt.TabIndex = 3;
            this.BtnSavingThrowInt.Text = "Int";
            this.BtnSavingThrowInt.UseVisualStyleBackColor = true;
            this.BtnSavingThrowInt.Click += new System.EventHandler(this.BtnSavingThrowInt_Click);
            // 
            // BtnSavingThrowCon
            // 
            this.BtnSavingThrowCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSavingThrowCon.Location = new System.Drawing.Point(109, 19);
            this.BtnSavingThrowCon.Name = "BtnSavingThrowCon";
            this.BtnSavingThrowCon.Size = new System.Drawing.Size(40, 23);
            this.BtnSavingThrowCon.TabIndex = 2;
            this.BtnSavingThrowCon.Text = "Con";
            this.BtnSavingThrowCon.UseVisualStyleBackColor = true;
            this.BtnSavingThrowCon.Click += new System.EventHandler(this.BtnSavingThrowCon_Click);
            // 
            // BtnSavingThrowDex
            // 
            this.BtnSavingThrowDex.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSavingThrowDex.Location = new System.Drawing.Point(63, 19);
            this.BtnSavingThrowDex.Name = "BtnSavingThrowDex";
            this.BtnSavingThrowDex.Size = new System.Drawing.Size(40, 23);
            this.BtnSavingThrowDex.TabIndex = 1;
            this.BtnSavingThrowDex.Text = "Dex";
            this.BtnSavingThrowDex.UseVisualStyleBackColor = true;
            this.BtnSavingThrowDex.Click += new System.EventHandler(this.BtnSavingThrowDex_Click);
            // 
            // BtnSavingThrowStr
            // 
            this.BtnSavingThrowStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSavingThrowStr.Location = new System.Drawing.Point(17, 19);
            this.BtnSavingThrowStr.Name = "BtnSavingThrowStr";
            this.BtnSavingThrowStr.Size = new System.Drawing.Size(40, 23);
            this.BtnSavingThrowStr.TabIndex = 0;
            this.BtnSavingThrowStr.Text = "Str";
            this.BtnSavingThrowStr.UseVisualStyleBackColor = true;
            this.BtnSavingThrowStr.Click += new System.EventHandler(this.BtnSavingThrowStr_Click);
            // 
            // GrpSkills
            // 
            this.GrpSkills.Controls.Add(this.DdlSkills);
            this.GrpSkills.Controls.Add(this.BtnSkillRoll);
            this.GrpSkills.Location = new System.Drawing.Point(3, 127);
            this.GrpSkills.Name = "GrpSkills";
            this.GrpSkills.Size = new System.Drawing.Size(155, 80);
            this.GrpSkills.TabIndex = 13;
            this.GrpSkills.TabStop = false;
            this.GrpSkills.Text = "Skills";
            // 
            // GrpInitiative
            // 
            this.GrpInitiative.Controls.Add(this.BtnInitiative);
            this.GrpInitiative.Controls.Add(this.LblSelectToken);
            this.GrpInitiative.Location = new System.Drawing.Point(164, 49);
            this.GrpInitiative.Name = "GrpInitiative";
            this.GrpInitiative.Size = new System.Drawing.Size(161, 72);
            this.GrpInitiative.TabIndex = 14;
            this.GrpInitiative.TabStop = false;
            this.GrpInitiative.Text = "Initiative";
            // 
            // CbTopmost
            // 
            this.CbTopmost.AutoSize = true;
            this.CbTopmost.Location = new System.Drawing.Point(310, 236);
            this.CbTopmost.Name = "CbTopmost";
            this.CbTopmost.Size = new System.Drawing.Size(15, 14);
            this.CbTopmost.TabIndex = 15;
            this.CbTopmost.UseVisualStyleBackColor = true;
            this.CbTopmost.CheckedChanged += new System.EventHandler(this.CbTopmost_CheckedChanged);
            // 
            // LblTopmost
            // 
            this.LblTopmost.AutoSize = true;
            this.LblTopmost.Location = new System.Drawing.Point(231, 237);
            this.LblTopmost.Name = "LblTopmost";
            this.LblTopmost.Size = new System.Drawing.Size(73, 13);
            this.LblTopmost.TabIndex = 16;
            this.LblTopmost.Text = "Always on top";
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 255);
            this.Controls.Add(this.LblTopmost);
            this.Controls.Add(this.CbTopmost);
            this.Controls.Add(this.GrpInitiative);
            this.Controls.Add(this.GrpSkills);
            this.Controls.Add(this.GrpAttacks);
            this.Controls.Add(this.GrpSavingThrows);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.LblCharacterName);
            this.Controls.Add(this.RbDisadvantage);
            this.Controls.Add(this.RbNormal);
            this.Controls.Add(this.RbAdvantage);
            this.Name = "CharacterForm";
            this.Text = "Skills";
            this.TopMost = true;
            this.GrpAttacks.ResumeLayout(false);
            this.GrpSavingThrows.ResumeLayout(false);
            this.GrpSkills.ResumeLayout(false);
            this.GrpInitiative.ResumeLayout(false);
            this.GrpInitiative.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RbAdvantage;
        private System.Windows.Forms.RadioButton RbNormal;
        private System.Windows.Forms.RadioButton RbDisadvantage;
        private System.Windows.Forms.Label LblCharacterName;
        private System.Windows.Forms.ComboBox DdlSkills;
        private System.Windows.Forms.Button BtnSkillRoll;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnInitiative;
        private System.Windows.Forms.Label LblSelectToken;
        private System.Windows.Forms.GroupBox GrpAttacks;
        private System.Windows.Forms.Button BtnAttack2;
        private System.Windows.Forms.Button BtnAttack1;
        private System.Windows.Forms.GroupBox GrpSavingThrows;
        private System.Windows.Forms.GroupBox GrpSkills;
        private System.Windows.Forms.GroupBox GrpInitiative;
        private System.Windows.Forms.Button BtnSavingThrowCha;
        private System.Windows.Forms.Button BtnSavingThrowWis;
        private System.Windows.Forms.Button BtnSavingThrowInt;
        private System.Windows.Forms.Button BtnSavingThrowCon;
        private System.Windows.Forms.Button BtnSavingThrowDex;
        private System.Windows.Forms.Button BtnSavingThrowStr;
        private System.Windows.Forms.CheckBox CbTopmost;
        private System.Windows.Forms.Label LblTopmost;
    }
}