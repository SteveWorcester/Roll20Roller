using CharacterSheet5e.Enums;
using CharacterSheet5e.Forms;
using CharacterSheet5e.Importer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSheet5e
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());

            // This will need to get moved to the import button on StartForm
            var scraper = new ScraperBase();
            scraper.SetCharacterInfo(CharacterName.Cloron);
            scraper.Start();
        }
    }
}
