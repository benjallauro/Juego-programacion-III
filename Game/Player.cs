using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        private int x;
        private int y;
        private bool alive;
        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
            alive = true;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public void SetX(int _x)
        {
            x = _x;
        }
        public void setY(int _y)
        {
            y = _y;
        }
        public void Moverse(ConsoleKeyInfo command)
        {
            if (command.Key == ConsoleKey.UpArrow && y > 0)
                y--;
            if (command.Key == ConsoleKey.LeftArrow && x > 0)
                x--;
            if (command.Key == ConsoleKey.RightArrow && x < 79)
                x++;
            if (command.Key == ConsoleKey.DownArrow && y < 23)
                y++;

        }
        public void death()
        {
            alive = false;
            Console.Clear();
        }
        public bool CheckLife()
        {
            if (alive == true)
                return true;
            else
                return false;
        }
        public void draw()
        {
            if (alive == true)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("0");
            }
        }
    }
}
