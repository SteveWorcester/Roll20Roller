using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet5e.Importer.Base
{
    public static class Wait
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeoutInMs = 30000)
        {
            return new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMs)).Until((drv) => {
                try
                {
                    var ele = drv.FindElement(by);
                    return ele.Displayed ? ele : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NotFoundException)
                {
                    return null;
                }
            });
        }
    }
}
