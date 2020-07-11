﻿using CharacterSheet5e.Importer.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace CharacterSheet5e.Importer.Maps
{
    public class MainPageObjects : ScraperBase
    {
        protected IWebElement _characterName => _Driver.WaitForElement(By.CssSelector(".ddbc-character-tidbits__heading > div:nth-child(1)"));
    }
}
