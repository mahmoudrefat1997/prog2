using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{

 

    class Program
    { 
        
        static void Main(string[] args)
        {// starting program setup
            try { 
            LinkedList<student> l = new LinkedList<student>();
                TextReader str = new StreamReader("students.txt");
            string line;
            while ((line = str.ReadLine()) != null)
            {
                student bu = new student();
             string[] e=   line.Split(',');
                bu.setname(e[0]);
                bu.setmajor(e[3]);
                bu.setemail(e[1]);
                bu.setgender(e[4]);
                bu.setnumber(e[2]);
                l.AddLast(bu);
            }
            str.Close();
            TextWriter stw = new StreamWriter("students.txt", false);
            //program setup ended here, start the testing

            while (true) {
                int flag2 =0;
            Console.WriteLine("please enter 1 to add students, 2 to change a student's name, 3 to change a student's email , 4 to change a student's major , 5 to change a student's number , 6 to save and exit");

            int x = int.Parse(Console.ReadLine());
                updatestudent sup = new updatestudent();
            switch (x)
            {
                case  1:
                    Console.WriteLine("enter name, email, number, major and gender");
                 string   name1=(Console.ReadLine());
                    string email1 =(Console.ReadLine());
                    string number1 =(Console.ReadLine());
                    string major1 =(Console.ReadLine());
                    string gender1 =(Console.ReadLine());
                    student snew = new student(name1, email1, number1, major1, gender1);
                        l.AddLast(snew);
                    break;
                    case 2:
                        sup.changename(l);
                        break;

                    case 3:
                        sup.changemail(l);
                        break;

                    case 4:
                        sup.changemajor(l);
                        break;

                    case 5:
                        sup.changnumber(l);
                        break;

                    case 6:
                        flag2 = 1;
                        break;
                        case 7:
                            sup.deletestudent(l);
                            //added delete later so no console promotion
                            break;
                    }

                if (flag2 == 1) break;
            }
            //  Program testing ended here 
            Console.WriteLine("saving");
           
            WriteStudentData fwr = new WriteStudentData((StreamWriter) stw, l);
            fwr.write();
            stw.Close();
            }catch(Exception we) { Console.WriteLine(we.StackTrace); }
        }
    }
}
