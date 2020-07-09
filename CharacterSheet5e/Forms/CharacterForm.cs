using CharacterSheet5e.Enums;
using CharacterSheet5e.Importer.Actions;
using CharacterSheet5e.Importer.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSheet5e.Forms
{
    public partial class CharacterForm : Form
    {
        public Skills _Skills;
        private List<string> _skillNames = new List<string>();
        private List<int> _skillBonuses = new List<int>();
        public string SelectedSkillName;
        public int SelectedSkillBonus;
        public int SelectedDieSides;
        public int AmountOfRolledDice;
        public int RolledDiceToDrop;



        public CharacterForm(CharacterName charName)
        {
            InitializeComponent();
            _Skills = new Skills(charName);            
            _Skills.NamesBonusesList.ForEach(n => _skillNames.Add(n.Item1));
            _Skills.NamesBonusesList.ForEach(b => _skillBonuses.Add(b.Item2));
            LblCharacterName.Text = _Skills.CharName.ToString();
            DdlSkills.DataSource = _skillNames;
        }

        private void DdlSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSkillBonus = _skillBonuses[DdlSkills.SelectedIndex];
        }

        private void BtnSkillRoll_Click(object sender, EventArgs e)
        {
            SelectedDieSides = 20;
            AmountOfRolledDice = 1; // TEMP: Will need to update when adv/disadv is added
            RolledDiceToDrop = 0;
            Clipboard.SetText($"/roll {AmountOfRolledDice}d{SelectedDieSides}dl{RolledDiceToDrop}1+{SelectedSkillBonus}");
        }
    }
}
