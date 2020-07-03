using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterSheet5e.Enums;
using IronWebScraper;

namespace CharacterSheet5e.Importer.Base
{
    public class ScraperBase : WebScraper
    {
        public string ScrapeUrl { get; set; }
        public DirectoryInfo SaveDataDirectory { get; set; }
        public string CharacterLabel { get; set; }

        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request(ScrapeUrl, Parse);
        }
        public override void Parse(Response response)
        {
            this.WorkingDirectory = SaveDataDirectory.FullName;
            foreach (var title_link in response.Css("h2.entry - title a"))
            {
                string strTitle = title_link.TextContentClean;                
                Scrape(new ScrapedData() { { CharacterLabel, strTitle } });
            }
            if (response.CssExists("div.prev-post > a[href]"))
            {
                var next_page = response.Css("div.prev-post > a[href]")[0].Attributes["href"];
                this.Request(next_page, Parse);
            }
        }

        public void SetCharacterInfo(CharacterName charName)
        {
            ScrapeUrl = Path.Combine(ConfigurationManager.AppSettings["BaseUrl"], ConfigurationManager.AppSettings[charName.ToString()]);
            SaveDataDirectory = Directory.CreateDirectory(ConfigurationManager.AppSettings["SaveDataLocation"]);
            CharacterLabel = $"{charName.ToString()}CharacterInfo";
        }
    }
}
