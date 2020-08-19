﻿using Roll20Roller.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Managers
{
    public class SpellsManager
    {
        public string MainClassSpellsFilePath;
        public string OffClassSpellsFilePath;

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

        public void SetSpellFilePaths(List<(CharacterClass charClass, int charLevel)> allClassesAndLevels)
        {
            MainClassSpellsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SpellCsv", $"Spells_{allClassesAndLevels.First().charClass}.csv");

            OffClassSpellsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SpellCsv", $"Spells_{allClassesAndLevels.Last().charClass}.csv");
        }
    }
}