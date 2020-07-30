using Roll20Roller.Importer.Base;
using Roll20Roller.Importer.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roll20Roller.Importer.Actions
{
    public class ActionsActions : ActionsObjects
    {
        public ActionsActions(long charId)
        {
            SetCharacterAndPullData(charId);
        }

        #region Attack

        public List<string> AllAttackNames()
        {
            var names = new List<string>();
            foreach (var element in _allAttackNames)
            {
                names.Add(element.Text);
            }

            return names;
        }

        /// <summary>
        /// Base attack roll ex: 2d20
        /// </summary>
        /// <param name="attackName"></param>
        /// <returns>The amount of dice rolled and the sides of dice ex: 2d20</returns>
        public string GetBaseAttackRoll(string attackName)
        {
            return _attackDamageRoll(attackName).Text;
        }

        public int GetToHitBonus(string attackName)
        {
            var canParse = int.TryParse(_attackToHitBonus(attackName).Text, out var bonus);
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
            return _attackHitBonusPlusMinus(attackName).Text.Equals("+");
        }

        public string GetDamageType(string attackName)
        {
            return _attackDamageType(attackName).GetAttribute("data-original-title");
        }

        public string GetVersatileAttackRoll(string attackName)
        {
            return _attackDamageRollVersatile(attackName).Text;
        }

        public bool IsAttackVersatile(string attackName)
        {
            if (_attackDamageRoll(attackName).Text.Equals(_attackDamageRollVersatile(attackName).Text))
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
