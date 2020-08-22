using Roll20Roller.Importer.Base;
using Roll20Roller.Importer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Importer.Actions
{
    public class SavingThrowsActions : SavingThrowsObjects
    {
        public SavingThrowsActions(long charId)
        {
            SetCharacterAndPullData(charId);
        }

        public List<string> GetAllSavingThrowNames()
        {
            var savingThrowNames = new List<string>();
            foreach (var name in _savingThrowNames)
            {
                savingThrowNames.Add(name.Text);
            }
            return savingThrowNames;
        }

        public int GetSavingThrowBonus(string savingThrow)
        {
            var canParse = int.TryParse(_savingThrowBonus(savingThrow).Text, out var parsedBonus);
            if (!canParse)
            {
                throw new Exception("Cannot parse saving throw bonus");
            }
            return _savingThrowPlusMinus(savingThrow).Text.Equals("+") ? parsedBonus : -parsedBonus;
        }

        public int GetStatCheckBonus(string statName)
        {
            var canParse = int.TryParse(_statCheckBonus(statName).Text, out var parsedBonus);
            if (!canParse)
            {
                throw new Exception("Cannot parse saving throw bonus");
            }
            return _statCheckPlusMinus(statName).Text.Equals("+") ? parsedBonus : -parsedBonus;
        }

        public int GetProficiencyBonus()
        {
            var canParse = int.TryParse(_proficiencyBonus.Text, out var profBonus);
            if (!canParse)
            {
                throw new Exception("Cannot parse proficiency bonus");
            }
            return _proficiencyPlusMinus.Text.Equals("+") ? profBonus : -profBonus;
        }
    }
}
