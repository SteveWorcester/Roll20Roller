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
        protected IWebElement BtnSpellsTabButtonPreClick => _Driver.WaitForElement(By.CssSelector(".ct-primary-box__tab--spells"), 45000);
        protected IWebElement BtnSpellsTabButtonPostClick => _Driver.WaitForElement(By.CssSelector("div.ct-primary-box__tab--spells:nth-child(2)"), 45000);

        private IWebElement _baseSpellsParent => _Driver.WaitForElement(By.CssSelector(".ddbc-tab-options__content"));
        protected IReadOnlyCollection<IWebElement> SpellsByLevel(uint level) => _baseSpellsParent.FindElements(By.XPath($"./div[{level+1}]/div[2]/div/div[2]/div")); // +1 because xpath is 1 indexed
        protected IReadOnlyCollection<IWebElement> AllSpellNames => _baseSpellsParent.FindElements(By.XPath("./div/div[2]/div/div[2]/div/div[2]/div[1]/span"));
    }
}
