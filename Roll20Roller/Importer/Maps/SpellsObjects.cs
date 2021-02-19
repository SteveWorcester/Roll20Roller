using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Roll20Roller.Importer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Importer.Maps
{
    public class SpellsObjects : ScraperBase
    {
        // navigation buttons
        protected IWebElement BtnSpellsTabButtonPreClick => _Driver.WaitForElement(By.CssSelector(".ct-primary-box__tab--spells"), 45000);
        protected IWebElement BtnSpellsTabButtonPostClick => _Driver.WaitForElement(By.CssSelector("div.ct-primary-box__tab--spells:nth-child(2)"), 45000);

        // basic content
        private IWebElement _basicSpellsParent => _Driver.WaitForElement(By.CssSelector(".ddbc-tab-options__content"));
        protected IReadOnlyCollection<IWebElement> SpellsByLevel(uint level) => _basicSpellsParent.FindElements(By.XPath($"./div[{level+1}]/div[2]/div/div[2]/div")); // +1 because xpath is 1 indexed
        protected IReadOnlyCollection<IWebElement> AllSpellNames => _basicSpellsParent.FindElements(By.XPath("./div/div[2]/div/div[2]/div/div[2]/div[1]/span"));
        protected IWebElement SpellLineParentByName(string spellName) => AllSpellNames.FirstOrDefault(n => n.Text.Contains(spellName)).FindElement(By.XPath("./parent::div/parent::div/parent::div"));

        // detailed content
        private IWebElement _detailedSpellsParent => _Driver.WaitForElement(By.CssSelector(".ct-spell-detail"));
        protected IWebElement SelectedSpellClass => _detailedSpellsParent.FindElement(By.XPath("./parent::div/div[1]/div[1]"));
        protected IWebElement SelectedSpellName => _detailedSpellsParent.FindElement(By.XPath("./parent::div/div[1]/div[2]/div[2]/span"));
        protected IWebElement SelectedSpellSchool => _detailedSpellsParent.FindElement(By.XPath("./div[1]/span[2]"));
        protected IWebElement SelectedSpellLevel => _detailedSpellsParent.FindElement(By.XPath("./div[1]/span[1]"));
        protected IWebElement SelectedSpellCastingTime => _detailedSpellsParent.FindElement(By.XPath("./div[4]/div[1]/div[2]"));
        protected IWebElement SelectedSpellRangeArea => _detailedSpellsParent.FindElement(By.XPath("./div[4]/div[2]/div[2]/span"));
        protected IReadOnlyCollection<IWebElement> SelectedSpellComponentTypes => _detailedSpellsParent.FindElements(By.XPath("./div[4]/div[3]/div[2]/span[1]/span"));
        protected IWebElement SelectedSpellComponentMaterials => _detailedSpellsParent.FindElement(By.XPath("./div[4]/div[3]/div[2]/span[2]/span"));
        protected IWebElement SelectedSpellDuration => _detailedSpellsParent.FindElement(By.XPath("./div[4]/div[4]/div[2]"));
        protected IReadOnlyCollection<IWebElement> SelectedSpellShortDescriptions => _detailedSpellsParent.FindElements(By.XPath("./div[2]/div[2]/div[1]/span"));
        protected IWebElement SelectedSpellDetail => _detailedSpellsParent.FindElement(By.XPath("./div[5]/p[1]"));
        protected IWebElement SelectedSpellDetailHigherLevels => _detailedSpellsParent.FindElement(By.XPath("./div[5]/p[2]"));
    }
}

                // CastingTime = ,
                // Class = ,
                // Components = ,
                // Description = ,
                // Duration = ,
                // Level = ,
                // Name = ,
                // Range = ,
                // School =
