using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Bomb
    {
        private int x;
        private int y;
        Random r = new Random();
        public Bomb()
        {
            x = r.Next(0, 79);
            y = r.Next(0, 23);
        }
        public Bomb(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        ~Bomb() { }
       /* public void setPosition(int _x, int _y)
        {
            x = _x;
            y = _y;
        }*/
        public void Explode()
        {
            Console.WriteLine("BOOM!!!");
            //PREGUNTAR COMO LLAMAR AL DESTRUCTOR
        }
        public bool Sense(int playerX, int PlayerY)
        {
            if(x == playerX && y == PlayerY)
            {
                Explode();
                return true;
            }
            return false;
        }
        public void Draw()
        {
            //while (2 < 3)
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine("X");
                //TEMPORAL
                //y--;
                //if (y <= 0)
                //   y = 25;
            }
        }
    }
}