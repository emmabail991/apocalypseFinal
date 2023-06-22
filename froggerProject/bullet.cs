using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace froggerProject
{
    internal class bullet
    {
        public int width, height, x, y, bulletspeed;

        
        public bullet(int _x, int _y, int _width, int _height, int _speed)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            bulletspeed = _speed;



        }

        public void MoveBulletLeft(int speed)
        {
            x -= speed;
        }
        public void MoveBulletRight(int speed)
        {
            x += speed;
        }

        

    }
}
