using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Game
{
    class Menu
    {
        private int cursorX = 33;
        private int cursorY = 12;
        private bool chosen = false;
        FileStream textData;
        public Menu()
        {
        }
        public void CreateOrReadText()
        {
            if (!File.Exists("TextData.txt"))
            {
                textData = File.Create("TextData.txt");
                StreamWriter TextWriter = new StreamWriter(textData);
                Console.SetCursorPosition(30, 3);
                Console.WriteLine("Please write your personal message: ");
                Console.SetCursorPosition(34, 15);
                TextWriter.WriteLine(Convert.ToString(Console.ReadLine()));
                TextWriter.Close();
                Console.Clear();
            }
            else
            {
                textData = File.OpenRead("TextData.txt");
                StreamReader textReader = new StreamReader(textData);
                Console.SetCursorPosition(30, 0);
                Console.WriteLine(textReader.ReadLine());
                textReader.Close();
            }
            textData.Close();
        }
        public bool MoveAndChoose()
        {
            CreateOrReadText();
            Console.SetCursorPosition(cursorX, cursorY);
            Draw();
            while(chosen == false)
            {
                Console.SetCursorPosition(33, 9);
                Console.WriteLine("CONSOLE MANIA");
                Console.SetCursorPosition(35, 11);
                Console.WriteLine("Choose an option");
                Console.SetCursorPosition(35, 12);
                Console.WriteLine("Play");
                Console.SetCursorPosition(35, 13);
                Console.WriteLine("Quit");
                ConsoleKeyInfo cursorControls = Console.ReadKey();
                if (cursorControls.Key == ConsoleKey.UpArrow && cursorY > 12)
                    cursorY--;
                else if (cursorControls.Key == ConsoleKey.DownArrow && cursorY < 13)
                    cursorY++;
                if (cursorControls.Key == ConsoleKey.Enter)
                    chosen = true;

                Console.Clear();
                Draw();
            }
            if (cursorY == 12)
            {
                chosen = false; 
                return true;
            }
            else
            {
                chosen = false;
                return false;
            }
        }
        public void Draw()
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.WriteLine(">");
        }
    }
}
