using CharacterSheet5e.Importer.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CharacterSheet5e.Importer.Maps
{
    public class SkillsObjects : ScraperBase
    {
        protected IWebElement _baseSkillsParent => _Driver.WaitForElement(By.CssSelector(".ct-skills__list"));
        protected ReadOnlyCollection<IWebElement> _allSkills => _baseSkillsParent.FindElements(By.XPath("./div")); // Note: Final skill is the "Additional Skills" label, not a skill
        protected ReadOnlyCollection<IWebElement> _allSkillNames => _baseSkillsParent.FindElements(By.XPath(".//div[@class='ct-skills__col--skill']"));
        protected IWebElement _skillName(string abilityName) => _allSkillNames.FirstOrDefault(n => n.Text.Equals(abilityName));
        protected IWebElement _skillPlusMinus(string abilityName) => _skillName(abilityName).FindElement(By.XPath(".//following-sibling::div[@class='ct-skills__col--modifier']/span/span[1]"));
        protected IWebElement _skillBonus(string abilityName) => _skillPlusMinus(abilityName).FindElement(By.XPath(".//following-sibling::span"));
    }
}
