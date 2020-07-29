using CharacterSheet5e.Enums;
using CharacterSheet5e.Importer.Actions;
using CharacterSheet5e.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CharacterSheet5e.Forms
{
    public partial class CharacterForm : Form
    {
        public SkillsActions _Skills;
        public MainPageActions _MainPage;
        public RollGenerator _Roll;
        public ActionsActions _Actions;

        public IList<string> AllSkillNames { get; set; }
        public string SelectedSkillName = "Acrobatics";
        
        private Advantage selectedAdvantage;

        IList<string> AllAttackNames { get; set; }
        public string SelectedAttackName;
        

        public CharacterForm(long charId)
        {
            InitializeComponent();
            _Roll = new RollGenerator(charId);

            #region Main Page

            _MainPage = new MainPageActions(charId);
            LblCharacterName.Text = _MainPage.GetCharacterName();
            this.Text = $"{_MainPage.GetCharacterName()} - Roll20Roller";

            #endregion

            #region Attacks

            _Actions = new ActionsActions(charId);
            AllAttackNames = _Actions.AllAttackNames();

            var attacksBindingSource = new BindingSource();
            attacksBindingSource.DataSource = AllAttackNames;

            DdlEquippedWeapon.ValueMember = "Name";
            DdlEquippedWeapon.DisplayMember = "Name";
            DdlEquippedWeapon.DataSource = attacksBindingSource.DataSource;
            SelectedAttackName = AllAttackNames.First();

            #endregion

            #region Skills

            _Skills = new SkillsActions(charId);
            AllSkillNames = _Skills.GetAllSkillNames();
            var skillsBindingSource = new BindingSource();
            skillsBindingSource.DataSource = AllSkillNames;

            DdlSkills.ValueMember = "Name";
            DdlSkills.DisplayMember = "Name";
            DdlSkills.DataSource = skillsBindingSource.DataSource;

            #endregion

            #region Saving Throws

            SavingThrowsActions _SavingThrows = new SavingThrowsActions(charId);
            var savingThrowNames = _SavingThrows.GetAllSavingThrowNames();
            BtnSavingThrowStr.Text = savingThrowNames[0];
            BtnSavingThrowDex.Text = savingThrowNames[1];
            BtnSavingThrowCon.Text = savingThrowNames[2];
            BtnSavingThrowInt.Text = savingThrowNames[3];
            BtnSavingThrowWis.Text = savingThrowNames[4];
            BtnSavingThrowCha.Text = savingThrowNames[5];

            #endregion

            RbNormal.Select();
            CbTopmost.Checked = true;
        }

        #region Skills

        private void DdlSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSkillName = DdlSkills.SelectedItem.ToString();
        }

        private void BtnSkillRoll_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollSkill(selectedAdvantage, SelectedSkillName);          
        }

        #endregion

        #region Initiative

        private void BtnInitiative_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollInitiative(selectedAdvantage);
        }

        #endregion

        #region Attacks

        private void BtnAttack1_Click(object sender, EventArgs e)
        {
            SetAdvantage();
            _Roll.RollAttack(selectedAdvantage, SelectedAttackName);
        }

        private void DdlEquippedWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedAttackName = DdlEquippedWeapon.SelectedItem.ToString();
        }

        #endregion

        #region Saving Throws

        private void BtnSavingThrowStr_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowStr.Text);
        }

        private void BtnSavingThrowDex_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowDex.Text);
        }

        private void BtnSavingThrowCon_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowCon.Text);
        }

        private void BtnSavingThrowInt_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowInt.Text);
        }

        private void BtnSavingThrowWis_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowWis.Text);
        }

        private void BtnSavingThrowCha_Click(object sender, EventArgs e)
        {
            ActivateSavingThrow(BtnSavingThrowCha.Text);
        }

        private void ActivateSavingThrow(string threeLetterAcronym)
        {
            SetAdvantage();
            _Roll.RollSavingThrow(selectedAdvantage, threeLetterAcronym);
        }

        #endregion

        #region Advantage

        private void SetAdvantage()
        {
            if (RbDisadvantage.Checked)
            {
                selectedAdvantage = Advantage.Disadvantage;
            }
            else if (RbNormal.Checked)
            {
                selectedAdvantage = Advantage.Normal;
            }
            else if (RbAdvantage.Checked)
            {
                selectedAdvantage = Advantage.Advantage;
            }
            SetAdvantageColors();
        }

        private void SetAdvantageColors()
        {
            var buttonList = GetAllControls(this).ToList();
            foreach (Control control in buttonList)
            {
                if (control is Button && control.Text != "Exit")
                {
                    if (selectedAdvantage.Equals(Advantage.Disadvantage))
                    {
                        control.BackColor = Color.LightPink;
                    }
                    if (selectedAdvantage.Equals(Advantage.Normal))
                    {
                        control.BackColor = Color.LightGray;
                    }
                    if (selectedAdvantage.Equals(Advantage.Advantage))
                    {
                        control.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        public IEnumerable<Control> GetAllControls(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetAllControls(child));
            }

            controls.Add(parent);

            return controls;
        }

        private void RbAdvantage_CheckedChanged(object sender, EventArgs e)
        {
            SetAdvantage();
        }

        private void RbNormal_CheckedChanged(object sender, EventArgs e)
        {
            SetAdvantage();
        }

        private void RbDisadvantage_CheckedChanged(object sender, EventArgs e)
        {
            SetAdvantage();
        }

        #endregion

        private void BtnExit_Click(object sender, EventArgs e)
        {
            _Actions._Driver.Quit();
            Environment.Exit(0);
        }

        private void CbTopmost_CheckedChanged(object sender, EventArgs e)
        {
            if (CbTopmost.Checked)
            {
                this.TopMost = true;
            }
            else if (!CbTopmost.Checked)
            {
                this.TopMost = false;
            }
        }
    }
}
