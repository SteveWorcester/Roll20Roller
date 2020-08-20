namespace Roll20Roller.Forms
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
            this.LblCharacterName = new System.Windows.Forms.Label();
            this.DdlSkills = new System.Windows.Forms.ComboBox();
            this.BtnSkillRoll = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnInitiative = new System.Windows.Forms.Button();
            this.LblSelectToken = new System.Windows.Forms.Label();
            this.GrpAttacks = new System.Windows.Forms.GroupBox();
            this.LblVersatile = new System.Windows.Forms.Label();
            this.CbVersatile = new System.Windows.Forms.CheckBox();
            this.DdlEquippedWeapon = new System.Windows.Forms.ComboBox();
            this.BtnAttack1 = new System.Windows.Forms.Button();
            this.GrpSavingThrows = new System.Windows.Forms.GroupBox();
            this.CbStatCheck = new System.Windows.Forms.CheckBox();
            this.BtnSavingThrowStr = new System.Windows.Forms.Button();
            this.BtnSavingThrowCha = new System.Windows.Forms.Button();
            this.BtnSavingThrowWis = new System.Windows.Forms.Button();
            this.BtnSavingThrowInt = new System.Windows.Forms.Button();
            this.BtnSavingThrowCon = new System.Windows.Forms.Button();
            this.BtnSavingThrowDex = new System.Windows.Forms.Button();
            this.GrpSkills = new System.Windows.Forms.GroupBox();
            this.GrpInitiative = new System.Windows.Forms.GroupBox();
            this.CbTopmost = new System.Windows.Forms.CheckBox();
            this.LblTopmost = new System.Windows.Forms.Label();
            this.CbGmOnly = new System.Windows.Forms.CheckBox();
            this.GrpClassOptions1 = new System.Windows.Forms.GroupBox();
            this.CbRage = new System.Windows.Forms.CheckBox();
            this.LblGmOnly = new System.Windows.Forms.Label();
            this.GrpCustom = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtBonus4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtDieSides4 = new System.Windows.Forms.TextBox();
            this.TxtNumberOfDice4 = new System.Windows.Forms.TextBox();
            this.BtnRollCustom4 = new System.Windows.Forms.Button();
            this.TxtDescription4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBonus3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDieSides3 = new System.Windows.Forms.TextBox();
            this.TxtNumberOfDice3 = new System.Windows.Forms.TextBox();
            this.BtnRollCustom3 = new System.Windows.Forms.Button();
            this.TxtDescription3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtBonus2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDieSides2 = new System.Windows.Forms.TextBox();
            this.TxtNumberOfDice2 = new System.Windows.Forms.TextBox();
            this.BtnRollCustom2 = new System.Windows.Forms.Button();
            this.TxtDescription2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtBonus1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDieSides1 = new System.Windows.Forms.TextBox();
            this.TxtNumberOfDice1 = new System.Windows.Forms.TextBox();
            this.BtnRollCustom1 = new System.Windows.Forms.Button();
            this.TxtDescription1 = new System.Windows.Forms.TextBox();
            this.LblPlus = new System.Windows.Forms.Label();
            this.TxtBonus0 = new System.Windows.Forms.TextBox();
            this.LblD = new System.Windows.Forms.Label();
            this.TxtDieSides0 = new System.Windows.Forms.TextBox();
            this.TxtNumberOfDice0 = new System.Windows.Forms.TextBox();
            this.BtnRollCustom0 = new System.Windows.Forms.Button();
            this.TxtDescription0 = new System.Windows.Forms.TextBox();
            this.LblBonus = new System.Windows.Forms.Label();
            this.LblDice = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.GrpSpells = new System.Windows.Forms.GroupBox();
            this.BtnSpell = new System.Windows.Forms.Button();
            this.DdlSpells = new System.Windows.Forms.ComboBox();
            this.RbAdvantage = new System.Windows.Forms.Button();
            this.RbNormal = new System.Windows.Forms.Button();
            this.RbDisadvantage = new System.Windows.Forms.Button();
            this.GrpAttacks.SuspendLayout();
            this.GrpSavingThrows.SuspendLayout();
            this.GrpSkills.SuspendLayout();
            this.GrpInitiative.SuspendLayout();
            this.GrpClassOptions1.SuspendLayout();
            this.GrpCustom.SuspendLayout();
            this.GrpSpells.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblCharacterName
            // 
            this.LblCharacterName.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.LblCharacterName.Location = new System.Drawing.Point(0, 0);
            this.LblCharacterName.Name = "LblCharacterName";
            this.LblCharacterName.Size = new System.Drawing.Size(219, 23);
            this.LblCharacterName.TabIndex = 7;
            this.LblCharacterName.Text = "name text";
            this.LblCharacterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.BtnExit.Location = new System.Drawing.Point(3, 487);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(39, 31);
            this.BtnExit.TabIndex = 8;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnInitiative
            // 
            this.BtnInitiative.Location = new System.Drawing.Point(6, 40);
            this.BtnInitiative.Name = "BtnInitiative";
            this.BtnInitiative.Size = new System.Drawing.Size(143, 29);
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
            this.GrpAttacks.Controls.Add(this.LblVersatile);
            this.GrpAttacks.Controls.Add(this.CbVersatile);
            this.GrpAttacks.Controls.Add(this.DdlEquippedWeapon);
            this.GrpAttacks.Controls.Add(this.BtnAttack1);
            this.GrpAttacks.Location = new System.Drawing.Point(164, 146);
            this.GrpAttacks.Name = "GrpAttacks";
            this.GrpAttacks.Size = new System.Drawing.Size(155, 80);
            this.GrpAttacks.TabIndex = 11;
            this.GrpAttacks.TabStop = false;
            this.GrpAttacks.Text = "Attacks";
            // 
            // LblVersatile
            // 
            this.LblVersatile.AutoSize = true;
            this.LblVersatile.Location = new System.Drawing.Point(102, 51);
            this.LblVersatile.Name = "LblVersatile";
            this.LblVersatile.Size = new System.Drawing.Size(47, 13);
            this.LblVersatile.TabIndex = 9;
            this.LblVersatile.Text = "Versatile";
            // 
            // CbVersatile
            // 
            this.CbVersatile.AutoSize = true;
            this.CbVersatile.Location = new System.Drawing.Point(89, 51);
            this.CbVersatile.Name = "CbVersatile";
            this.CbVersatile.Size = new System.Drawing.Size(15, 14);
            this.CbVersatile.TabIndex = 8;
            this.CbVersatile.UseVisualStyleBackColor = true;
            // 
            // DdlEquippedWeapon
            // 
            this.DdlEquippedWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DdlEquippedWeapon.FormattingEnabled = true;
            this.DdlEquippedWeapon.Location = new System.Drawing.Point(6, 19);
            this.DdlEquippedWeapon.Name = "DdlEquippedWeapon";
            this.DdlEquippedWeapon.Size = new System.Drawing.Size(143, 21);
            this.DdlEquippedWeapon.TabIndex = 7;
            this.DdlEquippedWeapon.SelectedIndexChanged += new System.EventHandler(this.DdlEquippedWeapon_SelectedIndexChanged);
            // 
            // BtnAttack1
            // 
            this.BtnAttack1.Location = new System.Drawing.Point(6, 46);
            this.BtnAttack1.Name = "BtnAttack1";
            this.BtnAttack1.Size = new System.Drawing.Size(77, 23);
            this.BtnAttack1.TabIndex = 0;
            this.BtnAttack1.Text = "BtnAttack1";
            this.BtnAttack1.UseVisualStyleBackColor = true;
            this.BtnAttack1.Click += new System.EventHandler(this.BtnAttack1_Click);
            // 
            // GrpSavingThrows
            // 
            this.GrpSavingThrows.Controls.Add(this.CbStatCheck);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowStr);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowCha);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowWis);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowInt);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowCon);
            this.GrpSavingThrows.Controls.Add(this.BtnSavingThrowDex);
            this.GrpSavingThrows.Location = new System.Drawing.Point(3, 49);
            this.GrpSavingThrows.Name = "GrpSavingThrows";
            this.GrpSavingThrows.Size = new System.Drawing.Size(155, 91);
            this.GrpSavingThrows.TabIndex = 12;
            this.GrpSavingThrows.TabStop = false;
            this.GrpSavingThrows.Text = "Saving Throws";
            // 
            // CbStatCheck
            // 
            this.CbStatCheck.AutoSize = true;
            this.CbStatCheck.Location = new System.Drawing.Point(26, 71);
            this.CbStatCheck.Name = "CbStatCheck";
            this.CbStatCheck.Size = new System.Drawing.Size(103, 17);
            this.CbStatCheck.TabIndex = 6;
            this.CbStatCheck.Text = "Stat Check Only";
            this.CbStatCheck.UseVisualStyleBackColor = true;
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
            // GrpSkills
            // 
            this.GrpSkills.Controls.Add(this.DdlSkills);
            this.GrpSkills.Controls.Add(this.BtnSkillRoll);
            this.GrpSkills.Location = new System.Drawing.Point(3, 146);
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
            this.GrpInitiative.Size = new System.Drawing.Size(155, 91);
            this.GrpInitiative.TabIndex = 14;
            this.GrpInitiative.TabStop = false;
            this.GrpInitiative.Text = "Initiative";
            // 
            // CbTopmost
            // 
            this.CbTopmost.AutoSize = true;
            this.CbTopmost.Location = new System.Drawing.Point(304, 0);
            this.CbTopmost.Name = "CbTopmost";
            this.CbTopmost.Size = new System.Drawing.Size(15, 14);
            this.CbTopmost.TabIndex = 15;
            this.CbTopmost.UseVisualStyleBackColor = true;
            this.CbTopmost.CheckedChanged += new System.EventHandler(this.CbTopmost_CheckedChanged);
            // 
            // LblTopmost
            // 
            this.LblTopmost.AutoSize = true;
            this.LblTopmost.Location = new System.Drawing.Point(231, 0);
            this.LblTopmost.Name = "LblTopmost";
            this.LblTopmost.Size = new System.Drawing.Size(73, 13);
            this.LblTopmost.TabIndex = 16;
            this.LblTopmost.Text = "Always on top";
            // 
            // CbGmOnly
            // 
            this.CbGmOnly.AutoSize = true;
            this.CbGmOnly.Location = new System.Drawing.Point(304, 505);
            this.CbGmOnly.Name = "CbGmOnly";
            this.CbGmOnly.Size = new System.Drawing.Size(15, 14);
            this.CbGmOnly.TabIndex = 17;
            this.CbGmOnly.UseVisualStyleBackColor = true;
            this.CbGmOnly.CheckedChanged += new System.EventHandler(this.CbGmOnly_CheckedChanged);
            // 
            // GrpClassOptions1
            // 
            this.GrpClassOptions1.Controls.Add(this.CbRage);
            this.GrpClassOptions1.Location = new System.Drawing.Point(3, 232);
            this.GrpClassOptions1.Name = "GrpClassOptions1";
            this.GrpClassOptions1.Size = new System.Drawing.Size(155, 79);
            this.GrpClassOptions1.TabIndex = 18;
            this.GrpClassOptions1.TabStop = false;
            this.GrpClassOptions1.Text = "Class Options";
            // 
            // CbRage
            // 
            this.CbRage.AutoSize = true;
            this.CbRage.Location = new System.Drawing.Point(8, 20);
            this.CbRage.Name = "CbRage";
            this.CbRage.Size = new System.Drawing.Size(52, 17);
            this.CbRage.TabIndex = 0;
            this.CbRage.Text = "Rage";
            this.CbRage.UseVisualStyleBackColor = true;
            // 
            // LblGmOnly
            // 
            this.LblGmOnly.AutoSize = true;
            this.LblGmOnly.Location = new System.Drawing.Point(218, 505);
            this.LblGmOnly.Name = "LblGmOnly";
            this.LblGmOnly.Size = new System.Drawing.Size(86, 13);
            this.LblGmOnly.TabIndex = 19;
            this.LblGmOnly.Text = "Send to GM only";
            // 
            // GrpCustom
            // 
            this.GrpCustom.Controls.Add(this.label7);
            this.GrpCustom.Controls.Add(this.TxtBonus4);
            this.GrpCustom.Controls.Add(this.label8);
            this.GrpCustom.Controls.Add(this.TxtDieSides4);
            this.GrpCustom.Controls.Add(this.TxtNumberOfDice4);
            this.GrpCustom.Controls.Add(this.BtnRollCustom4);
            this.GrpCustom.Controls.Add(this.TxtDescription4);
            this.GrpCustom.Controls.Add(this.label5);
            this.GrpCustom.Controls.Add(this.TxtBonus3);
            this.GrpCustom.Controls.Add(this.label6);
            this.GrpCustom.Controls.Add(this.TxtDieSides3);
            this.GrpCustom.Controls.Add(this.TxtNumberOfDice3);
            this.GrpCustom.Controls.Add(this.BtnRollCustom3);
            this.GrpCustom.Controls.Add(this.TxtDescription3);
            this.GrpCustom.Controls.Add(this.label3);
            this.GrpCustom.Controls.Add(this.TxtBonus2);
            this.GrpCustom.Controls.Add(this.label4);
            this.GrpCustom.Controls.Add(this.TxtDieSides2);
            this.GrpCustom.Controls.Add(this.TxtNumberOfDice2);
            this.GrpCustom.Controls.Add(this.BtnRollCustom2);
            this.GrpCustom.Controls.Add(this.TxtDescription2);
            this.GrpCustom.Controls.Add(this.label1);
            this.GrpCustom.Controls.Add(this.TxtBonus1);
            this.GrpCustom.Controls.Add(this.label2);
            this.GrpCustom.Controls.Add(this.TxtDieSides1);
            this.GrpCustom.Controls.Add(this.TxtNumberOfDice1);
            this.GrpCustom.Controls.Add(this.BtnRollCustom1);
            this.GrpCustom.Controls.Add(this.TxtDescription1);
            this.GrpCustom.Controls.Add(this.LblPlus);
            this.GrpCustom.Controls.Add(this.TxtBonus0);
            this.GrpCustom.Controls.Add(this.LblD);
            this.GrpCustom.Controls.Add(this.TxtDieSides0);
            this.GrpCustom.Controls.Add(this.TxtNumberOfDice0);
            this.GrpCustom.Controls.Add(this.BtnRollCustom0);
            this.GrpCustom.Controls.Add(this.TxtDescription0);
            this.GrpCustom.Controls.Add(this.LblBonus);
            this.GrpCustom.Controls.Add(this.LblDice);
            this.GrpCustom.Controls.Add(this.LblDescription);
            this.GrpCustom.Location = new System.Drawing.Point(3, 317);
            this.GrpCustom.Name = "GrpCustom";
            this.GrpCustom.Size = new System.Drawing.Size(316, 164);
            this.GrpCustom.TabIndex = 20;
            this.GrpCustom.TabStop = false;
            this.GrpCustom.Text = "Custom Rolls";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "+";
            // 
            // TxtBonus4
            // 
            this.TxtBonus4.Location = new System.Drawing.Point(231, 137);
            this.TxtBonus4.Name = "TxtBonus4";
            this.TxtBonus4.Size = new System.Drawing.Size(29, 20);
            this.TxtBonus4.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "D";
            // 
            // TxtDieSides4
            // 
            this.TxtDieSides4.Location = new System.Drawing.Point(190, 137);
            this.TxtDieSides4.Name = "TxtDieSides4";
            this.TxtDieSides4.Size = new System.Drawing.Size(24, 20);
            this.TxtDieSides4.TabIndex = 34;
            // 
            // TxtNumberOfDice4
            // 
            this.TxtNumberOfDice4.Location = new System.Drawing.Point(148, 137);
            this.TxtNumberOfDice4.Name = "TxtNumberOfDice4";
            this.TxtNumberOfDice4.Size = new System.Drawing.Size(24, 20);
            this.TxtNumberOfDice4.TabIndex = 33;
            // 
            // BtnRollCustom4
            // 
            this.BtnRollCustom4.Location = new System.Drawing.Point(277, 137);
            this.BtnRollCustom4.Name = "BtnRollCustom4";
            this.BtnRollCustom4.Size = new System.Drawing.Size(33, 20);
            this.BtnRollCustom4.TabIndex = 32;
            this.BtnRollCustom4.Text = "Roll";
            this.BtnRollCustom4.UseVisualStyleBackColor = true;
            this.BtnRollCustom4.Click += new System.EventHandler(this.BtnRollCustom4_Click);
            // 
            // TxtDescription4
            // 
            this.TxtDescription4.Location = new System.Drawing.Point(12, 137);
            this.TxtDescription4.Name = "TxtDescription4";
            this.TxtDescription4.Size = new System.Drawing.Size(126, 20);
            this.TxtDescription4.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "+";
            // 
            // TxtBonus3
            // 
            this.TxtBonus3.Location = new System.Drawing.Point(231, 111);
            this.TxtBonus3.Name = "TxtBonus3";
            this.TxtBonus3.Size = new System.Drawing.Size(29, 20);
            this.TxtBonus3.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "D";
            // 
            // TxtDieSides3
            // 
            this.TxtDieSides3.Location = new System.Drawing.Point(190, 111);
            this.TxtDieSides3.Name = "TxtDieSides3";
            this.TxtDieSides3.Size = new System.Drawing.Size(24, 20);
            this.TxtDieSides3.TabIndex = 27;
            // 
            // TxtNumberOfDice3
            // 
            this.TxtNumberOfDice3.Location = new System.Drawing.Point(148, 111);
            this.TxtNumberOfDice3.Name = "TxtNumberOfDice3";
            this.TxtNumberOfDice3.Size = new System.Drawing.Size(24, 20);
            this.TxtNumberOfDice3.TabIndex = 26;
            // 
            // BtnRollCustom3
            // 
            this.BtnRollCustom3.Location = new System.Drawing.Point(277, 111);
            this.BtnRollCustom3.Name = "BtnRollCustom3";
            this.BtnRollCustom3.Size = new System.Drawing.Size(33, 20);
            this.BtnRollCustom3.TabIndex = 25;
            this.BtnRollCustom3.Text = "Roll";
            this.BtnRollCustom3.UseVisualStyleBackColor = true;
            this.BtnRollCustom3.Click += new System.EventHandler(this.BtnRollCustom3_Click);
            // 
            // TxtDescription3
            // 
            this.TxtDescription3.Location = new System.Drawing.Point(12, 111);
            this.TxtDescription3.Name = "TxtDescription3";
            this.TxtDescription3.Size = new System.Drawing.Size(126, 20);
            this.TxtDescription3.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "+";
            // 
            // TxtBonus2
            // 
            this.TxtBonus2.Location = new System.Drawing.Point(231, 85);
            this.TxtBonus2.Name = "TxtBonus2";
            this.TxtBonus2.Size = new System.Drawing.Size(29, 20);
            this.TxtBonus2.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "D";
            // 
            // TxtDieSides2
            // 
            this.TxtDieSides2.Location = new System.Drawing.Point(190, 85);
            this.TxtDieSides2.Name = "TxtDieSides2";
            this.TxtDieSides2.Size = new System.Drawing.Size(24, 20);
            this.TxtDieSides2.TabIndex = 20;
            // 
            // TxtNumberOfDice2
            // 
            this.TxtNumberOfDice2.Location = new System.Drawing.Point(148, 85);
            this.TxtNumberOfDice2.Name = "TxtNumberOfDice2";
            this.TxtNumberOfDice2.Size = new System.Drawing.Size(24, 20);
            this.TxtNumberOfDice2.TabIndex = 19;
            // 
            // BtnRollCustom2
            // 
            this.BtnRollCustom2.Location = new System.Drawing.Point(277, 85);
            this.BtnRollCustom2.Name = "BtnRollCustom2";
            this.BtnRollCustom2.Size = new System.Drawing.Size(33, 20);
            this.BtnRollCustom2.TabIndex = 18;
            this.BtnRollCustom2.Text = "Roll";
            this.BtnRollCustom2.UseVisualStyleBackColor = true;
            this.BtnRollCustom2.Click += new System.EventHandler(this.BtnRollCustom2_Click);
            // 
            // TxtDescription2
            // 
            this.TxtDescription2.Location = new System.Drawing.Point(12, 85);
            this.TxtDescription2.Name = "TxtDescription2";
            this.TxtDescription2.Size = new System.Drawing.Size(126, 20);
            this.TxtDescription2.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "+";
            // 
            // TxtBonus1
            // 
            this.TxtBonus1.Location = new System.Drawing.Point(231, 59);
            this.TxtBonus1.Name = "TxtBonus1";
            this.TxtBonus1.Size = new System.Drawing.Size(29, 20);
            this.TxtBonus1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "D";
            // 
            // TxtDieSides1
            // 
            this.TxtDieSides1.Location = new System.Drawing.Point(190, 59);
            this.TxtDieSides1.Name = "TxtDieSides1";
            this.TxtDieSides1.Size = new System.Drawing.Size(24, 20);
            this.TxtDieSides1.TabIndex = 13;
            // 
            // TxtNumberOfDice1
            // 
            this.TxtNumberOfDice1.Location = new System.Drawing.Point(148, 59);
            this.TxtNumberOfDice1.Name = "TxtNumberOfDice1";
            this.TxtNumberOfDice1.Size = new System.Drawing.Size(24, 20);
            this.TxtNumberOfDice1.TabIndex = 12;
            // 
            // BtnRollCustom1
            // 
            this.BtnRollCustom1.Location = new System.Drawing.Point(277, 59);
            this.BtnRollCustom1.Name = "BtnRollCustom1";
            this.BtnRollCustom1.Size = new System.Drawing.Size(33, 20);
            this.BtnRollCustom1.TabIndex = 11;
            this.BtnRollCustom1.Text = "Roll";
            this.BtnRollCustom1.UseVisualStyleBackColor = true;
            this.BtnRollCustom1.Click += new System.EventHandler(this.BtnRollCustom1_Click_1);
            // 
            // TxtDescription1
            // 
            this.TxtDescription1.Location = new System.Drawing.Point(12, 59);
            this.TxtDescription1.Name = "TxtDescription1";
            this.TxtDescription1.Size = new System.Drawing.Size(126, 20);
            this.TxtDescription1.TabIndex = 10;
            // 
            // LblPlus
            // 
            this.LblPlus.AutoSize = true;
            this.LblPlus.Location = new System.Drawing.Point(215, 35);
            this.LblPlus.Name = "LblPlus";
            this.LblPlus.Size = new System.Drawing.Size(13, 13);
            this.LblPlus.TabIndex = 9;
            this.LblPlus.Text = "+";
            // 
            // TxtBonus0
            // 
            this.TxtBonus0.Location = new System.Drawing.Point(231, 33);
            this.TxtBonus0.Name = "TxtBonus0";
            this.TxtBonus0.Size = new System.Drawing.Size(29, 20);
            this.TxtBonus0.TabIndex = 8;
            // 
            // LblD
            // 
            this.LblD.AutoSize = true;
            this.LblD.Location = new System.Drawing.Point(173, 36);
            this.LblD.Name = "LblD";
            this.LblD.Size = new System.Drawing.Size(15, 13);
            this.LblD.TabIndex = 7;
            this.LblD.Text = "D";
            // 
            // TxtDieSides0
            // 
            this.TxtDieSides0.Location = new System.Drawing.Point(190, 33);
            this.TxtDieSides0.Name = "TxtDieSides0";
            this.TxtDieSides0.Size = new System.Drawing.Size(24, 20);
            this.TxtDieSides0.TabIndex = 6;
            // 
            // TxtNumberOfDice0
            // 
            this.TxtNumberOfDice0.Location = new System.Drawing.Point(148, 33);
            this.TxtNumberOfDice0.Name = "TxtNumberOfDice0";
            this.TxtNumberOfDice0.Size = new System.Drawing.Size(24, 20);
            this.TxtNumberOfDice0.TabIndex = 5;
            // 
            // BtnRollCustom0
            // 
            this.BtnRollCustom0.Location = new System.Drawing.Point(277, 33);
            this.BtnRollCustom0.Name = "BtnRollCustom0";
            this.BtnRollCustom0.Size = new System.Drawing.Size(33, 20);
            this.BtnRollCustom0.TabIndex = 4;
            this.BtnRollCustom0.Text = "Roll";
            this.BtnRollCustom0.UseVisualStyleBackColor = true;
            this.BtnRollCustom0.Click += new System.EventHandler(this.BtnRollCustom0_Click);
            // 
            // TxtDescription0
            // 
            this.TxtDescription0.Location = new System.Drawing.Point(12, 33);
            this.TxtDescription0.Name = "TxtDescription0";
            this.TxtDescription0.Size = new System.Drawing.Size(126, 20);
            this.TxtDescription0.TabIndex = 3;
            // 
            // LblBonus
            // 
            this.LblBonus.AutoSize = true;
            this.LblBonus.Location = new System.Drawing.Point(228, 16);
            this.LblBonus.Name = "LblBonus";
            this.LblBonus.Size = new System.Drawing.Size(37, 13);
            this.LblBonus.TabIndex = 2;
            this.LblBonus.Text = "Bonus";
            // 
            // LblDice
            // 
            this.LblDice.AutoSize = true;
            this.LblDice.Location = new System.Drawing.Point(167, 16);
            this.LblDice.Name = "LblDice";
            this.LblDice.Size = new System.Drawing.Size(29, 13);
            this.LblDice.TabIndex = 1;
            this.LblDice.Text = "Dice";
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Location = new System.Drawing.Point(9, 16);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(60, 13);
            this.LblDescription.TabIndex = 0;
            this.LblDescription.Text = "Description";
            // 
            // GrpSpells
            // 
            this.GrpSpells.Controls.Add(this.BtnSpell);
            this.GrpSpells.Controls.Add(this.DdlSpells);
            this.GrpSpells.Location = new System.Drawing.Point(164, 232);
            this.GrpSpells.Name = "GrpSpells";
            this.GrpSpells.Size = new System.Drawing.Size(155, 79);
            this.GrpSpells.TabIndex = 19;
            this.GrpSpells.TabStop = false;
            this.GrpSpells.Text = "Spells";
            // 
            // BtnSpell
            // 
            this.BtnSpell.Location = new System.Drawing.Point(9, 47);
            this.BtnSpell.Name = "BtnSpell";
            this.BtnSpell.Size = new System.Drawing.Size(140, 23);
            this.BtnSpell.TabIndex = 1;
            this.BtnSpell.Text = "Copy Spell Details";
            this.BtnSpell.UseVisualStyleBackColor = true;
            this.BtnSpell.Click += new System.EventHandler(this.BtnSpell_Click);
            // 
            // DdlSpells
            // 
            this.DdlSpells.FormattingEnabled = true;
            this.DdlSpells.Location = new System.Drawing.Point(9, 20);
            this.DdlSpells.Name = "DdlSpells";
            this.DdlSpells.Size = new System.Drawing.Size(140, 21);
            this.DdlSpells.TabIndex = 0;
            // 
            // RbAdvantage
            // 
            this.RbAdvantage.Location = new System.Drawing.Point(2, 20);
            this.RbAdvantage.Name = "RbAdvantage";
            this.RbAdvantage.Size = new System.Drawing.Size(106, 23);
            this.RbAdvantage.TabIndex = 21;
            this.RbAdvantage.Text = "Advantage";
            this.RbAdvantage.UseVisualStyleBackColor = true;
            this.RbAdvantage.Click += new System.EventHandler(this.RbAdvantage_Click);
            // 
            // RbNormal
            // 
            this.RbNormal.Location = new System.Drawing.Point(108, 20);
            this.RbNormal.Name = "RbNormal";
            this.RbNormal.Size = new System.Drawing.Size(106, 23);
            this.RbNormal.TabIndex = 22;
            this.RbNormal.Text = "Normal";
            this.RbNormal.UseVisualStyleBackColor = true;
            this.RbNormal.Click += new System.EventHandler(this.RbNormal_Click);
            // 
            // RbDisadvantage
            // 
            this.RbDisadvantage.Location = new System.Drawing.Point(214, 20);
            this.RbDisadvantage.Name = "RbDisadvantage";
            this.RbDisadvantage.Size = new System.Drawing.Size(105, 23);
            this.RbDisadvantage.TabIndex = 23;
            this.RbDisadvantage.Text = "Disadvantage";
            this.RbDisadvantage.UseVisualStyleBackColor = true;
            this.RbDisadvantage.Click += new System.EventHandler(this.RbDisadvantage_Click);
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 521);
            this.Controls.Add(this.RbDisadvantage);
            this.Controls.Add(this.RbNormal);
            this.Controls.Add(this.RbAdvantage);
            this.Controls.Add(this.GrpSpells);
            this.Controls.Add(this.GrpCustom);
            this.Controls.Add(this.LblGmOnly);
            this.Controls.Add(this.GrpClassOptions1);
            this.Controls.Add(this.CbGmOnly);
            this.Controls.Add(this.LblTopmost);
            this.Controls.Add(this.CbTopmost);
            this.Controls.Add(this.GrpInitiative);
            this.Controls.Add(this.GrpSkills);
            this.Controls.Add(this.GrpAttacks);
            this.Controls.Add(this.GrpSavingThrows);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.LblCharacterName);
            this.Name = "CharacterForm";
            this.Text = "characterName - Roll20Roller";
            this.TopMost = true;
            this.GrpAttacks.ResumeLayout(false);
            this.GrpAttacks.PerformLayout();
            this.GrpSavingThrows.ResumeLayout(false);
            this.GrpSavingThrows.PerformLayout();
            this.GrpSkills.ResumeLayout(false);
            this.GrpInitiative.ResumeLayout(false);
            this.GrpInitiative.PerformLayout();
            this.GrpClassOptions1.ResumeLayout(false);
            this.GrpClassOptions1.PerformLayout();
            this.GrpCustom.ResumeLayout(false);
            this.GrpCustom.PerformLayout();
            this.GrpSpells.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblCharacterName;
        private System.Windows.Forms.ComboBox DdlSkills;
        private System.Windows.Forms.Button BtnSkillRoll;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnInitiative;
        private System.Windows.Forms.Label LblSelectToken;
        private System.Windows.Forms.GroupBox GrpAttacks;
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
        private System.Windows.Forms.ComboBox DdlEquippedWeapon;
        private System.Windows.Forms.Label LblVersatile;
        private System.Windows.Forms.CheckBox CbVersatile;
        private System.Windows.Forms.CheckBox CbGmOnly;
        private System.Windows.Forms.GroupBox GrpClassOptions1;
        private System.Windows.Forms.CheckBox CbRage;
        private System.Windows.Forms.CheckBox CbStatCheck;
        private System.Windows.Forms.Label LblGmOnly;
        private System.Windows.Forms.GroupBox GrpCustom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtBonus4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtDieSides4;
        private System.Windows.Forms.TextBox TxtNumberOfDice4;
        private System.Windows.Forms.Button BtnRollCustom4;
        private System.Windows.Forms.TextBox TxtDescription4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBonus3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDieSides3;
        private System.Windows.Forms.TextBox TxtNumberOfDice3;
        private System.Windows.Forms.Button BtnRollCustom3;
        private System.Windows.Forms.TextBox TxtDescription3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtBonus2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDieSides2;
        private System.Windows.Forms.TextBox TxtNumberOfDice2;
        private System.Windows.Forms.Button BtnRollCustom2;
        private System.Windows.Forms.TextBox TxtDescription2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBonus1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDieSides1;
        private System.Windows.Forms.TextBox TxtNumberOfDice1;
        private System.Windows.Forms.Button BtnRollCustom1;
        private System.Windows.Forms.TextBox TxtDescription1;
        private System.Windows.Forms.Label LblPlus;
        private System.Windows.Forms.TextBox TxtBonus0;
        private System.Windows.Forms.Label LblD;
        private System.Windows.Forms.TextBox TxtDieSides0;
        private System.Windows.Forms.TextBox TxtNumberOfDice0;
        private System.Windows.Forms.Button BtnRollCustom0;
        private System.Windows.Forms.TextBox TxtDescription0;
        private System.Windows.Forms.Label LblBonus;
        private System.Windows.Forms.Label LblDice;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.GroupBox GrpSpells;
        private System.Windows.Forms.Button BtnSpell;
        private System.Windows.Forms.ComboBox DdlSpells;
        private System.Windows.Forms.Button RbAdvantage;
        private System.Windows.Forms.Button RbNormal;
        private System.Windows.Forms.Button RbDisadvantage;
    }
}