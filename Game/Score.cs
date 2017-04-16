using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    class Score
    {
        static int scoreNumber;
        static int highScore;
        private bool record = false;
        public Score()
        {
            scoreNumber = 0;
        }
        public int getHighScore()
        {
            return highScore;
        }
        public void setHighScore(int score)
        {
            highScore = score;
            if (record == false)
                record = true;
        }
        public int getScoreNumber()
        {
            return scoreNumber;
        }
        public void scoreUp()
        {
            scoreNumber++;
        }
        public bool getRecordBoolean()
        {
            return record;
        }
        public void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("SCORE: " + scoreNumber);
            if (record == true)
                Console.Write("  NEW HIGHSCORE!");
        }
    }
}
