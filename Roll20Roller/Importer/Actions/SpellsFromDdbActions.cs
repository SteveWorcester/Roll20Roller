using Roll20Roller.Importer.Base;
using Roll20Roller.Importer.Maps;
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
        public SpellsFromDdbActions(long charId)
        {            
            BtnSpellsTabButtonPreClick.Click();
            BtnSpellsTabButtonPostClick.Click();
            SetCharacterAndPullData(charId);
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
    }
}
