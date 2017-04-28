using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
            LoadHighScore();
        }
        public int getHighScore()
        {
            return highScore;
        }
        public void setHighScore()
        {
            highScore = scoreNumber;
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
        public void SaveHighScore()
        {
            FileStream scoreData;
            if (!File.Exists("highScoreData.txt"))
            {
                scoreData = new FileStream("highScoreData.txt", FileMode.Create);
                scoreData.Close();
                //scoreData = File.Create("highScoreData.txt");
            }
            //scoreData = File.OpenRead("highScoreData.txt");
            BinaryWriter scoreWriter = new BinaryWriter(File.Open("highScoreData.txt", FileMode.Open));
            //BinaryWriter scoreWriter = new BinaryWriter(scoreData);
            scoreWriter.Write(scoreNumber);
            scoreWriter.Close();
            //scoreWriter.Close();
        }
        private void LoadHighScore()
        {
            if (File.Exists("highScoreData.txt"))
            {
                BinaryReader scoreReader = new BinaryReader(File.Open("highScoreData.txt", FileMode.Open));
                highScore = scoreReader.ReadInt32();
                Console.Write("HIGHSCORE: " + highScore);
                
                scoreReader.Close();
            }
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
