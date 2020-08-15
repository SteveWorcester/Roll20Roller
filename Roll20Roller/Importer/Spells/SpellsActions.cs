using Roll20Roller.Enums;
using Roll20Roller.Importer.Actions;
using Roll20Roller.Importer.Maps;
using Roll20Roller.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Importer.Spells
{
    public class SpellsActions : SpellsObjects
    {
        private List<(CharacterClass charClass, int charLevel)> _classNamesAndLevels;
        private bool multiClassed = false;
        private MainPageActions mainPage;

        public SpellsActions(long charId)
        {
            mainPage = new MainPageActions(charId);
            _classNamesAndLevels = mainPage.GetClassNamesAndLevels();
            
            if (_classNamesAndLevels.First().Item1 != _classNamesAndLevels.Last().Item1)
            {
                multiClassed = true;
            }

            if (!multiClassed)
            {
                SetSpellEndpoints(_classNamesAndLevels.First().Item1);
            }
            else if (multiClassed)
            {
                SetSpellEndpoints(_classNamesAndLevels.First().Item1, _classNamesAndLevels.Last().Item1);
            } 
        }

        public async Task WriteAvailableSpellNames(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var name in _IndexAllNames)
                {
                    var spellClassLine = _SpellClasses(name.Text).Text;
                    var canParseLevel = double.TryParse(_SpellLevel(name.Text).Text, out var spellLevel);
                    if (!canParseLevel)
                    {
                        spellLevel = 0;
                    }

                    if (spellClassLine.Contains(_classNamesAndLevels.First().Item1.ToString())
                        && spellLevel <= Math.Ceiling((double)_classNamesAndLevels.First().charLevel / 2))
                    {
                        await writer.WriteLineAsync(name.Text + '$');
                    }

                    else if (multiClassed
                        && spellClassLine.Contains(_classNamesAndLevels.Last().charClass.ToString())
                        && spellLevel <= Math.Ceiling((double)_classNamesAndLevels.Last().charLevel / 2))
                    {
                        await writer.WriteLineAsync(name.Text + '$');
                    }
                }
                writer.Close();
            }
            return;
        }

        private bool IsSecondary(CharacterClass classToCheck)
        {
            if (!multiClassed)
            {
                return false;                
            }
            return !_classNamesAndLevels.First().Equals(classToCheck);
        }

        private bool IsSecondary(string spellName)
        {
            var availableClassNames = _SpellClasses(spellName).Text.Split(',').ToList();
            
            foreach (var className in availableClassNames)
            {
                var canParseClass = Enum.TryParse(className.Trim(), out CharacterClass charClass);
                if (!canParseClass)
                {
                    throw new Exception($"Cannot parse class {className} in index");
                }
                if (charClass.Equals(_classNamesAndLevels.First()))
                {
                    return false;
                }                
            }

            return true;
        }

        public Spell GetSpellDetails(string spellName)
        {            
            var isSecondaryClass = IsSecondary(spellName);

            return new Spell()
            {
                CastingTime = _SpellTime(spellName, isSecondaryClass).Text,
                Class = isSecondaryClass ? _classNamesAndLevels.Last().charClass : _classNamesAndLevels.First().charClass,
                Components = _SpellComponents(spellName, isSecondaryClass).Text,
                Concentration = _SpellIsConcentration(spellName).Text.Equals(string.Empty) ? "No" : "Yes",
                Description = _SpellDescription(spellName, isSecondaryClass).Text,
                Duration = _SpellDuration(spellName, isSecondaryClass).Text,
                Level = _SpellLevel(spellName).Text,
                Name = _IndexName(spellName).Text,
                Range = _SpellRange(spellName, isSecondaryClass).Text,
                Ritual = _SpellIsRitual(spellName).Text.Equals(string.Empty) ? "No" : "Yes",
                School = _SpellSchool(spellName).Text
            };
        }
    }
}
