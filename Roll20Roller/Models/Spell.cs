using Roll20Roller.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Models
{
    public class Spell
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionHigherLevels { get; set; }
        public string Range { get; set; }
        public List<string> ComponentTypes { get; set; }
        public string ComponentMaterials { get; set; }
        public int Level { get; set; }
        public string School { get; set; }
        public CharacterClass Class { get; set; }
        public string CastingTime { get; set; }
        public string Duration { get; set; }
        public bool IsConcentration { get; set; }
    }
}
