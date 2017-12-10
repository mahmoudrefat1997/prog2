using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class WriteStudentData
    {
       public WriteStudentData(StreamWriter w, LinkedList<student> dd)
        {
            ww = w;
            ss = dd;
           
        }
        
        StreamWriter ww;
        LinkedList<student> ss;

        public void write()
        {

            try
            {
                Console.WriteLine("writing data");
                foreach (student d in ss)
                {
                    

                     ww.WriteLine(d.getname() + "," + d.getemail() + "," + d.getnumber() + "," + d.getmajor() + "," + d.getgender());

                }
            }
            catch (Exception e) { Console.WriteLine("an error occured while writing data \n " + e.StackTrace); }




        }



    }
}
