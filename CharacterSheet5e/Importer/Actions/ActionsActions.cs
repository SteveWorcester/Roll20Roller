using CharacterSheet5e.Importer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet5e.Importer.Actions
{
    public class ActionsActions : ActionsObjects
    {
        #region Navigation

        public ActionsActions Actions()
        {
            _navActionsTab.Click();
            return this;
        }
        public ActionsActions Attack()
        {
            Actions()._subnavAttacksTab.Click();
            return this;
        }

        #endregion

        public List<string> AllAttackNames()
        {
            var names = new List<string>();
            foreach (var element in Attack()._allAttackNames)
            {
                names.Add(element.Text);
            }

            return names;
        }

        public int GetToHitBonus(string attackName)
        {
            var isPositive = Attack()._attackHitBonusPlusMinus(attackName).Text.Equals("+");
            var canParse = int.TryParse(Attack()._attackToHitBonus(attackName).Text, out var bonus);
            if (!canParse)
            {
                throw new InvalidCastException("Cannot parse the to-hit bonus of the listed ability");
            }

            return isPositive 
                ? bonus 
                : -bonus;
        }

        // public string GenerateToHitRoll(string attackName, bool hasAdvantage = false, bool hasDisadvantage = false)
        // {
        //     var toHitDie = 20;
        //     var rolledDice = 
        //     var toHitBonus = GetToHitBonus(attackName);
        //     return $"/roll {"
        // }
        // 
        // public string GenerateDamageRoll(string attackName)
        // {
        // 
        // }
    }
}
