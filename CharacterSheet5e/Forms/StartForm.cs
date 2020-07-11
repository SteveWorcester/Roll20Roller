using CharacterSheet5e.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSheet5e.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();            
        }

        public long SelectedCharacterId;

        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (RbCloron.Checked)
            {
                SelectedCharacterId = (long)CharacterName.Cloron;
            }
            else if (RbOther.Checked)
            {
                var canParse = long.TryParse(TxtOther.Text, out SelectedCharacterId);
                if (!canParse)
                {
                    throw new InvalidOperationException("Character ID must be a number");
                }
            }
            this.Hide();
            CharacterForm characterForm = new CharacterForm(SelectedCharacterId);
            characterForm.Show();
        }
    }
}
