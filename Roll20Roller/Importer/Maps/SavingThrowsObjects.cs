using Roll20Roller.Importer.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Importer.Maps
{
    public class SavingThrowsObjects : ScraperBase
    {
        protected IWebElement _savingThrowsParent => _Driver.WaitForElement(By.XPath("/html/body/div[1]/div/div[3]/div/section/div/div/div[2]/div/div[3]/div[1]/div[1]/div[2]/div"));
        protected ReadOnlyCollection<IWebElement> _savingThrowNames => _savingThrowsParent.FindElements(By.XPath("./div/div[@class='ddbc-saving-throws-summary__ability-name']"));
        protected IWebElement _savingThrowName(string savingThrow) => _savingThrowNames.First(n => n.Text.Equals(savingThrow));
        protected IWebElement _savingThrowPlusMinus(string savingThrow) => _savingThrowName(savingThrow).FindElement(By.XPath("./parent::div//span[@class='ddbc-signed-number__sign']"));
        protected IWebElement _savingThrowBonus(string savingThrow) => _savingThrowName(savingThrow).FindElement(By.XPath("./parent::div//span[@class='ddbc-signed-number__number']"));
    }
}
