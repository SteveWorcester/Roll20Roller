using CharacterSheet5e.Importer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CharacterSheet5e.Importer.Actions
{
    public class ActionsActions : ActionsObjects
    {
        public ActionsActions(long charId)
        {
            SetCharacterAndPullData(charId);
        }

        #region Navigation

        public ActionsActions Actions()
        {
            _navActionsTab.Click();
            return this;
        }
        public ActionsActions Attack()
        {
            Actions()._subnavAttacksTab.Click();
            Thread.Sleep(250);
            return this;
        }

        #endregion

        #region Attack

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
            var canParse = int.TryParse(Attack()._attackToHitBonus(attackName).Text, out var bonus);
            if (!canParse)
            {
                throw new InvalidCastException("Cannot parse the to-hit bonus of the listed ability");
            }

            return IsBonusPositive(attackName)
                ? bonus 
                : -bonus;
        }

        private bool IsBonusPositive(string attackName)
        {
            return Attack()._attackHitBonusPlusMinus(attackName).Text.Equals("+");
        }

        #endregion
    }
}
