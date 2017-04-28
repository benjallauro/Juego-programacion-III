using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Item
    {
        Random positionRandom = new Random();
        private int x;
        private int y;
        public Item()
        {
            x = positionRandom.Next(0, 79);
            y = positionRandom.Next(0, 23);
        }
        public Item(int _x, int _y)
        {
            x = _x;
            y = _y;
            positionRandom.Next(0, 100);
            positionRandom.Next(0, 100);
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public void draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("$");
        }
        public void Respawn()
        {
            x = positionRandom.Next(0, 79);
            y = positionRandom.Next(0, 23);
        }
    }
}
