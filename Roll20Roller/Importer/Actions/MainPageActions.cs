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
            var classname = _classNames.Text.Split('/').ToList();
            classname.ForEach(c => c.Split(' '));
            foreach (var item in classname)
            {
                var canParse = int.TryParse(item, out var level);
                if (!canParse)
                {
                    finalList.Add(item);
                }
            }

            return finalList;
        }

        public void SetupClassOptions(GroupBox classOptionsGroup)
        {
            if (classOptionsGroup.Text.Equals())
            {

            }

            var controls = classOptionsGroup.Controls;
            foreach (Control checkBox in controls)
            {
                if (checkBox is CheckBox)
                {

                }
            }
        }
    }
}
