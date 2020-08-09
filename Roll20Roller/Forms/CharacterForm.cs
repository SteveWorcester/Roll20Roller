﻿using Roll20Roller.Enums;
using Roll20Roller.Importer.Actions;
using Roll20Roller.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Roll20Roller.Forms
{
    public partial class CharacterForm : Form
    {
        public SkillsActions _Skills;
        public MainPageActions _MainPage;
        public RollGenerator _Roll;
        public ActionsActions _Actions;
        SavingThrowsActions _SavingThrows;

        public IList<string> AllSkillNames { get; set; }
        public string SelectedSkillName = "Acrobatics";
        
        private Advantage selectedAdvantage;
        private bool GmOnly = false;
        private string characterName = string.Empty;

        IList<string> AllAttackNames { get; set; }
        public string SelectedAttackName;

        public CharacterForm(long charId)
        {
            InitializeComponent();
            _Roll = new RollGenerator(charId);
            _MainPage = new MainPageActions(charId);
            _Actions = new ActionsActions(charId);
            _Skills = new SkillsActions(charId);
            _SavingThrows = new SavingThrowsActions(charId);

            #region Main Page

            characterName = _MainPage.GetCharacterName();            
            
            LblCharacterName.Text = characterName;
            this.Text = $"{characterName} - Roll20Roller";

            #endregion

            #region Attacks

            
            AllAttackNames = _Actions.AllAttackNames();
            BtnAttack1.Text = "Attack!";

            var attacksBindingSource = new BindingSource();
            attacksBindingSource.DataSource = AllAttackNames;

            DdlEquippedWeapon.ValueMember = "Name";
            DdlEquippedWeapon.DisplayMember = "Name";
            DdlEquippedWeapon.DataSource = attacksBindingSource.DataSource;
            SelectedAttackName = AllAttackNames.First();
            CbVersatile.Enabled = _Actions.IsAttackVersatile(SelectedAttackName) ? true : false;

            #endregion

            #region Skills

            
            AllSkillNames = _Skills.GetAllSkillNames();
            var skillsBindingSource = new BindingSource();
            skillsBindingSource.DataSource = AllSkillNames;

            DdlSkills.ValueMember = "Name";
            DdlSkills.DisplayMember = "Name";
            DdlSkills.DataSource = skillsBindingSource.DataSource;

            #endregion

            #region Saving Throws

            
            var savingThrowNames = _SavingThrows.GetAllSavingThrowNames();
            BtnSavingThrowStr.Text = savingThrowNames[0];
            BtnSavingThrowDex.Text = savingThrowNames[1];
            BtnSavingThrowCon.Text = savingThrowNames[2];
            BtnSavingThrowInt.Text = savingThrowNames[3];
            BtnSavingThrowWis.Text = savingThrowNames[4];
            BtnSavingThrowCha.Text = savingThrowNames[5];

            #endregion

            #region Class-Specific Options

            var classNames = _MainPage.GetClassNames();
            _Actions.SetupClassOptions(GrpClassOptions1, classNames.First(), classNames.Last());

            #endregion

            RbNormal.Select();
            CbTopmost.Checked = true;
        }

        #region Skills

        private void DdlSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSkillName = DdlSkills.SelectedItem.ToString();
        }

        private void BtnSkillRoll_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollSkill(selectedAdvantage, SelectedSkillName, GmOnly);          
        }

        #endregion

        #region Initiative

        private void BtnInitiative_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollInitiative(selectedAdvantage, GmOnly);
        }

        #endregion

        #region Attacks

        private void BtnAttack1_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollAttack(selectedAdvantage, SelectedAttackName, CbVersatile.Checked, GmOnly, CbRage.Checked);
        }

        private void DdlEquippedWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbVersatile.Checked = false;
            SelectedAttackName = DdlEquippedWeapon.SelectedItem.ToString();
            CbVersatile.Enabled = _Actions.IsAttackVersatile(SelectedAttackName) ? true : false;
        }

        #endregion

        #region Saving Throws

        private void BtnSavingThrowStr_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowStr.Text);
        }

        private void BtnSavingThrowDex_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowDex.Text);
        }

        private void BtnSavingThrowCon_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowCon.Text);
        }

        private void BtnSavingThrowInt_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowInt.Text);
        }

        private void BtnSavingThrowWis_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowWis.Text);
        }

        private void BtnSavingThrowCha_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowCha.Text);
        }

        private void ActivateSavingThrow(string threeLetterAcronym)
        {
            SetAdvantage();
            _Roll.RollSavingThrow(selectedAdvantage, threeLetterAcronym, GmOnly, CbRage.Checked);
        }

        #endregion

        #region Advantage

        private void SetAdvantage()
        {
            if (RbDisadvantage.Checked)
            {
                selectedAdvantage = Advantage.Disadvantage;
            }
            else if (RbNormal.Checked)
            {
                selectedAdvantage = Advantage.Normal;
            }
            else if (RbAdvantage.Checked)
            {
                selectedAdvantage = Advantage.Advantage;
            }
            SetAdvantageColors();
        }

        private void SetAdvantageColors()
        {
            var buttonList = GetAllControls(this).ToList();
            foreach (Control control in buttonList)
            {
                if (control is Button && control.Text != "Exit")
                {
                    if (selectedAdvantage.Equals(Advantage.Disadvantage))
                    {
                        control.BackColor = Color.LightPink;
                    }
                    if (selectedAdvantage.Equals(Advantage.Normal))
                    {
                        control.BackColor = Color.LightGray;
                    }
                    if (selectedAdvantage.Equals(Advantage.Advantage))
                    {
                        control.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        public IEnumerable<Control> GetAllControls(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetAllControls(child));
            }

            controls.Add(parent);

            return controls;
        }

        private void RbAdvantage_CheckedChanged(object sender, EventArgs e)
        {
            SetAdvantage();
        }

        private void RbNormal_CheckedChanged(object sender, EventArgs e)
        {
            SetAdvantage();
        }

        private void RbDisadvantage_CheckedChanged(object sender, EventArgs e)
        {
            SetAdvantage();
        }

        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            _Actions._Driver.Quit();
            Environment.Exit(0);
        }

        private void CbTopmost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = CbTopmost.Checked; 
        }

        private void CbGmOnly_CheckedChanged(object sender, EventArgs e)
        {
            GmOnly = CbGmOnly.Checked;
        }
    }
}