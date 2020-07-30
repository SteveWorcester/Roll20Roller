using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using OpenQA.Selenium.Chrome;

namespace Roll20Roller.Importer.Base
{
    public class ScraperBase
    {
        public ScraperBase()
        {
            options = new ChromeOptions();
            options.AddArguments(new List<string>() { "Headless", "--window-size=1920,1080" });
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
        }

        private static ChromeOptions options;
        private static ChromeDriverService service;
        private static readonly Lazy<ChromeDriver> _driver = new Lazy<ChromeDriver>(() => new ChromeDriver(service, options));
        public ChromeDriver _Driver
        {
            get
            {
                return _driver.Value;
            }
        }

        public string ScrapeUrl { get; set; }
        public DirectoryInfo SaveDataDirectory { get; set; }

        public void SetCharacterAndPullData(long charId)
        {
            SetCharacterInfo(charId);
            _Driver.Url = ScrapeUrl;
        }

        private void SetCharacterInfo(long charId)
        {
            ScrapeUrl = Path.Combine(
                ConfigurationManager.AppSettings["BaseUrl"],
                charId.ToString(),
                ConfigurationManager.AppSettings["XmlOnly"]);            
        }
    }
}
