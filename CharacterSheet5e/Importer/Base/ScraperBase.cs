using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using CharacterSheet5e.Enums;
using OpenQA.Selenium;
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
            service = ChromeDriverService.CreateDefaultService(ConfigurationManager.AppSettings["ChromeDriverLocation"]);
            SaveDataDirectory = Directory.CreateDirectory(ConfigurationManager.AppSettings["SaveDataLocation"]);
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
        public string CharacterLabel { get; set; }
        public CharacterName CharName { get; set; }

        public void SetCharacterAndPullData(CharacterName charName)
        {
            SetCharacterInfo(charName);
            _Driver.Url = ScrapeUrl;
        }

        public void SetCharacterAndPullData(long charId)
        {
            SetCharacterInfo(charId);
            _Driver.Url = ScrapeUrl;
            CharacterLabel = _Driver.FindElement(By.XPath("//div[@class='ddbc-character-name ']")).Text;
        }

        private void SetCharacterInfo(CharacterName charName)
        {
            ScrapeUrl = Path.Combine(
                ConfigurationManager.AppSettings["BaseUrl"], 
                ConfigurationManager.AppSettings[charName.ToString()], 
                ConfigurationManager.AppSettings["XmlOnly"]);

            CharacterLabel = charName.ToString();
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
