using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using CharacterSheet5e.Enums;
using OpenQA.Selenium.Chrome;

namespace CharacterSheet5e.Importer.Base
{
    public class ScraperBase
    {
        public ScraperBase()
        {

        }

        public string ScrapeUrl { get; set; }
        public DirectoryInfo SaveDataDirectory { get; set; }
        public string CharacterLabel { get; set; }
        public CharacterName CharName { get; set; }
        private ChromeOptions options = new ChromeOptions();
        private ChromeDriverService service = ChromeDriverService.CreateDefaultService();
        private static readonly Lazy<ChromeDriver> _driver = new Lazy<ChromeDriver>(() => new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriverLocation"]));

        public ChromeDriver _Driver
        {
            get
            {
                return _driver.Value;
            }
        }

        public void SetCharacter(CharacterName charName)
        {
            SetCharacterInfo(charName);
            _Driver.Url = ScrapeUrl;
        }

        private void SetCharacterInfo(CharacterName charName)
        {
            ScrapeUrl = Path.Combine(
                ConfigurationManager.AppSettings["BaseUrl"], 
                ConfigurationManager.AppSettings[charName.ToString()], 
                ConfigurationManager.AppSettings["XmlOnly"]);

            SaveDataDirectory = Directory.CreateDirectory(ConfigurationManager.AppSettings["SaveDataLocation"]);
            CharacterLabel = $"{charName.ToString()}CharacterInfo";
        }
    }
}
