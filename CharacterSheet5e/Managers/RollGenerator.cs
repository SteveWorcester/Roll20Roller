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
            _MainPage = new MainPageActions(charId);
            _Actions = new ActionsActions(charId);
        }

        public SkillsActions _Skills;
        public MainPageActions _MainPage;
        public ActionsActions _Actions;

        private int AmountOfRolledDice = 1;
        private int SelectedDieSides = 20;
        private int RolledDiceToDrop = 0;
        private int SelectedSkillBonus = 0;
        private bool dropLowest = false;
        private bool dropHighest = false;

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
            var template9 = $"{AmountOfRolledDice}d{SelectedDieSides}";
            var templateDropLowest = $"dl{RolledDiceToDrop}";
            var templateDropHighest = $"dh{RolledDiceToDrop}";
            var template11 = $"+{SelectedSkillBonus}]]";
            var template12 = "}}";

            string roll =
                _rollTemplate
                + template1
                + template2
                + template3
                + template4                
                + template5
                + template6
                + template7
                + template8
                + template9;

            if (dropHighest && dropLowest)
            {
                throw new Exception("cannot drop both the highest and lowest dice in one roll");
            }
            else if (!dropHighest && !dropLowest)
            {
                //NOP
            }
            else if (dropHighest || dropLowest)
            {
                roll += dropLowest
                    ? templateDropLowest
                    : templateDropHighest;
            }
            roll += template11 + template12;

            Clipboard.SetText(roll);
        }

        public void RollInitiative(Advantage adv)
        {
            SetSkillAdvantageDice(adv);
            var initiativeBonus = _MainPage.GetInitiativeBonus();

            var _rollTemplate = "&{template:default}";
            var template1 = "{{name=Initiative}} ";
            var template2 = "{{Advantage=";
            var template3 = $"{adv}";
            var template4 = "}} ";
            var template5 = "{{Roll=[[";
            var template6 = $"{AmountOfRolledDice}d{SelectedDieSides}";
            var templateDropLowest = $"dl{RolledDiceToDrop}";
            var templateDropHighest = $"dh{RolledDiceToDrop}";
            var template8 = $"+{initiativeBonus}";
            var template9 = "&{tracker:*}]]}}";

            string roll =
                _rollTemplate
                + template1
                + template2
                + template3
                + template4
                + template5
                + template6;

            if (dropHighest && dropLowest)
            {
                throw new Exception("cannot drop both the highest and lowest dice in one roll");
            }
            else if (!dropHighest && !dropLowest)
            {
                //NOP
            }
            else if (dropHighest || dropLowest)
            {
                roll += dropLowest
                    ? templateDropLowest
                    : templateDropHighest;
            }
            roll += template8 + template9;

            Clipboard.SetText(roll);
        }

        public void RollAttack(Advantage adv, string attackName)
        {
            // to hit
            SetSkillAdvantageDice(adv);
            var toHitBonus = _Actions.GetToHitBonus(attackName);

            // damage
            var damageRoll = _Actions.GetBaseAttackRoll(attackName);
            var damageType = _Actions.GetDamageType(attackName);

            // template
            var _rollTemplate = "&{template:default} ";
            var template1 = "{{name=";
            var template2 = $"{attackName} Attack";
            var template3 = "}} ";
            var template4 = "{{advantage=";
            var template5 = $"{adv}";
            var template6 = "}} ";
            var template7 = "{{ToHit=[[";
            var template8 = $"{AmountOfRolledDice}d{SelectedDieSides}";
            var templateDropLowest = $"dl{RolledDiceToDrop}";
            var templateDropHighest = $"dh{RolledDiceToDrop}";
            var template9 = $"+{toHitBonus}]]";
            var template10 = "}}";
            var template11 = "{{Damage=[[";
            var template12 = $"{damageRoll}]]";
            var template13 = "}} ";
            var template14 = "{{DamageType=";
            var template15 = $"{damageType}";
            var template16 = "}} ";

            string roll =
                _rollTemplate
                + template1
                + template2
                + template3
                + template4
                + template5
                + template6
                + template7
                +template8;

            if (dropHighest && dropLowest)
            {
                throw new Exception("cannot drop both the highest and lowest dice in one roll");
            }
            else if (!dropHighest && !dropLowest)
            {
                //NOP
            }
            else if (dropHighest || dropLowest)
            {
                roll += dropLowest
                    ? templateDropLowest
                    : templateDropHighest;
            }
            roll += template9 
                + template10
                + template11
                + template12
                + template13
                + template14
                + template15
                + template16;

            Clipboard.SetText(roll);
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
                    dropHighest = true;
                    break;
                case Advantage.Normal:
                    AmountOfRolledDice = 1;
                    RolledDiceToDrop = 0;
                    dropLowest = false;
                    dropHighest = false;
                    break;
                case Advantage.Advantage:
                    AmountOfRolledDice = 2;
                    RolledDiceToDrop = 1;
                    dropLowest = true;
                    dropHighest = false;                    
                    break;
                default:
                    throw new Exception("Advantage radio button not selected");
            }
        }


    }
}
