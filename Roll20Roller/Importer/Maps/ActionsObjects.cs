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
        #region Attack

        protected IWebElement _baseAttacksParent => _Driver.WaitForElement(By.CssSelector(".ddbc-attack-table__content"));
        protected ReadOnlyCollection<IWebElement> _allAttackRows => _Driver.FindElements(By.XPath("/html/body/div[2]/div/div[3]/div/section/div/div/div[2]/div/div[3]/div[6]/div/div[2]/div[2]/div/div/div/div[2]/div/div[1]/div[2]/div[1]/div[2]/div[1]"));
        protected ReadOnlyCollection<IWebElement> _allAttackNames => _baseAttacksParent.FindElements(By.XPath("//div/div/div[2]/div/div[1]/div[2]/div[1]/div[2]/div/div[2]/div[1]/span"));        
        protected IWebElement _attackName(string attackName) => _allAttackNames.FirstOrDefault(n => n.Text.Equals(attackName));
        protected IWebElement _attackParent(string attackName) => FindAttackParent(attackName);
        protected IWebElement _attackDamageRoll(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-damage__value']"));
        protected IWebElement _attackToHitBonus(string attackName) => _attackParent(attackName).FindElement(By.XPath(".//span[@class='ddbc-signed-number__number']"));
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

        private IWebElement FindAttackParent(string attackName)
        {
            var parentIndex = _allAttackNames.IndexOf(_attackName(attackName));
            return _allAttackRows[parentIndex];
        }

        #endregion

        #region Bonus Actions

        protected IWebElement _bonusActionsHeader => _Driver.WaitForElement(By.XPath("/html/body/div[1]/div/div[3]/div/section/div/div/div[2]/div/div[3]/div[6]/div/div[2]/div[2]/div/div/div/div[1]/div[4]/div"));

        protected IWebElement _bonusActionsParent => _Driver.WaitForElement(By.XPath("/html/body/div[1]/div/div[3]/div/section/div/div/div[2]/div/div[3]/div[6]/div/div[2]/div[2]/div/div/div/div[2]/div/div[2]"));
        protected ReadOnlyCollection<IWebElement> _allBonusActionNames => _bonusActionsParent.FindElements(By.XPath("./div[@class='ct-actions-list__content']/div/div/div[@class='ct-feature-snippet__heading']"));
        protected IWebElement _bonusActionName(string bonusActionName) => _allBonusActionNames.First(n => n.Text.Equals(bonusActionName));     
        protected IWebElement _rageBonus => _bonusActionName("Rage").FindElement(By.XPath("//span[@class='ddbc-snippet__tag']"));

        #endregion
    }
}
