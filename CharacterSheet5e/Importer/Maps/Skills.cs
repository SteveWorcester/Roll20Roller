using CharacterSheet5e.Enums;
using CharacterSheet5e.Importer.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet5e.Importer.Maps
{
    public class Skills : ScraperBase
    {
        public Skills(CharacterName charName)
        {
            SetCharacterAndPullData(charName);
            _nbl = GetNamesBonusesList();
        }

        public Skills(long charId)
        {
            SetCharacterAndPullData(charId);
            _nbl = GetNamesBonusesList();
        }

        private string baseAbilitiesXpath = "//div[@class='ct-skills__list']/div";
        private string abilityNamesXpathExtension = "/div[@class='ct-skills__col--skill']";
        private string abilityBonusesXpathExtension = "/div[@class='ct-skills__col--modifier']/span/span[@class='ddbc-signed-number__number']";
        private string abilityPlusMinusXpathExtension = "/div[@class = 'ct-skills__col--modifier']/span/span[@class='ddbc-signed-number__sign']";

        private List<string> AbilityNamesList = new List<string>();
        private List<bool> PlusMinusList = new List<bool>();
        private List<int> BonusesList = new List<int>();

        private List<Tuple<string, int>> _nbl;
        public List<Tuple<string, int>> NamesBonusesList
        { 
            get
            {
                if (_nbl.Count <= 0)
                {
                    _nbl = GetNamesBonusesList();
                }
                return _nbl;
            } 
        }

        public List<Tuple<string, int>> GetNamesBonusesList()
        {
            ResetAbilityLists();
            var namesBonusesList = new List<Tuple<string, int>>();
            for (int i = 0; i < AbilityNamesList.Count ; i++)
            {
                NamesBonusesList
                    .Add(new Tuple<string, int>(
                    AbilityNamesList[i], 
                    PlusMinusList[i] 
                    ? BonusesList[i] 
                    : -BonusesList[i]));
            }
            return namesBonusesList;
        }

        private void ResetAbilityLists()
        {
            AbilityNamesList.Clear();
            PlusMinusList.Clear();
            BonusesList.Clear();

            var names = _Driver.FindElementsByXPath(baseAbilitiesXpath + abilityNamesXpathExtension).ToList();
            names.ForEach(e => AbilityNamesList.Add(e.Text));

            var plusMinus = _Driver.FindElementsByXPath(baseAbilitiesXpath + abilityPlusMinusXpathExtension).ToList();
            plusMinus.ForEach(e => PlusMinusList.Add(e.Text.Equals("+") ? true : false));

            var bonuses = _Driver.FindElementsByXPath(baseAbilitiesXpath + abilityBonusesXpathExtension).ToList();
            bonuses.ForEach(e => BonusesList.Add(int.Parse(e.Text)));
        }
    }
}
