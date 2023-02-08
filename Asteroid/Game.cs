using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroid
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;


        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static public Random Random { get; set; } = new Random();

        static int Frames = 0;
        static int xBackground = 800;
        static BaseObject[] _obj;
        static Star star;
        //static Bullet bullet;
        //private static Ship ship;

        static Game()
        {

        }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics graphics;

            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics();


            // Создаем объект (поверхность рисования) и связываем его с формой
            // Задаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;


            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(graphics, new Rectangle(0, 0, Width, Height));


            Load();
            //form.KeyDown += Form_KeyDown;

            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        //private static void Form_KeyDown(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Left:
        //            ship.Left();
        //            break;
        //        case Keys.Down:
        //            ship.Down();
        //            break;
        //        case Keys.Up:
        //            ship.Up();
        //            break;
        //        case Keys.Right:
        //            ship.Right();
        //            break;
        //        case Keys.Space:
        //            if (bullet.CanFire)
        //                bullet.Fire(new Point(ship.Rect.X + 40, ship.Rect.Y), new Point(5, 0));
        //            break;


        //    }
        //}

        public static void Load()
        {
            _obj = new BaseObject[20];

            for (int i = 0; i < _obj.Length / 2; i++)
                _obj[i] = new BaseObject(new Point(Game.Width - 10 * i, Game.Height - 10 * i), new Point(i * 2, i * 3), new Size(20, 20));
            //_obj[i] = new Planet(new Point(Game.Width - 10 * i, Game.Height - 10 * i), new Point(i * 2, i * 3), "pictures\\planet.bmp");

            for (int i = _obj.Length / 2; i < _obj.Length; i++)
                _obj[i] = new Star(new Point(Game.Width - 10 * i, Game.Height - 10 * i), new Point(i * 2, i * 3));

            star = new Star(new Point(200, 200), new Point(10, 10));
            //bullet = new Bullet(new Point(-200, 400), new Point(0, 0), "pictures\\bullet.bmp");
            //ship = new Ship(new Point(0, 200), new Point(5, 5), "pictures\\Ship.bmp");
        }

        public static void Draw()
        {
            Frames++;

            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(xBackground, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(xBackground, 100, 200, 200));

            Buffer.Graphics.DrawString($"Frames:{Frames}", SystemFonts.DefaultFont, Brushes.AliceBlue, 600, 0);


            foreach (BaseObject obj in _obj)
                obj?.Draw();
            

            //bullet.Draw();
            //ship.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _obj)
                obj?.Update();

            xBackground -= 10;

            if (xBackground < -200)
                xBackground = 800;


            //for (int i = 0; i < _obj.Length; i++)
            //{
            //    if (_obj[i] != null)
            //    {
            //        _obj[i].Update();
            //        if (_obj[i] is Planet)
            //            if (_obj[i].Collision(bullet))
            //            {
            //                Console.WriteLine("Clash!");
            //                _obj[i] = null;
            //            }
            //    }

            //}
            //bullet.Update();
            //ship.Update();
        }
    }
}
