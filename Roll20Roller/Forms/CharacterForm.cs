using Roll20Roller.Enums;
using Roll20Roller.Importer.Actions;
using Roll20Roller.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20Roller.Forms
{
    public partial class CharacterForm : Form
    {
        public SkillsActions _Skills;
        public MainPageActions _MainPage;
        public RollGenerator _Roll;
        public ActionsActions _Actions;
        public SavingThrowsActions _SavingThrows;
        public CustomRollManager _CustomRollManager;
        public SpellsFromDdbActions _SpellsDdb;
        
        private Advantage selectedAdvantage = Advantage.Normal;
        private bool GmOnly = false;
        private string characterName = string.Empty;

        public bool IsDebug = bool.Parse(ConfigurationManager.AppSettings["IsDebugMode"]);
        public bool IsDarkMode = true;

        public CharacterForm(long charId)
        {
            InitializeComponent();
            _Roll = new RollGenerator(charId);
            _MainPage = new MainPageActions(charId);
            _Actions = new ActionsActions(charId);
            _Skills = new SkillsActions(charId);
            _SavingThrows = new SavingThrowsActions(charId);
            _CustomRollManager = new CustomRollManager(charId);
            _SpellsDdb = new SpellsFromDdbActions(charId);

            #region Class-Specific Options

            var classes = _MainPage.GetClassNamesAndLevels();
            _Actions.SetupClassOptions(GrpClassOptions1, classes.First().Item1.ToString(), classes.Last().Item1.ToString());

            #endregion

            #region Main Page

            characterName = _MainPage.GetCharacterName();            
            
            LblCharacterName.Text = characterName;
            this.Text = $"{characterName} - Roll20Roller";

            #endregion

            #region Attacks

            _Actions.SetEquippedWeaponsList(DdlEquippedWeapon);

            #endregion

            #region Skills

            _Skills.SetSkillsList(DdlSkills);

            #endregion

            #region Saving Throws
            
            var savingThrowNames = _SavingThrows.GetAllSavingThrowNames();
            BtnSavingThrowStr.Text = savingThrowNames[0];
            BtnSavingThrowDex.Text = savingThrowNames[1];
            BtnSavingThrowCon.Text = savingThrowNames[2];
            BtnSavingThrowInt.Text = savingThrowNames[3];
            BtnSavingThrowWis.Text = savingThrowNames[4];
            BtnSavingThrowCha.Text = savingThrowNames[5];

            #endregion

            #region Custom Rolls

            var allCustomRolls = _CustomRollManager.GetAllCustomRolls();
            var customGroup = GetAllControls(GrpCustom);

            foreach (var roll in allCustomRolls)
            {
                foreach (Control control in customGroup)
                {
                    if (control is TextBox && control.Name.EndsWith(roll.CustomRowNumber.ToString()))
                    {
                        if (control.Name.Contains("TxtDescription"))
                        {
                            control.Text = roll.Description;
                        }
                        if (control.Name.Contains("TxtNumberOfDice"))
                        {
                            control.Text = roll.NumberOfDice.ToString();
                        }
                        if (control.Name.Contains("TxtDieSides"))
                        {
                            control.Text = roll.SidesOfDice.ToString();
                        }
                        if (control.Name.Contains("TxtBonus"))
                        {
                            control.Text = roll.Bonus.ToString();
                        }
                    }
                }
            }

            #endregion

            #region Spells From Ddb

            if (_SpellsDdb.HasAvailableSpells())
            {
                _SpellsDdb.Init(DdlDdbSpells);
            }
            else
            {
                DdlDdbSpells.Enabled = false;
                BtnDdbSpell.Enabled = false;
                CbSpellHigherLevels.Enabled = false;
                BtnDdbSpell.Text = "No Spells!";
            }

            #endregion

            RbNormal.Select();
            CbTopmost.Checked = true;
            ViewManager.ToggleDarkMode(this);
        }

        #region Skills

        private void BtnSkillRoll_Click(object sender, EventArgs e)
        {
            _Roll.RollSkill(selectedAdvantage, DdlSkills.Text, GmOnly);          
        }

        #endregion

        #region Initiative

        private void BtnInitiative_Click(object sender, EventArgs e)
        {
            _Roll.RollInitiative(selectedAdvantage, GmOnly);
        }

        #endregion

        #region Attacks

        private void BtnAttack1_Click(object sender, EventArgs e)
        {
            _Roll.RollAttack(selectedAdvantage, DdlEquippedWeapon.Text, CbVersatile.Checked, GmOnly, CbRage.Checked);
        }

        private void DdlEquippedWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbVersatile.Checked = false;
            CbVersatile.Enabled = _Actions.IsAttackVersatile(DdlEquippedWeapon.Text);
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
            _Roll.RollSavingThrow(selectedAdvantage, threeLetterAcronym, GmOnly, CbStatCheck.Checked);
        }

        #endregion

        #region Advantage

        private void SetAdvantageColors()
        {
            var buttonList = GetAllControls(this).ToList();
            foreach (Control control in buttonList)
            {
                if (control is Button 
                    && !control.Text.Equals("Exit") 
                    && !control.Text.Equals("Roll") 
                    && !control.Name.Contains("Rb")
                    && !control.Text.Equals("Copy Spell Details")
                    && !control.Text.Contains("Theme"))
                {
                    if (selectedAdvantage.Equals(Advantage.Disadvantage))
                    {
                        control.BackColor = IsDarkMode ? Color.DarkRed : Color.LightPink;
                    }
                    if (selectedAdvantage.Equals(Advantage.Normal))
                    {
                        control.BackColor = IsDarkMode ? Color.DarkSlateGray : Color.White;
                    }
                    if (selectedAdvantage.Equals(Advantage.Advantage))
                    {
                        control.BackColor = IsDarkMode ? Color.Green : Color.LightGreen;
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

        private void RbAdvantage_Click(object sender, EventArgs e)
        {
            selectedAdvantage = Advantage.Advantage;
            SetAdvantageColors();
        }

        private void RbNormal_Click(object sender, EventArgs e)
        {
            selectedAdvantage = Advantage.Normal;
            SetAdvantageColors();
        }

        private void RbDisadvantage_Click(object sender, EventArgs e)
        {
            selectedAdvantage = Advantage.Disadvantage;
            SetAdvantageColors();
        }

        #endregion

        #region Custom Rolls

        private void CustomRoll(string description, string numberOfDice, string dieSides, string bonus, int rowNumber)
        {
            var roll = _CustomRollManager.CreateCustomRoll(description, numberOfDice, dieSides, bonus, rowNumber);
            _Roll.RollCustom(roll, CbGmOnly.Checked);
        }

        private void BtnRollCustom0_Click(object sender, EventArgs e)
        {
            CustomRoll(TxtDescription0.Text, TxtNumberOfDice0.Text, TxtDieSides0.Text, TxtBonus0.Text, 0);
        }

        private void BtnRollCustom1_Click_1(object sender, EventArgs e)
        {
            CustomRoll(TxtDescription1.Text, TxtNumberOfDice1.Text, TxtDieSides1.Text, TxtBonus1.Text, 1);
        }

        private void BtnRollCustom2_Click(object sender, EventArgs e)
        {
            CustomRoll(TxtDescription2.Text, TxtNumberOfDice2.Text, TxtDieSides2.Text, TxtBonus2.Text, 2);
        }

        private void BtnRollCustom3_Click(object sender, EventArgs e)
        {
            CustomRoll(TxtDescription3.Text, TxtNumberOfDice3.Text, TxtDieSides3.Text, TxtBonus3.Text, 3);
        }

        private void BtnRollCustom4_Click(object sender, EventArgs e)
        {
            CustomRoll(TxtDescription4.Text, TxtNumberOfDice4.Text, TxtDieSides4.Text, TxtBonus4.Text, 4);
        }

        #endregion

        #region Main Window

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _Actions._Driver.Quit();
            Environment.Exit(0);
        }

        private void CbTopmost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = CbTopmost.Checked;
        }

        private void BtnDarkMode_Click(object sender, EventArgs e)
        {
            selectedAdvantage = Advantage.Normal;
            IsDarkMode = IsDarkMode ? false : true;
            BtnDarkMode.Text = BtnDarkMode.Text.Equals("Light Theme") ? "Dark Theme" : "Light Theme";
            ViewManager.ToggleDarkMode(this);
        }

        #endregion

        #region Spells from Ddb

        private void BtnDdbSpell_Click(object sender, EventArgs e)
        {
            _Roll.GetSpellCard(_SpellsDdb.GetSpellFromDdb(DdlDdbSpells.Text), GmOnly, CbSpellHigherLevels.Checked);
        }

        #endregion


    }
}
