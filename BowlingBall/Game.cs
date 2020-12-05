using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        int currentRoll = 0;


        public int GetScore()
        {
            // Returns the final score of the Bowling game.
            var score = 0;
            var rollIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                //Strike
                if (IsStrike(rollIndex))
                {
                    score += GetStrikeScore(rollIndex);
                    rollIndex++;
                }
                //Spare
                else if (IsSpare(rollIndex))
                {
                    score += GetSpareScore(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += GetStandardScore(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }

        public void Roll(int pins)
        {
           rolls[currentRoll++] = pins;
        }


        private int GetStrikeScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }       

        private int GetStandardScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        private int GetSpareScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }
    }
}
