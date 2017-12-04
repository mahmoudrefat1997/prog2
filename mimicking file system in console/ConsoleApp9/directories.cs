using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class directories : Idirectories
    {
        directories parent = null;
        public string name = "";
         LinkedList<Ifilesystem> contents = new LinkedList<Ifilesystem>();
        private DateTime dateoflastchange;

    public  void append(Ifilesystem i)
        {
            contents.AddLast(i);

        }
        public void moveto(ref directories d)
        {
            parent = d;
            d.append(this);

        }

        void setname(string s)
        {
            name = s;
            dateoflastchange = DateTime.Now;

        }

        public LinkedList<Ifilesystem> getcontents()
        {
            Console.WriteLine("the contents of this directory : "  );
        foreach(Ifilesystem i in contents)
            {
                Console.Write(i.retname() +"\n");
            
            }
            return contents ;
            throw new NotImplementedException();
        }
        public string retname()
        {
            return name;

            throw new NotImplementedException();
        }
        public string getname()
        { Console.WriteLine("directory name is {0}", name);
            return name;

            throw new NotImplementedException();
        }

        public DateTime getdateoflastchange()
        {
            Console.WriteLine("last date of change is {0}", dateoflastchange);
            return dateoflastchange;
            throw new NotImplementedException();
        }

        public directories(string n, directories p)
        {
            name = n;
            parent = p;
        }

        public directories(string n)
        {
            name = n;
        }


    }
}
