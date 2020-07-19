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
    public class ActionsObjects : ScraperBase
    {
        // Research on mapping Flex Containers necessary before use. The Full tab-selection section is a flex container.
        protected IWebElement _tabsWindow => _Driver.WaitForElement(By.CssSelector("div.ct-subsection:nth-child(6)"));
        protected IWebElement _navActionsTab => _tabsWindow.FindElement(By.XPath("/div[contains(text(), 'ct-primary-box__tab--actions ddbc-tab-list__nav-item']"));

        #region Attack

        protected IWebElement _subnavAttacksTab => _Driver.WaitForElement(By.CssSelector(".ddbc-tab-options__header-heading--is-active"));
        protected IWebElement _baseAttacksParent => _Driver.WaitForElement(By.CssSelector(".ddbc-attack-table__content"));
        protected ReadOnlyCollection<IWebElement> _allAttackNames => _baseAttacksParent.FindElements(By.XPath("./div/div[@class='ddbc-combat-attack__name']/span[contains(@class,'ddbc-item-name ddbc-item-name--rarity-')]"));
        protected IWebElement _attackParent(string attackName) => _allAttackNames.FirstOrDefault(n => n.Text.Equals(attackName)).FindElement(By.XPath(".//parent::div[contains(@class,'ddbc-combat-attack--item ddbc-combat-item-attack--')]"));
        protected IWebElement _attackName(string attackName) => _allAttackNames.FirstOrDefault(n => n.Text.Equals(attackName)); 
        protected IWebElement _attackDamageRoll(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-damage__value']"));
        protected IWebElement _attackToHitBonus(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-signed-number__number']"));
        protected IWebElement _attackHitBonusPlusMinus(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-signed-number__sign'"));
        
        #endregion
    }
}
