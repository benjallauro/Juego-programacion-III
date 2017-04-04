using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Menu
    {
        private int cursorX = 33;
        private int cursorY = 12;
        private bool chosen = false;
        public Menu()
        {
        }
        public bool MoveAndChoose()
        {
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
                return true;
            else
                return false;
        }
        public void Draw()
        {
            Console.SetCursorPosition(cursorX, cursorY);
            Console.WriteLine(">");
            
        }
    }
}
