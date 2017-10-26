using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{//takes a number and a bit position and tells if it's a zero or one
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("please enter a number (between 2147483647 and -2147483648)");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter the bit position (between 1 and 32)");
                int b = (int.Parse(Console.ReadLine()) % 33) - 1;
                int mask = (int)(Math.Pow(2, b));
                string bitrep = Convert.ToString(x, 2);
                Console.WriteLine("number in binary is " + bitrep);
                if (mask == (mask & x))
                {
                    
                    Console.WriteLine("the position {0} is a 1", b + 1);
                }
                else
                {
                    
                    Console.WriteLine("the position {0} is a 0", b + 1);
                }
            }
        }
    }
}
