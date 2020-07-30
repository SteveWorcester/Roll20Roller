using Roll20Roller.Importer.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Roll20Roller.Importer.Maps
{
    public class SkillsObjects : ScraperBase
    {
        protected IWebElement _baseSkillsParent => _Driver.WaitForElement(By.CssSelector(".ct-skills__list"));
        protected ReadOnlyCollection<IWebElement> _allSkillNames => _baseSkillsParent.FindElements(By.XPath(".//div[@class='ct-skills__col--skill']"));
        protected IWebElement _skillName(string skillName) => _allSkillNames.FirstOrDefault(n => n.Text.Equals(skillName));
        protected IWebElement _skillPlusMinus(string skillName) => _skillName(skillName).FindElement(By.XPath(".//following-sibling::div[@class='ct-skills__col--modifier']/span/span[1]"));
        protected IWebElement _skillBonus(string skillName) => _skillPlusMinus(skillName).FindElement(By.XPath(".//following-sibling::span"));
    }
}
