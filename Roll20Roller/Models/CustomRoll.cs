using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Models
{
    public class CustomRoll
    {
        public int CustomRowNumber { get; set; }
        public string Description { get; set; }
        public int NumberOfDice { get; set; }
        public int SidesOfDice { get; set; }
        public int Bonus { get; set; }
    }
}
