using CharacterSheet5e.Enums;
using CharacterSheet5e.Importer.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet5e.Importer.Maps
{
    public class Skills : ScraperBase
    {
        public Skills(CharacterName charName)
        {
            SetCharacter(charName);
        }

        public IList<IWebElement> SkillsElementsList => _Driver.FindElements(By.XPath("//div[@class='ct-skills__list']/div"));
        private List<Tuple<string, int>> _nbl = new List<Tuple<string, int>>();
        public List<Tuple<string, int>> NamesBonusesList
        { 
            get
            {
                if (_nbl.Count <= 0)
                {
                    _nbl = CreateSkillsNamesList();
                }
                return _nbl;
            } 
        }

        private List<Tuple<string, int>> CreateSkillsNamesList()
        {
            var namesBonusesList = new List<Tuple<string, int>>();
            foreach (var name in SkillsElementsList)
            {
                var skillName = name.FindElement(By.XPath("/div[@class='ct-skills__col--skill']")).Text;
                var isPositive = name.FindElement(By.XPath("/div[@class='ct-skills__col--modifier']/span/span[@class='ddbc-signed-number__sign']")).Text.Equals("+");
                var bonus = int.Parse(name.FindElement(By.XPath("/div[@class='ct-skills__col--modifier']/span/span[@class='ddbc-signed-number__number']")).Text);
                namesBonusesList.Add(isPositive ? new Tuple<string, int>(skillName, bonus) : new Tuple<string, int>(skillName, -bonus));
            }
            return namesBonusesList;
        }

    }
}
