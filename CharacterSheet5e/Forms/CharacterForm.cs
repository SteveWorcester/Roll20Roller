using CharacterSheet5e.Importer.Actions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CharacterSheet5e.Forms
{
    public partial class CharacterForm : Form
    {
        public SkillsActions _Skills;
        public MainPageActions _MainPage;


        public IList<string> AllSkillNames { get; set; }


        public string SelectedSkillName;
        public int SelectedSkillBonus;
        public int SelectedDieSides;
        public int AmountOfRolledDice;
        public int RolledDiceToDrop;

        public CharacterForm(long charId)
        {
            InitializeComponent();
            _Skills = new SkillsActions(charId);
            _MainPage = new MainPageActions(charId);

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
            SelectedSkillBonus = _Skills.GetSkillBonusByName(DdlSkills.SelectedItem.ToString());
        }

        private void BtnSkillRoll_Click(object sender, EventArgs e)
        {
            SelectedDieSides = 20; // All skills use a d20

            if (RbAdvantage.Checked)
            {
                AmountOfRolledDice = 2;
                RolledDiceToDrop = 1;
                Clipboard.SetText($"/roll {AmountOfRolledDice}d{SelectedDieSides}dl{RolledDiceToDrop}+{SelectedSkillBonus}");
            }
            else if (RbNormal.Checked)
            {
                AmountOfRolledDice = 1;
                RolledDiceToDrop = 0;
                Clipboard.SetText($"/roll {AmountOfRolledDice}d{SelectedDieSides}dl{RolledDiceToDrop}+{SelectedSkillBonus}");
            }
            else if (RbDisadvantage.Checked)
            {
                AmountOfRolledDice = 2;
                RolledDiceToDrop = 1;
                Clipboard.SetText($"/roll {AmountOfRolledDice}d{SelectedDieSides}dh{RolledDiceToDrop}+{SelectedSkillBonus}");
            }            
        }
    }
}
