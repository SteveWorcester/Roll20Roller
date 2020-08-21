using Roll20Roller.Enums;
using Roll20Roller.Importer.Actions;
using Roll20Roller.Managers;
using Roll20Roller.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Roll20Roller.Importer.Spells
{
    public class SpellsActions : SpellsManager
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
            SetSpellFilePaths(_classNamesAndLevels);
        }

        public void SetSpellsList(ComboBox ddlSpellsDropdown)
        {
            List<string> allSpellNames = new List<string>();


            if (SpellcastingClasses.Contains(_classNamesAndLevels.First().charClass))
            {
                using (StreamReader reader = new StreamReader(MainClassSpellsFilePath))
                {
                    var levelLimit = Math.Ceiling((double)_classNamesAndLevels.First().charLevel / 2) + 1;
                    var spellLevel = 0;
                    allSpellNames.Add($"-=Cantrips=-");
                    do
                    {
                        var fullList = reader.ReadLine().Split(';').ToList();
                        var levelCheck = int.Parse(fullList[0].Replace('"', ' ').Trim());

                        if (levelCheck > spellLevel && levelCheck < levelLimit)
                        {
                            allSpellNames.Add(string.Empty);
                            allSpellNames.Add($"-=Level {levelCheck} Spells=-");
                        }

                        spellLevel = int.Parse(fullList[0].Replace('"', ' ').Trim());
                        if (spellLevel < levelLimit)
                        {
                            allSpellNames.Add(fullList[1].Replace('"', ' ').Trim());
                        }




                    } while (spellLevel < levelLimit);
                    reader.Close();
                }
            }

            if (multiClassed && SpellcastingClasses.Contains(_classNamesAndLevels.Last().charClass))
            {
                using (StreamReader reader2 = new StreamReader(OffClassSpellsFilePath))
                {
                    var offClassLevelLimit = Math.Round((double)_classNamesAndLevels.Last().charLevel / 2);
                    var spellLevel = 0;
                    do
                    {
                        var fullList = reader2.ReadLine().Split(';').ToList();
                        spellLevel = int.Parse(fullList[0].Replace('"', ' ').Trim());
                        allSpellNames.Add(fullList[1].Replace('"', ' ').Trim());

                    } while (spellLevel <= offClassLevelLimit);
                    reader2.Close();
                }
            }

            var spellsBindingSource = new BindingSource();
            spellsBindingSource.DataSource = allSpellNames;

            ddlSpellsDropdown.ValueMember = "Name";
            ddlSpellsDropdown.DisplayMember = "Name";
            ddlSpellsDropdown.DataSource = spellsBindingSource.DataSource;
        }

        public Spell GetSpell(string spellName)
        {
            if (spellName.Equals(string.Empty) || spellName.Contains("=-"))
            {
                return new Spell();
            }
            /* index of each spell line: 
            0 = spell level
            1 = spell name
            2 = spell school and level
            3 = casting time
            4 = range
            5 = components
            6 = duration
            7 = description
            8 = class + ExtraInfo if expanded book
            */

            StreamReader reader = new StreamReader(MainClassSpellsFilePath);
            var intendedSpellLine = new List<string>();
            var foundSpell = false;
            do
            {
                var line = reader.ReadLine().Split(';');
                if (line[1].Replace('"', ' ').Trim().Equals(spellName)) 
                {
                    intendedSpellLine = line.ToList();
                    foundSpell = true;
                }
            } 
            while (!foundSpell && !reader.Peek().Equals(null));

            if (!foundSpell)
            {
                reader = new StreamReader(OffClassSpellsFilePath);
                do
                {
                    var line = reader.ReadLine().Split(';');
                    if (line[1].Replace('"', ' ').Trim().Equals(spellName))
                    {
                        intendedSpellLine = line.ToList();
                        foundSpell = true;
                    }
                }
                while (!foundSpell && !reader.Peek().Equals(null));
            }

            if (!foundSpell)
            {
                throw new Exception($"Unable to locate spell in {MainClassSpellsFilePath} or {OffClassSpellsFilePath}.");
            }

            string spellSchool = string.Empty;
            var canParseLevel = int.TryParse(intendedSpellLine[2].Replace('"', ' ').Trim().First().ToString(), out var spellLevel);
            if (canParseLevel)
            {
                spellSchool = intendedSpellLine[2].Replace('"', ' ').Trim().Split(' ').Last();
            }
            if (!canParseLevel)
            {
                spellLevel = 0;
                spellSchool = intendedSpellLine[2].Replace('"', ' ').Trim().Split(' ').First();
            }

            var canParseClass = Enum.TryParse(intendedSpellLine[8].Replace('"', ' ').Trim().Split(' ').First(), out CharacterClass charClass);
            if (!canParseClass)
            {
                throw new Exception($"cannot parse class {intendedSpellLine[8].Replace('"', ' ').Trim().Split(' ').First()}");
            }

            return new Spell()
            {
                Level = spellLevel,
                Name = intendedSpellLine[1].Replace('"', ' ').Trim(),
                School = spellSchool,
                CastingTime = intendedSpellLine[3].Replace('"', ' ').Trim(),
                Range = intendedSpellLine[4].Replace('"', ' ').Trim(),
                Components = intendedSpellLine[5].Replace('"', ' ').Trim(),
                Duration = intendedSpellLine[6].Replace('"', ' ').Trim(),
                Description = intendedSpellLine[7],
                Class = charClass
            };
        }
    }
}
