using CharacterSheet5e.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet5e.Importer.Base
{
    public class TemplateFactory
    {
        private int AmountOfRolledDice = 1;
        private int SelectedDieSides = 20;
        private int RolledDiceToDrop = 0;
        private bool dropLowest = false;
        private bool dropHighest = false;

        protected string TemplateStartDefaultTemplate(string title)=> "&{template:default}" + TemplateGenerateRow("name", title);
        protected string TemplateGenerateRow(string descriptor, string result)
        {
            var template = "{{";
            template += $"{descriptor}={result}";
            template += "}} ";
            return template;
        }

        protected string TemplateGenerateD20HiddenRoll(
            Advantage adv,
            int bonus,
            bool addToTurnTracker = false,
            string descriptor = "Roll")
        {
            SetSkillAdvantageDice(adv);

            var template = "{{";
            template += $"{descriptor}=[[";
            template += $"{AmountOfRolledDice}d{SelectedDieSides}";

            if (dropHighest && dropLowest)
            {
                throw new Exception("cannot drop both the highest and lowest dice in one roll");
            }
            else if (!dropHighest && !dropLowest)
            {
                //NOP - Normal does not drop dice
            }
            else if (dropHighest || dropLowest)
            {
                template += dropLowest
                    ? $"dl{RolledDiceToDrop}"
                    : $"dh{RolledDiceToDrop}";
            }

            template += $"+{bonus}";

            if (addToTurnTracker)
            {
                template += "&{tracker:*}";
            }

            template += "]]}}";

            return template;
        }

        protected string TemplateGenerateRowWithHiddenRollText(string descriptor, string fullDamageRoll)
        {
            var template = "{{";
            template += $"{descriptor}=[[";
            template += $"{fullDamageRoll}]]";
            template += "}} ";

            return template;
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
