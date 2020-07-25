using CharacterSheet5e.Enums;
using CharacterSheet5e.Importer.Actions;
using CharacterSheet5e.Importer.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterSheet5e.Managers
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

        public void RollSkill(Advantage adv, string skillName)
        {
            var bonus = _Skills.GetSkillBonusByName(skillName);

            var template = TemplateStartDefaultTemplate("Skill Check")
            + TemplateGenerateRow("Skill", skillName)
            + TemplateGenerateRow("Advantage", adv.ToString())
            + TemplateGenerateD20HiddenRoll(adv, bonus);

            Clipboard.SetText(template);
        }

        public void RollInitiative(Advantage adv)
        {
            var initiativeBonus = _MainPage.GetInitiativeBonus();

            var template = TemplateStartDefaultTemplate("Initiative")
            + TemplateGenerateRow("Advantage", adv.ToString())
            + TemplateGenerateD20HiddenRoll(adv, initiativeBonus, addToTurnTracker: true);

            Clipboard.SetText(template);
        }

        public void RollSavingThrow(Advantage adv, string savingThrow)
        {
            var bonus = _SavingThrows.GetSavingThrowBonus(savingThrow);

            var template = TemplateStartDefaultTemplate($"{savingThrow} Saving Throw")
            + TemplateGenerateRow("Save", savingThrow)
            + TemplateGenerateRow("Advantage", adv.ToString())
            + TemplateGenerateD20HiddenRoll(adv, bonus);

            Clipboard.SetText(template);
        }

        public void RollAttack(Advantage adv, string attackName)
        {
            // to hit            
            var toHitBonus = _Actions.GetToHitBonus(attackName);

            // damage
            var damageRoll = _Actions.GetBaseAttackRoll(attackName);
            var damageType = _Actions.GetDamageType(attackName);

            // template
            var template = TemplateStartDefaultTemplate($"{attackName} Attack")
            + TemplateGenerateRow("Advantage", adv.ToString())
            + TemplateGenerateD20HiddenRoll(adv, toHitBonus, descriptor: "ToHit")
            + TemplateGenerateRowWithHiddenRollText("Damage", damageRoll)
            + TemplateGenerateRow("DamageType", damageType);

            Clipboard.SetText(template);
        }       
    }
}
