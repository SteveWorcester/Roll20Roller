using Roll20Roller.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20Roller.Managers
{
    public class CustomRollManager
    {
        public CustomRollManager(long charId)
        {
            characterIdFolder = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["LastCharacterIdFilePath"]);
            customRollFileName = $"{charId}_CustomRolls.txt";
            fullFilePath = Path.Combine(characterIdFolder, customRollFileName);
            if (!File.Exists(fullFilePath))
            {
                string[] emptyLines = new string[] { "$$$", "$$$", "$$$", "$$$", "$$$" };
                File.WriteAllLines(fullFilePath, emptyLines);
            }
        }

        private string characterIdFolder { get; }
        private string customRollFileName { get; }
        private string fullFilePath { get; }

        public CustomRoll CreateCustomRoll(string description, string numberOfDice, string sidesOfDice, string bonus, int customRowNumber)
        {

            var canParseNumberOfDice = int.TryParse(numberOfDice, out var NoOfDice);
            if (!canParseNumberOfDice) { NoOfDice = 0; }

            var canParseSidesOfDice = int.TryParse(sidesOfDice, out var dieSides);
            if (!canParseSidesOfDice) { dieSides = 0; }

            var canParseBonus = int.TryParse(bonus, out var rollBonus);
            if (!canParseBonus) { rollBonus = 0; }

            var roll = new CustomRoll
            {
                CustomRowNumber = customRowNumber,
                Bonus = rollBonus,
                Description = description,
                NumberOfDice = NoOfDice,
                SidesOfDice = dieSides
            };

            SaveRoll(roll);
            return roll;
        }

        private void SaveRoll(CustomRoll roll)
        {
            var currentRolls = File.ReadAllLines(fullFilePath);
            currentRolls[roll.CustomRowNumber] = $"{roll.Description}${roll.NumberOfDice}${roll.SidesOfDice}${roll.Bonus}";
            File.WriteAllLines(fullFilePath, currentRolls); 
        }

        public List<CustomRoll> GetAllCustomRolls()
        {
            var rollList = new List<CustomRoll>();

            var allLines = File.ReadAllLines(fullFilePath);
            for (int i = 0; i < allLines.Count(); i++)
            {
                var splitLine = allLines[i].Split('$');
                rollList.Add(CreateCustomRoll(splitLine[0], splitLine[1], splitLine[2], splitLine[3], i));
            }

            return rollList;
        }
    }
}
