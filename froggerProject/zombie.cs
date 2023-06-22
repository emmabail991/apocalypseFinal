using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace froggerProject
{
    class zombie
    {
        public int x, y, size, speed;
        public SolidBrush brushColour;
        


        public zombie(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            
        }

        public void MoveRight()
        {
            x += speed;
        }

        public void MoveLeft()
        {
            x -= speed;
        }






        public void Move(string direction)
        {
            if (direction == "left")
            {
                x -= 4;
            }
            else if (direction == "right")
            {
                x += 4;
            }
            
        }

        public bool Collision(zombie b)
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
