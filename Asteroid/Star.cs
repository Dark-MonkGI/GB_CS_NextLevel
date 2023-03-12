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
            Game.Buffer.Graphics.DrawImage(img, Pos);            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
    }


    #region class Planet
    internal class Planet : Star
    {
        Image img;

        public Planet(Point pos, Point dir, string imgFilename) : base(pos, dir)
        {
            img = Image.FromFile(imgFilename);
            Size = new Size(img.Width, img.Height);
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);            
        }
    }
    #endregion

    #region class Bullet
    internal class Bullet : Star
    {
        public static event Action<Bullet> Hide; // событие

        Image img;
        public bool CanFire { get; private set; } = true;

        public Bullet(Point pos, Point dir, string imgFilename) : base(pos, dir)
        {
            img = Image.FromFile(imgFilename);
            Size = new Size(img.Width, img.Height);
        }

        public override void Draw() 
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);    
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y);
            if (Pos.X > Game.Width)
            {
                Hide(this);
                CanFire = true;
                //Pos = new Point(0, Game.Random.Next(0, Game.Height));
            }

        }

        public void Fire(Point pos, Point dir)
        {
            CanFire = false;
            Pos = pos;
            Dir = dir;
        }
    }
    #endregion

    #region class Ship
    internal class Ship : Star
    {
        Image img;
        public Ship(Point pos, Point dir, string imgFilename) : base(pos, dir)
        {
            img = Image.FromFile(imgFilename);
            Size = new Size(img.Width, img.Height);
        }

        public override void Update()
        {
            Pos = new Point(Pos.X + Dir.X, Pos.Y + Dir.Y);
        }

        public void Up()
        {
            Dir = new Point(Dir.X, -Math.Abs(Dir.Y));
        }
        public void Down()
        {
            Dir = new Point(Dir.X, Math.Abs(Dir.Y));
        }

        public void Left()
        {
            Dir = new Point(-Math.Abs(Dir.X), Dir.Y);
        }
        public void Right()
        {
            Dir = new Point(Math.Abs(Dir.X), Dir.Y);
        }

        public override void Draw()//полиморфизм
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }


    } 
    #endregion
}
