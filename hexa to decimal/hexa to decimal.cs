using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nplease enter a number in hexadecimal format");
                String s = Console.ReadLine();
                s.ToLower();
                Program c5 = new Program();
                Console.WriteLine(c5.conv(s));
            }
        }

        ulong conv(string a)
        {
            ulong sum = 0;
            for (int i = a.Length-1; i >=0 ; i--)
            {
                if (a[i].Equals('f')) { sum += (15 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('e')) { sum += (14 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('d')) { sum += (13 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('c')) { sum += (12 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('b')) { sum += (11 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('a')) { sum += (10 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('9')) { sum += (9 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('8')) { sum += (8 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('7')) { sum += (7 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('6')) { sum += (6 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('5')) { sum += (5 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('4')) { sum += (4 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('3')) { sum += (3 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('2')) { sum += (2 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('1')) { sum += (1 * ((ulong)Math.Pow(16, a.Length - 1 - i))); continue; }
                if (a[i].Equals('0')) { sum += (0 * ((ulong)Math.Pow(16, a.Length - 1-i))); continue; }else
                { Console.WriteLine("invalid number ");
                    break;
                }


            }
            return sum;
        }
    }
}
