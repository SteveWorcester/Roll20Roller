using Roll20Roller.Enums;
using Roll20Roller.Importer.Base;
using Roll20Roller.Importer.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        #region Class-Specific Options

        public void SetupClassOptions(GroupBox classOptionsGroupBox, string className1, string className2)
        {
            var canParsePrimary = Enum.TryParse(className1, out CharacterClass primaryClass);
            var canParseSecondary = Enum.TryParse(className2, out CharacterClass secondaryClass);
            
            if (!canParsePrimary && !canParseSecondary)
            {
                classOptionsGroupBox.Enabled = false;
            }

            var controls = classOptionsGroupBox.Controls;
            var classOptionsCheckBoxes = new List<CheckBox>();
            foreach (Control ctrl in controls)
            {
                if (ctrl is CheckBox)
                {
                    ctrl.Enabled = false;
                    classOptionsCheckBoxes.Add((CheckBox)ctrl);
                }
            }

            ActivateOptionsForClass(primaryClass, classOptionsCheckBoxes);

            var hasSecondaryClass = !primaryClass.Equals(secondaryClass);            
            if (hasSecondaryClass)
            {
                ActivateOptionsForClass(secondaryClass, classOptionsCheckBoxes);
            }
        }

        public int GetRageBonus()
        {
            var canParse = int.TryParse(_rageBonus.Text, out var bonus);
            if (!canParse)
            {
                throw new Exception("Cannot parse rage bonus");
            }
            return bonus;
        }
        
        private void ActivateOptionsForClass(CharacterClass characterClass, List<CheckBox> classOptionsCheckBoxes)
        {
            switch (characterClass)
            {
                case CharacterClass.None:
                    break;
                case CharacterClass.Barbarian:
                    classOptionsCheckBoxes.First(cb => cb.Text.Equals("Rage")).Enabled = true;
                    break;
                case CharacterClass.Bard:
                    break;
                case CharacterClass.Cleric:
                    break;
                case CharacterClass.Druid:
                    break;
                case CharacterClass.Fighter:
                    break;
                case CharacterClass.Monk:
                    break;
                case CharacterClass.Paladin:
                    break;
                case CharacterClass.Ranger:
                    break;
                case CharacterClass.Rogue:
                    break;
                case CharacterClass.Sorcerer:
                    break;
                case CharacterClass.Warlock:
                    break;
                case CharacterClass.Wizard:
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
