using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroid
{
    internal abstract class BaseObject
    {
        protected Point Pos { get; set; } // авто св-во
        protected Point Dir { get; set; }
        protected Size Size { get; set; }

        public BaseObject(Point pos, Point dir,  Size size)
        {
            this.Pos = pos;
            this.Dir = dir;
            this.Size = size;
        }

        public abstract void Draw();


        public void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y); //сдвигаем обьект
            //Pos.Offset(Dir);

            if (Pos.X < 0 || Pos.X > Game.Width) 
                Dir = new Point(-Dir.X, Dir.Y);

            if (Pos.Y < 0 || Pos.Y > Game.Height) 
                Dir = new Point(Dir.X, -Dir.Y);
        }

    }
}
