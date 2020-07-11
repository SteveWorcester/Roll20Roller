﻿using CharacterSheet5e.Importer.Base;
using CharacterSheet5e.Importer.Maps;
using System;
using System.Collections.Generic;

namespace CharacterSheet5e.Importer.Actions
{
    public class SkillsActions : SkillsObjects
    {
        public SkillsActions(long charId)
        {
            SetCharacterAndPullData(charId);
        }

        public List<string> GetAllSkillNames()
        {
            var allNames = new List<string>();
            foreach (var name in _allSkillNames)
            {
                allNames.Add(name.Text);
            }
            return allNames;
        }

        public int GetSkillBonusByName(string abilityName)
        {
            var isPositive = _skillPlusMinus(abilityName).Text.Equals("+");
            var canParse = int.TryParse(_skillBonus(abilityName).Text, out var bonus);
            if (!canParse)
            {
                throw new FormatException($"Unable to parse {abilityName}'s bonus text");
            }
            return isPositive ? bonus : -bonus;
        }
    }
}
