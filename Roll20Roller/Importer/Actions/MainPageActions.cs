using Roll20Roller.Enums;
using Roll20Roller.Importer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<(CharacterClass charClass, int charLevel)> GetClassNamesAndLevels()
        {
            var finalList = new List<(CharacterClass charClass, int charLevel)>();

            var thingtest = _classNames.Text.ToCharArray();
            var classes = _classNames.Text.Split('/').ToList();

            var classList = new List<string>();
            classes.ForEach(c => classList.Add(c.Trim().Remove(c.Length-2)));

            var levelList = new List<char>();
            classes.ForEach(c => levelList.Add(c.Trim().Last()));

            var finalClassList = new List<CharacterClass>();
            foreach (var segment in classList)
            {
                var canParseClass = Enum.TryParse(segment, out CharacterClass charClass);
                if (canParseClass)
                {
                    finalClassList.Add(charClass);
                }
            }

            for (int i = 0; i < finalClassList.Count; i++)
            {
                finalList.Add((finalClassList[i], int.Parse(levelList[i].ToString())));
            }

            return finalList;
        }
    }
}
