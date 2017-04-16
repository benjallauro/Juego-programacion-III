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
                playerPosData = File.OpenRead("PlayerPosData.txt");
                where = (Position)formatter.Deserialize(playerPosData);
            }
            Menu theMenu = new Menu();
            if(theMenu.MoveAndChoose() == true)
            {
                Score theScore = new Game.Score();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Red;
                Random rand = new Random();
                Player zero = new Player(where.x, where.y);
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
                            zero.death();
                    }
                    theScore.scoreUp();
                    if (theScore.getScoreNumber() > theScore.getHighScore())
                        theScore.setHighScore(theScore.getScoreNumber());
                    theScore.Draw();
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
                formatter.Serialize(playerPosData, where);
                playerPosData.Close();
                Console.ReadKey();
            }
        }
    }
}