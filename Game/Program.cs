using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu theMenu = new Menu();
            Game theGame = new Game();
            while(theMenu.MoveAndChoose() == true)
            {
                theGame.Run();
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}