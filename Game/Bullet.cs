using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bullet
    {
        private int posX;
        private int posY;
        private string direction;
        public Bullet(int _posX, int _posY, ConsoleKey directionKey)
        {
            posX = _posX;
            posY = _posY;
            switch (directionKey)
            {
                case ConsoleKey.UpArrow:
                    direction = "up";
                    break;
                case ConsoleKey.DownArrow:
                    direction = "down";
                    break;
                case ConsoleKey.LeftArrow:
                    direction = "left";
                    break;
                case ConsoleKey.RightArrow:
                    direction = "right";
                    break;
                default:
                    direction = "right";
                    break;
            }      
        }
        public void Update()
        {
            Move();
            Draw();
        }
        private void Move()
        {
            switch (direction)
            {
                case "right":
                    posX++;
                    break;
                case "left":
                    posX--;
                    break;
                case "up":
                    posY--;
                    break;
                case "down":
                    posY++;
                    break;
                default:
                    break;
            }
        }
        private void Draw()
        {
            if (posX > 0 && posX < Console.WindowWidth && posY > 0 && posY < Console.WindowHeight)
            {
                Console.SetCursorPosition(posX, posY);
                if (direction == "left" || direction == "right")
                    Console.WriteLine("-");
                else
                    Console.WriteLine("|");
            }
        }
        public int GetPosX()
        {
            return posX;
        }
        public int GetPosY()
        {
            return posY;
        }
    }
}
