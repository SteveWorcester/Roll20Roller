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
        // public ActionsActions _Actions;

        public IList<string> AllSkillNames { get; set; }

        public string SelectedSkillName = "Acrobatics";
        private Advantage selectedAdvantage;

        public CharacterForm(long charId)
        {
            InitializeComponent();
            _MainPage = new MainPageActions(charId);
            _Skills = new SkillsActions(charId);
            _Roll = new RollGenerator(charId);
            //_Actions = new ActionsActions(charId);
            LblCharacterName.Text = _MainPage.GetCharacterName();
            //LblWeapon1.Text = _Actions.AllAttackNames().First();

            #region DdlSkills
            
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
            var chrome = Process.GetProcessesByName("chromeDriver.exe").ToList();
            var cons = Process.GetProcessesByName("Console Window Host").ToList();
            chrome.ForEach(c => c.Kill());
            cons.ForEach(c => c.Kill());
            Environment.Exit(0);
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
    }
}
