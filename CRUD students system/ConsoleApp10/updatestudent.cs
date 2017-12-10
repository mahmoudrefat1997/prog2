using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class updatestudent
    {
        /*  static string name;
          updatestudent() {
              Console.WriteLine("please enter the student's name");
           string name = Console.ReadLine();
          }*/
        public void deletestudent(LinkedList<student> names)
        {

            Console.WriteLine("please enter the student's name you want to delete");
            string name = Console.ReadLine();

            int flag = 0;
            foreach (student name1 in names.ToArray())
            {
               
                if (name == name1.getname())
                {
                    names.Remove(name1) ;
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("student not found");
            }
        }

        
      public  void changemajor(LinkedList<student> names)
        {
            {
                Console.WriteLine("please enter the student's name");
                string name = Console.ReadLine();
                Console.WriteLine("please enter the student's new major");
                string major = Console.ReadLine();
                int flag = 0;
                foreach (student name1 in names)
                {

                    if (name == name1.getname())
                    {
                        name1.setmajor(major);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("student not found");
                }
            }
        }
        public void changemail(LinkedList<student> names)
        {
            {
                Console.WriteLine("please enter the student's name");
                string name = Console.ReadLine();
                Console.WriteLine("please enter the student's new email");
                string email = Console.ReadLine();
                int flag = 0;
                foreach (student name1 in names)
                {

                    if (name == name1.getname())
                    {
                        name1.setemail(email);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("student not found");
                }
            }
        }
        public void changnumber(LinkedList<student> names)
        {
            {
                Console.WriteLine("please enter the student's name");
                string name = Console.ReadLine();
                Console.WriteLine("please enter the student's new number");
                string number = Console.ReadLine();
                int flag = 0;
                foreach (student name1 in names)
                {

                    if (name == name1.getname())
                    {
                        name1.setnumber(number);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("student not found");
                }
            }
        }
        public void changename(LinkedList<student> names)
        {
            {
                Console.WriteLine("please enter the student's old name");
                string name = Console.ReadLine();
                Console.WriteLine("please enter the student's new name");
                string namen = Console.ReadLine();
                int flag = 0;
                foreach (student name1 in names)
                {

                    if (name == name1.getname())
                    {
                        name1.setname(namen);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("student not found");
                }
            }
        }
      /*  updatestudent(student student1)
        {

            s = student1;

        }
        
        student s;*/
       /* public void changemajor(string nn)
        {
            s.setmajor(nn);

        }
        public void changegender(string nn)
        {
            s.setgender(nn);

        }
        public void changnuumber(string nn)
        {
            s.setnumber(nn);

        }
        public void changeemail(string nn)
        {
            s.setemail(nn);

        }
        public void changename(string nn)
        {
            s.setname(nn);
           
        }*/
    }
}
