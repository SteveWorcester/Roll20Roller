using CharacterSheet5e.Enums;
using CharacterSheet5e.Importer.Actions;
using CharacterSheet5e.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace CharacterSheet5e.Forms
{
    public partial class CharacterForm : Form
    {
        public SkillsActions _Skills;
        public MainPageActions _MainPage;
        public RollGenerator _Roll;
        public ActionsActions _Actions; // Actions are not supported on the main page

        public IList<string> AllSkillNames { get; set; }

        public string SelectedSkillName = "Acrobatics";
        private Advantage selectedAdvantage;

        private string attack1Name;
        private string attack2Name;

        public CharacterForm(long charId)
        {
            InitializeComponent();
            _Roll = new RollGenerator(charId);

            #region Main Page

            _MainPage = new MainPageActions(charId);
            LblCharacterName.Text = _MainPage.GetCharacterName();

            #endregion

            #region Attacks

            _Actions = new ActionsActions(charId);
            attack1Name = _Actions.AllAttackNames().First();
            BtnAttack1.Text = attack1Name;

            if (_Actions.AllAttackNames().Count > 1)
            {
                attack2Name = _Actions.AllAttackNames()[1];
                BtnAttack2.Text = attack2Name;
            }
            else
            {
                BtnAttack2.Text = "None";
                BtnAttack2.Enabled = false;
            }

            #endregion

            #region Skills

            _Skills = new SkillsActions(charId);
            AllSkillNames = _Skills.GetAllSkillNames();
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = AllSkillNames;

            DdlSkills.ValueMember = "Name";
            DdlSkills.DisplayMember = "Name";
            DdlSkills.DataSource = bindingSource1.DataSource;

            #endregion

            #region Saving Throws

            SavingThrowsActions _SavingThrows = new SavingThrowsActions(charId);
            var savingThrowNames = _SavingThrows.GetAllSavingThrowNames();
            BtnSavingThrowStr.Text = savingThrowNames[0];
            BtnSavingThrowDex.Text = savingThrowNames[1];
            BtnSavingThrowCon.Text = savingThrowNames[2];
            BtnSavingThrowInt.Text = savingThrowNames[3];
            BtnSavingThrowWis.Text = savingThrowNames[4];
            BtnSavingThrowCha.Text = savingThrowNames[5];

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
            _Roll.RollSkill(selectedAdvantage, SelectedSkillName);          
        }

        #endregion

        #region Initiative

        private void BtnInitiative_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollInitiative(selectedAdvantage);
        }

        #endregion

        #region Attacks

        private void BtnAttack1_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollAttack(selectedAdvantage, attack1Name);
        }

        private void BtnAttack2_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollAttack(selectedAdvantage, attack2Name);
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
            _Roll.RollSavingThrow(selectedAdvantage, threeLetterAcronym);
        }

        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            _Actions._Driver.Quit();
            Environment.Exit(0);
        }

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
        }

        private void CbTopmost_CheckedChanged(object sender, EventArgs e)
        {
            if (CbTopmost.Checked)
            {
                this.TopMost = true;
            }
            else if (!CbTopmost.Checked)
            {
                this.TopMost = false;
            }
        }
    }
}
