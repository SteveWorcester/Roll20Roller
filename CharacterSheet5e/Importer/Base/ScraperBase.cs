using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using OpenQA.Selenium.Chrome;

namespace CharacterSheet5e.Importer.Base
{
    public class ScraperBase
    {
        public ScraperBase()
        {
            // Set flexible default chrome driver install path before sharing.
            // ConfigurationManager.AppSettings.Add(new KeyValuePair<string, string>("DefaultChromeDriverInstallLocation", Path...FindIt));
            
            options = new ChromeOptions();
            options.AddArguments(new List<string>() { "Headless" });
            service = ChromeDriverService.CreateDefaultService();
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
