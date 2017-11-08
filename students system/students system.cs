using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {static void change(ref string[] names, int[] deg)
        {
            {
                Console.WriteLine("please enter the student's old name");
                string name = Console.ReadLine();
                Console.WriteLine("please enter the student's new name");
                string namen = Console.ReadLine();
                int flag = 0;
                foreach (string name1 in names)
                {

                    if (name == name1)
                    {
                        names[Array.IndexOf(names, name1)] = namen;
                        Console.WriteLine("students names and degrees are");
                        foreach (string s1 in names)
                        {
                            Console.WriteLine("<" + s1 + "," + deg[Array.IndexOf(names, s1)] + ">");

                        }
                        Console.Write("\n \n");
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("student not found");
                }
            }
        }
        static void getHighst(string[] names, int[] deg)
        {
           
            Console.WriteLine("the student's name is {0} " , names[Array.IndexOf(deg, deg.Max())] );
            Console.WriteLine("the student's degree is {0} ", deg.Max());
        }
         static void getDeg(string[] names , int[] deg)
        {
            {
                Console.WriteLine("please enter the student's name");
                string name = Console.ReadLine();
                int flag = 0;
                foreach (string name1 in names)
                {
                    
                    if (name == name1)
                    {
                        Console.WriteLine("student degree is {0} ", deg[Array.IndexOf(names,name1)]);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("student not found");
                }
            }

        }
        static void Main(string[] args)
        {
           
                
                //  Console.WriteLine("please enter 1 to add students, 2 to show top student, 3 to change a student's name");
                Console.WriteLine("enter the number of students");

            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
           
                string[] names = new string[num];
                int[] deg = new int[num];
                for (int i = 1; i<= num; i++)
                {
                    Console.WriteLine("please enter student no {0} name", i);
                    names[i - 1] = Console.ReadLine();
                    Console.WriteLine("please enter student no {0} degree", i);
                
                
                    try
                    {
                        deg[i - 1] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e) { Console.WriteLine("not a valid input degree will be considered 0 " );
                    deg[i - 1] = 0;
                };
                
                }
            Console.WriteLine("students names and degrees are");
            foreach(string s1 in names)
            {
                Console.WriteLine("<"+s1 + "," + deg[Array.IndexOf(names,s1)]+ ">");

            }
                Console.Write("\n \n");
            while (true)
            {

                Console.WriteLine("choose an option from the following menu \n [1] search for student degree \n [2] get top student name and degree \n [3] change a student's name \n please enter your choice ");
                int ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1) { getDeg(names, deg); }
                if (ch == 2) { getHighst(names, deg); }
                if (ch == 3) { change(ref names , deg); }
                if ((ch != 3)&& (ch != 2) && (ch != 1) ) { Console.WriteLine("wrong input"); }


            }
            }
            catch (Exception a)
            {
                Console.WriteLine("not a valid naumber, program will restart");
                string[] aa = { "a", "b" };
                Main(aa);
            }
        }
    }
}
