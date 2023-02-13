using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroid
{
    internal class GameException: Exception
    {
        public GameException() 
        {
            Console.WriteLine(base.Message);
        }

        public GameException(string message): base(message)
        {

        }
    }
}
