using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeepSeaAdventure
{
    /* A class for keeping track of the score the player has in the level */

    public class Score
    {
        private static Score instance = new Score();
        private int currentScore = 0;

        private Score() { }

        //public read-only property

        public static Score Instance
        {
            get { return instance; }
        }

        /* Retrieve the current score */
        public int getScore()
        {
            return currentScore;
        }

        /* Increase the score */
        public void incrementScore(int amount)
        {
            /* Ammount in taken from the score given by the destroyed creature/collectable */
            currentScore += amount;
        }

        /* Reset the score */
        public void resetScore()
        {
            currentScore = 0;
        }

    }
}
