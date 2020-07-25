using CharacterSheet5e.Importer.Base;
using CharacterSheet5e.Importer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet5e.Importer.Actions
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
    }
}
