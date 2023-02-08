using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroid
{
    internal class Star: BaseObject
    {
        static Image img = Image.FromFile(@"img\star.png");


        public Star(Point pos, Point dir) : base(pos, dir, new Size(img.Width, img.Height))
        {

        }

        public override void Draw() //полиморфный
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }
    }
}
