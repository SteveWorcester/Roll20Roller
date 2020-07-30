using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Roll20Roller.Importer.Base
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

        public static IWebElement WaitForDisplayed(this IWebElement element, int waitTimeInMs = 15000)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (!element.Displayed && sw.ElapsedMilliseconds < waitTimeInMs)
            {
                Thread.Sleep(100);
            }
            sw.Stop();

            if (sw.ElapsedMilliseconds > waitTimeInMs)
            {
                throw new TimeoutException($"Waited {sw.ElapsedMilliseconds}ms, and timed out while waiting for {element} to be displayed");
            }

            return element;
        }

        public static ReadOnlyCollection<IWebElement> WaitForElements(this IWebDriver driver, By by, int timeoutInMs = 30000)
        {
            return new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMs)).Until((drv) => {
                try
                {
                    var ele = drv.FindElements(by);
                    return ele.Last().Displayed ? ele : null;
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
