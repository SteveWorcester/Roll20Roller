using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using Roll20Roller.Enums;
using Roll20Roller.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;

using System.Threading.Tasks;


namespace Roll20Roller.Importer.Base
{
    public class SpellsBase
    {
        public SpellsBase()
        {
            options = new ChromeOptions();
            options.AddArguments(new List<string>() { "Headless", "--window-size=1920,1080" });
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
        }

        public static List<CharacterClass> SpellcastingClasses = new List<CharacterClass>()
        {
            CharacterClass.Paladin,
            CharacterClass.Wizard,
            CharacterClass.Sorcerer,
            CharacterClass.Ranger,
            CharacterClass.Warlock,
            CharacterClass.Bard,
            CharacterClass.Druid,
            CharacterClass.Cleric
        };

        private static ChromeOptions options;
        private static ChromeDriverService service;
        private static readonly Lazy<ChromeDriver> _spellsIndexDriver = new Lazy<ChromeDriver>(() => new ChromeDriver(service, options));
        public ChromeDriver _SpellsIndexDriver
        {
            get
            {
                return _spellsIndexDriver.Value;
            }
        }

        private static readonly Lazy<ChromeDriver> _spellCardsDriver = new Lazy<ChromeDriver>(() => new ChromeDriver(service, options));
        public ChromeDriver _SpellCardsDriver
        {
            get
            {
                return _spellCardsDriver.Value;
            }
        }

        public static ChromeDriver _MulticlassSpellCardsDriver;

        public void SetSpellEndpoints(CharacterClass characterClass1, CharacterClass characterClass2 = CharacterClass.None)
        {
            _SpellsIndexDriver.Url = ConfigurationManager.AppSettings["SpellsIndex"];
            if (SpellcastingClasses.Contains(characterClass1))
            {                
                _SpellCardsDriver.Url = Path.Combine(ConfigurationManager.AppSettings["SpellCards"], characterClass1.ToString(), "//");
            }
            if (SpellcastingClasses.Contains(characterClass2))
            {
                _MulticlassSpellCardsDriver = new ChromeDriver(service, options);
                _MulticlassSpellCardsDriver.Url = Path.Combine(ConfigurationManager.AppSettings["SpellCards"], characterClass2.ToString(), "//");
            }
        }
    }
}
