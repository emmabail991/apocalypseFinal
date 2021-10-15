using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace froggerProject
{
    class Box
    {
        public int x, y, size, speed;
        public SolidBrush brushColour;

        public Box(int _x, int _y, int _size, int _speed, SolidBrush _brushColor)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            brushColour = _brushColor;
        }

        public void Move()
        {
            x += speed;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= 40;
            }
            else if (direction == "right")
            {
                x += 40;
            }
            if (direction == "up")
            {
                y -= 40;
            }
            else if (direction == "down")
            {
                y += 40;
            }
        }

        public bool Collision(Box b)
        {
            Rectangle thisRec = new Rectangle(x, y, size, size);
            Rectangle boxRec = new Rectangle(b.x, b.y, b.size, b.size);

            if (thisRec.IntersectsWith(boxRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}