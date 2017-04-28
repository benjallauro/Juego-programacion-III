using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game
{
    [Serializable]
    struct Position
    {
        public int x;
        public int y;
    }
    class Game
    {
        static private Player zero;
        static private List<Bullet> bullets;

        public Game()
        {

        }
        public int Run(string weather)
        {
            Position where;
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream playerPosData;
            if (!File.Exists("PlayerPosData.txt"))
            {
                playerPosData = File.Create("PlayerPosData.txt");
                where.x = 50;
                where.y = 20;
            }
            else
            {
                using (playerPosData = File.OpenRead("PlayerPosData.txt"))
                {
                    where = (Position)formatter.Deserialize(playerPosData);
                }
            }
            playerPosData.Close();

            Score theScore = new Score();
            switch(weather)
            {
                case "Cloudy":
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case "Sunny":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Random rand = new Random();
            zero = new Player(where.x, where.y);

            bullets = new List<Bullet>();
            ConsoleKey lastDirectionKey = new ConsoleKey(); //Sirve para que guarde la direccion en la que se esta moviendo el jugador

            Enemy[] badGuys = new Enemy[20];
            for (int i = 0; i < badGuys.Length; i++)
                badGuys[i] = new Enemy(rand.Next(0, 79), rand.Next(0, 23));
            Bomb[] mines = new Bomb[5];
            for (int i = 0; i < mines.Length; i++)
                mines[i] = new Bomb(rand.Next(0, 79), rand.Next(0, 23));
            Item[] coins = new Item[10];
            for (int i = 0; i < coins.Length; i++)
                coins[i] = new Item(rand.Next(0, 79), rand.Next(0, 23));
            Console.SetCursorPosition(35, 12);
            Console.WriteLine("GAME START!");
            zero.draw();
            Console.ReadKey();
            while (zero.CheckLife() == true)
            {
                Console.Clear();
                zero.draw();
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo controls = Console.ReadKey();
                    zero.Moverse(controls);
                    if (controls.Key == ConsoleKey.UpArrow || controls.Key == ConsoleKey.DownArrow || controls.Key == ConsoleKey.LeftArrow || controls.Key == ConsoleKey.RightArrow)
                        lastDirectionKey = controls.Key;
                    else if (controls.Key == ConsoleKey.Spacebar)
                        bullets.Add(new Bullet(zero.getX(), zero.getY(), lastDirectionKey));
                    else if (controls.Key == ConsoleKey.Escape)
                        return 0;
                }
                for (int i = 0; i < badGuys.Length; i++)
                {
                    for (int j = 0; j < bullets.Count; j++)
                    {
                        if (badGuys[i].GetX() == bullets[j].GetPosX() && badGuys[i].GetY() == bullets[j].GetPosY())
                        {
                            badGuys[i].Respawn();
                            bullets.RemoveAt(j);
                            theScore.scoreUp();
                        }
                    }
                }
                for (int i = 0; i < mines.Length; i++)
                {
                    mines[i].Draw();
                    if (mines[i].Sense(zero.getX(), zero.getY()))
                        zero.death();
                }
                for (int i = 0; i < badGuys.Length; i++)
                {
                    badGuys[i].draw();
                    badGuys[i].Move();
                    if (badGuys[i].searchAndKill(zero.getX(), zero.getY()))
                    {
                        zero.LoseLife();
                        if (zero.GetLives() == 0)
                            zero.death();
                    }
                }
                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].Update();
                }
                for(int i = 0; i < coins.Length; i++)
                {
                    coins[i].draw();
                    if(coins[i].GetX() == zero.getX() && coins[i].GetY() == zero.getY())
                    {
                        coins[i].Respawn();
                        theScore.scoreUp();
                    }
                }
                if (theScore.getScoreNumber() > theScore.getHighScore())
                    theScore.setHighScore();
                theScore.Draw();
                DrawLives();
                System.Threading.Thread.Sleep(50);
            }
            Console.SetCursorPosition(35, 12);
            Console.WriteLine("GAME OVER");
            where.x = zero.getX();
            where.y = zero.getY();
            using (playerPosData = File.OpenWrite("PlayerPosData.txt"))
            {
                formatter.Serialize(playerPosData, where); // it stops here and says "it can't be modified" the second time
            }
            if(theScore.getRecordBoolean()) //Devuelve se se realizo un nuevo record}
            {
                /*scoreData = File.OpenRead("HighScoreData.txt");
                BinaryWriter scoreDataWriter = new BinaryWriter(scoreData);
                scoreDataWriter.Write(theScore.getScoreNumber());*/
                theScore.SaveHighScore();
            }
            playerPosData.Close();

            Console.ReadKey();
            return 0;
        }

        static public void DrawLives()
        {
            for (int i = 0; i < zero.GetLives(); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.WriteLine("♥");
            }
        }
    }
}