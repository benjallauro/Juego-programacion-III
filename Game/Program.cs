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
    class Program
    {
        static private Player zero;
        static private List<Bullet> bullets;
        static void Main(string[] args)
        {

            //FileStream data = new FileStream("gameData.txt", FileMode.OpenOrCreate); //abre el codigo si existe. sino, lo crea.
            //StreamWriter textSaver = new StreamWriter(data); //escritor de texto
            //BinaryWriter scoreSaver = new BinaryWriter(data);
            //BinaryFormatter formatter = new BinaryFormatter();
            //FileStream playerPosData = new FileStream("PlayerPosData.txt", FileMode.OpenOrCreate);
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
            Menu theMenu = new Menu();
            if (theMenu.MoveAndChoose() == true)
            {
                Score theScore = new Game.Score();
                Console.BackgroundColor = ConsoleColor.Green;
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
                    }
                    for (int i = 0; i < badGuys.Length; i++)
                    {
                        for (int j = 0; j < bullets.Count; j++)
                        {
                            if (badGuys[i].GetX() == bullets[j].GetPosX() && badGuys[i].GetY() == bullets[j].GetPosY())
                            {
                                badGuys[i].Respawn();
                                bullets.RemoveAt(j); 
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
                    theScore.scoreUp();
                    if (theScore.getScoreNumber() > theScore.getHighScore())
                        theScore.setHighScore(theScore.getScoreNumber());
                    theScore.Draw();
                    DrawLives();
                    System.Threading.Thread.Sleep(50);
                }
                Console.SetCursorPosition(35, 12);
                Console.WriteLine("GAME OVER");
                //textSaver.WriteLine("Acá va a ir el highscore. Testeando"); //Test de puntuacion
                //scoreSaver.Write(theScore.getHighScore());
                //textSaver.Close();
                //data.Close();
                where.x = zero.getX();
                where.y = zero.getY();
                using (playerPosData = File.OpenWrite("PlayerPosData.txt"))
                {
                    formatter.Serialize(playerPosData, where); // it stops here and says "it can't be modified" the second time
                }
                playerPosData.Close();
                Console.ReadKey();
            }
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