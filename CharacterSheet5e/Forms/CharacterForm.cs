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

            RbNormal.Select();
        }

        private void DdlSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSkillName = DdlSkills.SelectedItem.ToString();
        }

        private void BtnSkillRoll_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollSkill(selectedAdvantage, SelectedSkillName);          
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
            var chrome = Process.GetProcessesByName("chromeDriver.exe").ToList();
            var cons = Process.GetProcessesByName("Console Window Host").ToList();
            chrome.ForEach(c => c.Kill());
            cons.ForEach(c => c.Kill());
        }

        private void BtnInitiative_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollInitiative(selectedAdvantage);
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
    }
}
