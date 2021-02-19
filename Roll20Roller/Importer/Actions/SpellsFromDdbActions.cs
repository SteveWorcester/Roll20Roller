using Roll20Roller.Enums;
using Roll20Roller.Importer.Base;
using Roll20Roller.Importer.Maps;
using Roll20Roller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20Roller.Importer.Actions
{
    public class SpellsFromDdbActions : SpellsObjects
    {
        private List<(CharacterClass charClass, int charLevel)> _classNamesAndLevels;
        private MainPageActions mainPage;
        public SpellsFromDdbActions(long charId)
        {
            SetCharacterAndPullData(charId);
            mainPage = new MainPageActions(charId);
            _classNamesAndLevels = mainPage.GetClassNamesAndLevels();
        }

        public List<string> GetAllSpellNames => AllSpellNames.Select(n => n.Text).ToList();

        internal void SetSpellsList(ComboBox ddlDdbSpells)
        {
            var spellsBindingSource = new BindingSource();
            spellsBindingSource.DataSource = GetAllSpellNames;

            ddlDdbSpells.ValueMember = "Name";
            ddlDdbSpells.DisplayMember = "Name";
            ddlDdbSpells.DataSource = spellsBindingSource.DataSource;
        }

        internal void Init(ComboBox ddlDdbSpells)
        {
            BtnSpellsTabButtonPreClick.Click();
            SetSpellsList(ddlDdbSpells);
            ddlDdbSpells.SelectedIndex = 0;
        }

        public Spell GetSpellFromDdb(string spellName)
        {
            if (spellName.Equals(string.Empty) || spellName.Contains("=-"))
            {
                return new Spell();
            }

            SpellLineParentByName(spellName).Click();

            if (!Enum.TryParse<CharacterClass>(SelectedSpellClass.Text, out var className))
            {
                throw new FormatException($"The class {SelectedSpellClass.Text} cannot be parsed in spell description.");
            }

            if (!int.TryParse(SelectedSpellLevel.Text.First().ToString(), out var levelInt))
            {
                if (SelectedSpellLevel.Text.Contains("Cantrip"))
                {
                    levelInt = 0;
                }
                else
                {
                    throw new FormatException($"unable to parse level {SelectedSpellLevel.Text} into character level for spells.");
                }
            }

            var isConcentration = SelectedSpellDuration.Text.Contains("Concentration");

            //if (SelectedSpellShortDescription.Text)
            {

            }

            return new Spell()
            {
                CastingTime = SelectedSpellCastingTime.Text,
                Class = className,
                ComponentTypes = SelectedSpellComponentTypes.Select(t => t.Text).ToList(),
                ComponentMaterials = SelectedSpellComponentMaterials.Text,
                Description = SelectedSpellDetail.Text,
                DescriptionHigherLevels = SelectedSpellDetailHigherLevels.Text,
                Duration = SelectedSpellDuration.Text,
                Level = levelInt,
                Name = SelectedSpellName.Text,
                Range = SelectedSpellRangeArea.Text,
                School = SelectedSpellSchool.Text
            };
        }
    }
}
