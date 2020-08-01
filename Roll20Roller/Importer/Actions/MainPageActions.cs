using Roll20Roller.Enums;
using Roll20Roller.Importer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

        public List<string> GetClassNames()
        {
            var finalList = new List<string>();
            var tempClasses = _classNames.Text.Split('/').ToList();
            var tempClassList = new List<string>();
            tempClasses.ForEach(c => tempClassList.Add(c.Remove(4))); // all class names are first 4 letters.
            foreach (var classOnly in tempClassList)
            {
                var canParse = int.TryParse(classOnly, out var level);
                if (!canParse)
                {
                    finalList.Add(classOnly);
                }
            }

            return finalList;
        }
    }
}
