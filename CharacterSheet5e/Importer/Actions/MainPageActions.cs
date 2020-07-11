using CharacterSheet5e.Importer.Maps;
using System;
using System.Collections.Generic;

namespace CharacterSheet5e.Importer.Actions
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
    }
}
