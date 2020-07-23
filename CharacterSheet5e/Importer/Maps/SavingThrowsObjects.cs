using CharacterSheet5e.Importer.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet5e.Importer.Maps
{
    public class SavingThrowsObjects : ScraperBase
    {
        protected IWebElement _savingThrowsParent => _Driver.WaitForElement(By.CssSelector(".ddbc-saving-throws-summary"));
        protected ReadOnlyCollection<IWebElement> _savingThrowNames => _savingThrowsParent.FindElements(By.XPath("//div[@class='ddbc-saving-throws-summary__ability-name']"));
        protected IWebElement _savingThrowName(string savingThrow) => _savingThrowNames.First(n => n.Text.Equals(savingThrow));
        protected IWebElement _savingThrowPlusMinus(string savingThrow) => _savingThrowName(savingThrow).FindElement(By.XPath("..//span[@class='ddbc-signed-number__sign']"));
        protected IWebElement _savingThrowBonus(string savingThrow) => _savingThrowName(savingThrow).FindElement(By.XPath("..//span[@class='ddbc-signed-number__number']"));
    }
}
