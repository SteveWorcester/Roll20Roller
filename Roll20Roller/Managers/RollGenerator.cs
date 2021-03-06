using Roll20Roller.Enums;
using Roll20Roller.Importer.Actions;
using Roll20Roller.Importer.Base;
using Roll20Roller.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20Roller.Managers
{
    public class RollGenerator : TemplateFactory
    {
        public RollGenerator(long charId)
        {
            _Skills = new SkillsActions(charId);
            _MainPage = new MainPageActions(charId);
            _Actions = new ActionsActions(charId);
            _SavingThrows = new SavingThrowsActions(charId);
            _Spells = new SpellsFromDdbActions(charId);
        }

        public SkillsActions _Skills;
        public MainPageActions _MainPage;
        public ActionsActions _Actions;
        public SavingThrowsActions _SavingThrows;
        public SpellsFromDdbActions _Spells;

        private string _gmWhisper = "/w gm ";

        public void RollSkill(Advantage adv, string skillName, bool gmOnly)
        {
            var bonus = _Skills.GetSkillBonusByName(skillName);
            var template = string.Empty;

            if (gmOnly)
            {
                template += _gmWhisper;
            }

            template += TemplateStartDefaultTemplate("Skill Check")
            + TemplateGenerateRow("Skill", skillName)
            + TemplateGenerateRow("Advantage", adv.ToString())
            + TemplateGenerateD20HiddenRoll(adv, bonus);

            Clipboard.SetText(template);
        }

        public void RollInitiative(Advantage adv, bool gmOnly)
        {
            var initiativeBonus = _MainPage.GetInitiativeBonus();
            var template = string.Empty;

            if (gmOnly)
            {
                template += _gmWhisper;
            }

            template += TemplateStartDefaultTemplate("Initiative")
            + TemplateGenerateRow("Advantage", adv.ToString())
            + TemplateGenerateD20HiddenRoll(adv, initiativeBonus, addToTurnTracker: true);

            Clipboard.SetText(template);
        }

        public void RollSavingThrow(Advantage adv, string savingThrow, bool gmOnly, bool statCheckOnly)
        {
            var bonus = statCheckOnly ? _SavingThrows.GetStatCheckBonus(savingThrow) : _SavingThrows.GetSavingThrowBonus(savingThrow);
            var title = statCheckOnly ? "Stat Check" : "Saving Throw";

            var template = string.Empty;

            if (gmOnly)
            {
                template += _gmWhisper;
            }

            template += TemplateStartDefaultTemplate(title)
            + TemplateGenerateRow("Save", savingThrow)
            + TemplateGenerateRow("Advantage", adv.ToString())
            + TemplateGenerateD20HiddenRoll(adv, bonus);

            Clipboard.SetText(template);
        }

        public void RollAttack(Advantage adv, string attackName, bool versatile, bool gmOnly, bool rageEnabled)
        {
            // to hit            
            var toHitBonus = _Actions.GetToHitBonus(attackName);

            // damage
            var damageRoll = versatile ? _Actions.GetVersatileAttackRoll(attackName) : _Actions.GetBaseAttackRoll(attackName);
            damageRoll = rageEnabled ? damageRoll+=$"+{_Actions.GetRageBonus().ToString()}" : damageRoll;
            var damageType = _Actions.GetDamageType(attackName);

            // template
            var template = string.Empty;

            if (gmOnly)
            {
                template += _gmWhisper;
            }

            template += TemplateStartDefaultTemplate($"{attackName} Attack");
            
            if (versatile)
            {
                template += TemplateGenerateRow("Versatile", "2-Handed");
            }

            template += TemplateGenerateRow("Advantage", adv.ToString());
            if (! _Actions.AttackHasSaveDc(attackName))
            {
                template += TemplateGenerateD20HiddenRoll(adv, toHitBonus, descriptor: "ToHit");
            }
            template += _Actions.AttackHasSaveDc(attackName) ? TemplateGenerateRow("Save DC", damageRoll) : TemplateGenerateRowWithHiddenRollText("Damage", damageRoll);
            template += TemplateGenerateRow("DamageType", damageType);

            Clipboard.SetText(template);
        }

        public void RollCustom(CustomRoll roll, bool gmOnly)
        {
            var template = string.Empty;

            if (gmOnly)
            {
                template += _gmWhisper;
            }

            template += TemplateStartDefaultTemplate($"{roll.Description}")
            + TemplateGenerateRowWithHiddenRollText("Roll", $"{roll.NumberOfDice}d{roll.SidesOfDice}+{roll.Bonus}");

            Clipboard.SetText(template);
        }

        public void GetSpellCard(Spell spell, bool gmOnly, bool displayHigherLevelsText)
        {
            Clipboard.Clear();
            if (!spell.Description.Equals("Invalid"))
            {
                var componentTypes = new StringBuilder();
                spell.ComponentTypes.ForEach(t => componentTypes.Append($"{t} "));
                var range = int.TryParse(spell.Range, out _) ? $"{spell.Range} ft." : spell.Range;
                var bonuses = _Spells.HasSpellSpecificDc(spell) ? _Spells.SpellSpecificBonuses(spell) : _Spells.SpellBonuses();

                var template = string.Empty;

                if (gmOnly)
                {
                    template += _gmWhisper;
                }

                template += TemplateStartDefaultTemplate(
                    $"{spell.Name}\n" +
                    $"Level {spell.Level.ToString()} {spell.School}\n" +
                    $"{spell.Class}")
                + TemplateGenerateRow("Casting", spell.CastingTime)
                + TemplateGenerateRow("Range", range)
                + TemplateGenerateRow("Components", $"{componentTypes.ToString().Trim()}; {spell.ComponentMaterials}")
                + TemplateGenerateRow("Duration", spell.Duration)
                + TemplateGenerateRow("Bonuses", $"Damage: {bonuses.modifier}\n" +
                                                 $"Spell Attack: {bonuses.spellAttack}\n" +
                                                 $"Save DC: {bonuses.saveDc}")                
                + TemplateGenerateRow("Short Description", spell.Description);

                if (displayHigherLevelsText)
                {
                    template += TemplateGenerateRow("Higher Levels", spell.DescriptionHigherLevels);
                }

                Clipboard.SetText(template);
            }
        }
    }
}
