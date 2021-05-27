using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetProgrammeringsTest
{
    public class Dice
    {
       public Random diceRange = new Random();
       public bool success;

        //A regular dice toss
        public int DiceToss(int diceSize){

            int diceToss = diceRange.Next(1, diceSize);
            return diceToss;

            }
        //Dice roll that might be used to check player luck, etc
        public bool DiceRollagainstTreshold(int diceSize, int mcStat, int threshold)
        {

            mcStat = mcStat + diceRange.Next(1, diceSize);

            success = mcStat > threshold ? true : false;
            return success;
        }
        //Dice roll used to messure player and opponent stats 
       public bool DiceRollagainstOpponent(int diceSize, int mcStat, int enemyStat)
        {
            Random diceRange = new Random();

            mcStat = mcStat + diceRange.Next(1, diceSize);

            enemyStat = enemyStat + diceRange.Next(1, diceSize);

            success = mcStat > enemyStat ? true : false;
            return success;
        }
    }
}

