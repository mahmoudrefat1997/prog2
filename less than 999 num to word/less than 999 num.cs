using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        //takes a number less than 999 and converts it to a written form
        static void Main(string[] args)
        {
            int flag = 0;
            string[] one = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] specials = new string[] { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = new string[] { "", "ten ", "twenty ", "thirty ", "fourty ", "fifty ", "sixty ", "seventy ", "eighty ", "ninety " };
            while (true)
            {
                Console.WriteLine("please enter a number less than 1000");
		
                int i = (int.Parse(Console.ReadLine())) % 1000; //to ensure it's less than 1000
		

                if (i == 0)
                {
                    Console.Write("zero");
                }
                {
                    if (i >= 100)

                    {
                        flag = 1;
                        Console.Write((one[(i / 100)] + " hundred "));
                    }
                    int a = i % 100;
                    if ((a != 0) && (flag == 1)) { Console.Write("and "); }
                    if ((a < 20) && (a > 10))
                    {
                        Console.WriteLine(specials[a - 10] + " ");

                    }
                    else
                    {
                        Console.WriteLine(tens[(a / 10)] + one[(a % 10)]);
                    }
                    flag = 0;
                }
            }
            
        }
    }
    }

