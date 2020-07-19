using CharacterSheet5e.Enums;
using CharacterSheet5e.Importer.Actions;
using CharacterSheet5e.Managers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CharacterSheet5e.Forms
{
    public partial class CharacterForm : Form
    {
        public SkillsActions _Skills;
        public MainPageActions _MainPage;
        public RollGenerator _Roll;

        public IList<string> AllSkillNames { get; set; }

        public string SelectedSkillName;
        private Advantage selectedAdvantage;

        public CharacterForm(long charId)
        {
            InitializeComponent();
            _MainPage = new MainPageActions(charId);
            _Skills = new SkillsActions(charId);
            _Roll = new RollGenerator(charId);

            LblCharacterName.Text = _MainPage.GetCharacterName();

            #region DdlSkills

            var bindingSource1 = new BindingSource();
            AllSkillNames = _Skills.GetAllSkillNames();
            bindingSource1.DataSource = AllSkillNames;
            DdlSkills.ValueMember = "Name";
            DdlSkills.DisplayMember = "Name";
            DdlSkills.DataSource = bindingSource1.DataSource;

            #endregion
        }

        private void DdlSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSkillName = DdlSkills.SelectedItem.ToString();
        }

        private void BtnSkillRoll_Click(object sender, EventArgs e)
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

            _Roll.RollSkill(selectedAdvantage, SelectedSkillName);          
        }
    }
}
