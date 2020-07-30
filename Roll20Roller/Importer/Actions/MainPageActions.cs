using Roll20Roller.Importer.Maps;
using System;
using System.Collections.Generic;

namespace Roll20Roller.Importer.Actions
{
    public class MainPageActions : MainPageObjects
    {
        public MainPageActions(long charId)
        {
            SetCharacterAndPullData(charId);
        }

        public string GetCharacterName()
        {
            return _characterName.Text;
        }

        public int GetInitiativeBonus()
        {
            var isPositive = _initiativePlusMinus.Text.Equals("+");
            var canParse = int.TryParse(_initiativeBonus.Text, out var bonus);
            if (!canParse)
            {
                throw new Exception("Initiative bonus cannot be parsed");
            }

            return isPositive ? bonus : -bonus;
        }
    }
}
