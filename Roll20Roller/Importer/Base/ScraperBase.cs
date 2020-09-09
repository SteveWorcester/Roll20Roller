using System;
using System.Collections.Generic;
using System.Configuration;
using System.Deployment.Application;
using System.IO;
using System.IO.Compression;
using OpenQA.Selenium.Chrome;

namespace Roll20Roller.Importer.Base
{
    public class ScraperBase
    {
        public ScraperBase()
        {
            options = new ChromeOptions();            
            options.BinaryLocation = GetChromeBinaryLocation();
            options.AddArgument("--headless");
            options.AddArgument("--window-size=1920,1080");

            
            service = ChromeDriverService.CreateDefaultService();
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;
        }

        private string GetChromeBinaryLocation()
        {
            var isNetworkDeployed = ApplicationDeployment.IsNetworkDeployed;

            var chromeZip = isNetworkDeployed
                ? Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, "Importer", "ChromeCompressed", "ChromeZip.zip")
                : Path.Combine(Directory.GetCurrentDirectory(), "Importer", "ChromeCompressed", "ChromeZip.zip");

            var chromeDir = Directory.CreateDirectory(isNetworkDeployed
                ? Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, "ChromeBin")
                : Path.Combine(Directory.GetCurrentDirectory(), "ChromeBin"));

            if (!File.Exists(Path.Combine(chromeDir.FullName, "GoogleChromePortable", "App", "Chrome-Bin", "chrome.exe")))
            {
                ZipFile.ExtractToDirectory(chromeZip, chromeDir.FullName);
            }

            return Path.Combine(chromeDir.FullName, "GoogleChromePortable", "App", "Chrome-Bin", "chrome.exe");
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
