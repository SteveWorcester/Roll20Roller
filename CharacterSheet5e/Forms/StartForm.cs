using CharacterSheet5e.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSheet5e.Forms
{
    public partial class StartForm : Form
    {
        private long selectedCharacterId;
        private string characterIdFolder = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["LastCharacterIdFilePath"]);
        private string lastCharacterIdFileName = ConfigurationManager.AppSettings["FileName"];
        private string fullFilePath;
        private string lastCharacterId;

        public StartForm()
        {
            InitializeComponent();
            if (!Directory.Exists(characterIdFolder))
            {
                Directory.CreateDirectory(characterIdFolder);
            }
            fullFilePath = Path.Combine(characterIdFolder, lastCharacterIdFileName);

            var fileExists = File.Exists(fullFilePath);
            if (fileExists)
            {
                StreamReader read = new StreamReader(fullFilePath);
                lastCharacterId = read.ReadLine();
                read.Close();
                TxtOther.Text = lastCharacterId;
            }
            else if (!fileExists)
            {
                var newFile = File.Create(fullFilePath);
                newFile.Close();
            }
            
            LblLoading.Text = "";
        }



        private void BtnImport_Click(object sender, EventArgs e)
        {
            BtnImport.Enabled = false;
            LblLoading.Text = "LOADING...";
            LblLoading.ForeColor = Color.Black;
            LblLoading.BackColor = Color.AliceBlue;
            var canParse = long.TryParse(TxtOther.Text, out selectedCharacterId);
            if (!canParse)
            {
                throw new InvalidOperationException("Character ID must be a number. " +
                    "Pull the character ID number from the DndBeyond.com URL when viewing your character.");
            }

            if (!TxtOther.Text.Equals(lastCharacterId))
            {
                StreamWriter write = new StreamWriter(fullFilePath);
                write.WriteLine(TxtOther.Text);
                write.Close();
            }

            CharacterForm characterForm = new CharacterForm(selectedCharacterId);
            characterForm.Show();
            this.Hide();
        }
    }
}
