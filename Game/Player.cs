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
        private int lives;
        private const int maxLives = 3;
        public Player(int _x, int _y)
        {
            x = _x;
            y = _y;
            alive = true;
            lives = 3;
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
        public int GetLives()
        {
            return lives;
        }
        public void SetLives(int _lives)
        {
            if (_lives <= maxLives)
                lives = _lives;
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
        public void LoseLife()
        {
            if (lives > 0)
                lives--;
        }
    }
}
