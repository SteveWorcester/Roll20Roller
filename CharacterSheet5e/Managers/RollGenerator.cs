using CharacterSheet5e.Enums;
using CharacterSheet5e.Importer.Actions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSheet5e.Managers
{
    public class RollGenerator
    {
        public RollGenerator(long charId)
        {
            _Skills = new SkillsActions(charId);
        }

        public SkillsActions _Skills;
        public MainPageActions _MainPage;

        private int AmountOfRolledDice = 1;
        private int SelectedDieSides = 20;
        private int RolledDiceToDrop = 0;
        private int SelectedSkillBonus = 0;
        private bool dropLowest = false;

        public void RollSkill(Advantage adv, string skillName)
        {
            SetSkillAdvantageDice(adv);
            SelectedSkillBonus = _Skills.GetSkillBonusByName(skillName);
            var _rollTemplate = "&{template:default} ";
            var template1 = "{{name=Skill Check}} ";
            var template2 = "{{skill=";
            var template3 = $"{skillName}";
            var template4 = "}} ";
            var template5 = "{{advantage=";
            var template6 = $"{adv}";
            var template7 = "}} ";
            var template8 = "{{Roll=[[";
            var template9 = $"{AmountOfRolledDice}d{SelectedDieSides}dl{RolledDiceToDrop}+{SelectedSkillBonus}]]";
            var template10 = "}}";

            Clipboard.SetText(
                _rollTemplate 
                + template1 
                + template2 
                + template3 
                + template4 
                + template5 
                + template6 
                + template7 
                + template8 
                + template9 
                + template10);
        }

        private void SetSkillAdvantageDice(Advantage adv)
        {
            SelectedDieSides = 20; // All skills use 20 sided dice
            switch (adv)
            {
                case Advantage.Disadvantage:
                    AmountOfRolledDice = 2;
                    RolledDiceToDrop = 1;
                    dropLowest = false;
                    break;
                case Advantage.Normal:
                    AmountOfRolledDice = 1;
                    RolledDiceToDrop = 0;
                    dropLowest = false;
                    break;
                case Advantage.Advantage:
                    AmountOfRolledDice = 2;
                    RolledDiceToDrop = 1;
                    dropLowest = true;
                    break;
                default:
                    throw new Exception("Advantage radio button not selected");
            }
        }
    }
}
