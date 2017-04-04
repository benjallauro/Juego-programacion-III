using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Enemy
    {
        Random directionMarker = new Random();
        private int x;
        private int y;
        private bool goingLeft = true;
        private bool goingDown = true;

        public Enemy(int _x, int _y)
        {
            x = _x;
            y = _y;
            if (directionMarker.Next(0, 100) >= 50)
                goingLeft = false;
            if (directionMarker.Next(0, 100) >= 50)
                goingDown = false;
        }
        public void Move()
        {
            if (goingLeft == true)
                x--;
            else
                x++;
            if (goingDown == true)
                y++;
            else
                y--;
            CheckAndSwitchPosition();
        }
        public bool searchAndKill(int playerPosX, int playerPosY)
        {
            if (x == playerPosX && y == playerPosY)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("I KILLED YOU!");
                return true;
            }
            return false;
        }
        private void CheckAndSwitchPosition()
        {
            if (x <= 0)
                x = 78;
            else if (x >= 79)
                x = 1;
            if (y <= 0)
                y = 22;
            else if (y >= 23)
                y = 1;
        }
        public void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("+");
        }
    }
}
