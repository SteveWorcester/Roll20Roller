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
    public class ActionsObjects : ScraperBase
    {
        #region Navigation

        protected IWebElement BtnActionsTabPreClick => _Driver.WaitForElement(By.CssSelector(".ct-primary-box__tab--actions"));
        protected IWebElement BtnActionTabPostClick => _Driver.WaitForElement(By.CssSelector("div.ddbc-tab-list__nav-item:nth-child(1)"));

        #endregion

        #region Attack

        protected IWebElement _baseAttacksParent => _Driver.WaitForElement(By.CssSelector(".ddbc-attack-table__content"));
        protected ReadOnlyCollection<IWebElement> _allAttackRows => _Driver.FindElements(By.XPath("//div/div/div[2]/div/div[1]/div[2]/div[1]/div[2]/div"));
        protected ReadOnlyCollection<IWebElement> _allAttackNames => _baseAttacksParent.FindElements(By.XPath("//div/div/div[2]/div/div[1]/div[2]/div[1]/div[2]/div/div[2]/div[1]/span"));        
        protected IWebElement _attackName(string attackName) => _allAttackNames.FirstOrDefault(n => n.Text.Equals(attackName));
        protected IWebElement _attackParent(string attackName) => _attackName(attackName).FindElement(By.XPath("./parent::div[1]/parent::div[1]/parent::div[1]"));
        protected IWebElement _attackDamageRoll(string attackName)
        {
            try
            {
                return _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-damage__value']"));
            }
            catch (NoSuchElementException)
            {
                return _attackParent(attackName).FindElement(By.XPath("./div[@class='ddbc-combat-attack__damage']"));
            }            
        }
        protected IWebElement _attackToHitBonus(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-signed-number__number']"));
        protected IWebElement _attackSaveDc(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-combat-attack__save-value']"));
        protected IWebElement _attackSaveDcStat(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-combat-attack__save-label']"));
        protected IWebElement _attackHitBonusPlusMinus(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-signed-number__sign']"));
        protected IWebElement _attackDamageRollVersatile(string attackName)
        {
            try
            {
                return _attackDamageRoll(attackName).FindElement(By.XPath("./parent::span/following-sibling::span/span"));
            }
            catch (NoSuchElementException)
            {
                return _attackDamageRoll(attackName);
            }            
        }

        /// <summary>
        /// Attack Damage Type is in the "data-original-title" inner text.
        /// </summary>
        /// <param name="attackName"></param>
        /// <returns></returns>
        protected IWebElement _attackDamageType(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-tooltip  ddbc-damage']"));

        protected IWebElement _spellAttackDamageType(string attackName) => _attackParent(attackName).FindElement(By.CssSelector(".ddbc-spell-damage-effect__damages > span:nth-child(2) > span:nth-child(1) > span:nth-child(1)"));

        #endregion

        #region Bonus Actions

        protected IWebElement _bonusActionsSubtab => _Driver.WaitForElement(By.CssSelector("div.ddbc-tab-options__header:nth-child(4) > div:nth-child(1)"));

        protected IWebElement _bonusActionsParent => _Driver.WaitForElement(By.CssSelector("div.ct-actions-list:nth-child(2)"));
        protected ReadOnlyCollection<IWebElement> _allBonusActionNames => _bonusActionsParent.FindElements(By.XPath("./div[@class='ct-actions-list__content']/div/div/div[@class='ct-feature-snippet__heading']"));
        protected IWebElement _bonusActionName(string bonusActionName) => _allBonusActionNames.First(n => n.Text.Equals(bonusActionName));     
        protected IWebElement _rageBonus => _bonusActionName("Rage").FindElement(By.XPath("//span[@class='ddbc-snippet__tag']"));

        #endregion

        protected bool IsActionsTabSelected()
        {
            try
            {
                var element = BtnActionsTabPreClick.Text;
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

        public bool AttackHasSaveDc(string attackName)
        {
            try
            {
                var element = _attackSaveDcStat(attackName).Text;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool AttackHasDamageType(string attackName)
        {
            try
            {
                var element = _attackDamageType(attackName).Text;
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
