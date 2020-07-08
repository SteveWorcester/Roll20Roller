using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using CharacterSheet5e.Enums;
using HtmlAgilityPack;
using System.Runtime.InteropServices;
using System.Xml;

namespace CharacterSheet5e.Importer.Base
{
    public class ScraperBase
    {
        public string ScrapeUrl { get; set; }
        public DirectoryInfo SaveDataDirectory { get; set; }
        public string CharacterLabel { get; set; }

        public void Scrape(CharacterName charName)
        {
            SetCharacterInfo(charName);

            var stream = new MemoryStream();
            var xmlWriter = new XmlTextWriter(stream, Encoding.UTF8);

            var web = new HtmlWeb();
            web.LoadHtmlAsXml(ScrapeUrl, xmlWriter);





            // name
            var characterName = xmlWriter;//.DocumentNode.SelectSingleNode("//div[@class='ddbc-character-name ']").InnerText;

            // reference
            // var characterTidbits = doc.DocumentNode.SelectSingleNode("//div[@class='item-inner']/span[@class='title']");

            //var first = characterTidbits.First();
            //var last = characterTidbits.Last();
        }

        public void SetCharacterInfo(CharacterName charName)
        {
            ScrapeUrl = Path.Combine(ConfigurationManager.AppSettings["BaseUrl"], ConfigurationManager.AppSettings[charName.ToString()], ConfigurationManager.AppSettings["XmlOnly"]);
            SaveDataDirectory = Directory.CreateDirectory(ConfigurationManager.AppSettings["SaveDataLocation"]);
            CharacterLabel = $"{charName.ToString()}CharacterInfo";
        }
    }
}
