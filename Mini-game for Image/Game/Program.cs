using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Player zero = new Player(50, 20);
            Bomb[] mines = new Bomb[5];
            for (int i = 0; i < mines.Length; i++)
                mines[i] = new Bomb(rand.Next(0, 79), rand.Next(0, 23));
            Console.SetCursorPosition(35, 12);
            Console.WriteLine("GAME START!");
            while (zero.CheckLife() == true)
            {
                zero.draw();
                ConsoleKeyInfo controls = Console.ReadKey();
                zero.Moverse(controls);
                Console.Clear();
                for (int i = 0; i < mines.Length; i++)
                { 
                    mines[i].Draw();
                    if (mines[i].Sense(zero.getX(), zero.getY()))
                        zero.death();
                }
            }
            Console.SetCursorPosition(35, 12);
            Console.WriteLine("GAME OVER");
            Console.ReadKey();
        }
    }
}
