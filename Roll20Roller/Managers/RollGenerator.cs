﻿using Roll20Roller.Enums;
using Roll20Roller.Importer.Actions;
using Roll20Roller.Importer.Base;
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
        }

        public SkillsActions _Skills;
        public MainPageActions _MainPage;
        public ActionsActions _Actions;
        public SavingThrowsActions _SavingThrows;

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

        public void RollSavingThrow(Advantage adv, string savingThrow, bool gmOnly, bool barbRage)
        {
            var bonus = barbRage && savingThrow.Equals("STR") ? _SavingThrows.GetSavingThrowBonus(savingThrow) + _Actions.GetRageBonus() : _SavingThrows.GetSavingThrowBonus(savingThrow);

            var template = string.Empty;

            if (gmOnly)
            {
                template += _gmWhisper;
            }

            template += TemplateStartDefaultTemplate($"Saving Throw")
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

            template += TemplateGenerateRow("Advantage", adv.ToString())
            + TemplateGenerateD20HiddenRoll(adv, toHitBonus, descriptor: "ToHit")
            + TemplateGenerateRowWithHiddenRollText("Damage", damageRoll)
            + TemplateGenerateRow("DamageType", damageType);

            Clipboard.SetText(template);
        }       
    }
}