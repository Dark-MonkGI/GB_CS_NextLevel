using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // создали форму
            Form form= new Form();
            form.Width = 800;
            form.Height = 600;
            form.MaximumSize = new Size(800, 600);
            form.MinimumSize = new Size(800, 600);
            form.Text = "Space asteroid";  

            if (File.Exists(@"asteroid.ico"))  
                form.Icon = new Icon(@"asteroid.ico");

            form.Show();

            //---------


            Game.Init(form);
            //Game.Draw();

            //0:45

            Application.Run(form);
        }
    }
}
