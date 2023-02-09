namespace WithExampleInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TableFun tableFun = new TableFun();

            TableFun a = new SinFun();

            IFunc funcInterface = new SinFun();
            double result = funcInterface.CalculateFunc(0.5);

            Console.WriteLine("Таблица функции Sin:");
            a.Table(-2, 2, 0.1, funcInterface); //Так


            a = new SimpleFun();
            Console.WriteLine("Таблица функции Simple:");
            a.Table(0, 3, 0.5, (IFunc)a); // Или так
        }
    }

    interface IFunc
    {
        double CalculateFunc(double x);
    }

    abstract class TableFun
    {


        public void Table(double a, double b, double h, IFunc func)
        {
            Console.WriteLine("----- X ----- Y -----");

            double x = a;

            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, func.CalculateFunc(x));
                x += h;
            }

            Console.WriteLine("---------------------");
        }
    }

    class SimpleFun : TableFun, IFunc, ICloneable, IComparable
    {


        public double CalculateFunc(double x)
        {
            return x * x;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }
    }

    class SinFun : TableFun, IFunc
    {
        public double CalculateFunc(double x)
        {
            return Math.Sin(x);
        }
    }
}