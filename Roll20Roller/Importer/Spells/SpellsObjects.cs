using OpenQA.Selenium;
using Roll20Roller.Importer.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Importer.Spells
{
    public class SpellsObjects : SpellsBase
    {
        #region Index Class #1

        protected IWebElement _IndexParent => _SpellsIndexDriver.WaitForElement(By.XPath("/html/body/div[2]/form/table/tbody"));
        protected IReadOnlyCollection<IWebElement> _IndexAllNames => _IndexParent.FindElements(By.XPath("./tr/td[1]"));
        protected IWebElement _IndexName(string spellName) => _IndexAllNames.First(n => n.Text.ToLower().Equals(spellName.ToLower()));
        protected IWebElement _SpellSchool(string spellName) => _IndexName(spellName).FindElement(By.XPath("./following-sibling::td"));
        protected IWebElement _SpellLevel(string spellName) => _SpellSchool(spellName).FindElement(By.XPath("./following-sibling::td"));
        protected IWebElement _SpellIsRitual(string spellName) => _SpellLevel(spellName).FindElement(By.XPath("./following-sibling::td"));
        protected IWebElement _SpellIsConcentration(string spellName) => _SpellIsRitual(spellName).FindElement(By.XPath("./following-sibling::td"));
        protected IWebElement _SpellClasses(string spellName) => _SpellIsConcentration(spellName).FindElement(By.XPath("./following-sibling::td"));

        #endregion

        #region Cards

        protected IWebElement _CardsParent => _SpellCardsDriver.WaitForElement(By.XPath("/html/body/div[4]/div[3]"));
        protected IWebElement _McCardsParent => _MulticlassSpellCardsDriver.WaitForElement(By.XPath("/html/body/div[4]/div[3]"));
        protected IReadOnlyCollection<IWebElement> _CardsAllNames(bool multiClass = false) => multiClass 
            ? _McCardsParent.FindElements(By.XPath("./div/div/div/h3"))
            : _CardsParent.FindElements(By.XPath("./div/div/div/h3"));
        protected IWebElement _CardsName(string spellName, bool multiClass) => _CardsAllNames(multiClass).First(n => n.Text.ToLower().Contains(spellName.ToLower()));
        protected IWebElement _SpellTime(string spellName, bool multiClass) => _CardsName(spellName, multiClass).FindElement(By.XPath("./following-sibling::ul/li[1]"));
        protected IWebElement _SpellRange(string spellName, bool multiClass) => _CardsName(spellName, multiClass).FindElement(By.XPath("./following-sibling::ul/li[2]"));
        protected IWebElement _SpellComponents(string spellName, bool multiClass) => _CardsName(spellName, multiClass).FindElement(By.XPath("./following-sibling::ul[2]/li[1]"));
        protected IWebElement _SpellDuration(string spellName, bool multiClass) => _CardsName(spellName, multiClass).FindElement(By.XPath("./following-sibling::ul[2]/li[2]"));
        protected IWebElement _SpellDescription(string spellName, bool multiClass) => _CardsName(spellName, multiClass).FindElement(By.XPath("./following-sibling::p"));

        #endregion
    }
}
