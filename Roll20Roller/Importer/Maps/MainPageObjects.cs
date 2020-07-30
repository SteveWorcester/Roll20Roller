using Roll20Roller.Importer.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Roll20Roller.Importer.Maps
{
    public class MainPageObjects : ScraperBase
    {
        protected IWebElement _characterName => _Driver.WaitForElement(By.CssSelector(".ddbc-character-tidbits__heading > div:nth-child(1)"));
        protected IWebElement _initiativePlusMinus => _Driver.WaitForElement(By.CssSelector("span.ddbc-signed-number:nth-child(2) > span:nth-child(1)"));
        protected IWebElement _initiativeBonus => _Driver.WaitForElement(By.CssSelector("span.ddbc-signed-number:nth-child(2) > span:nth-child(2)"));
    }
}
