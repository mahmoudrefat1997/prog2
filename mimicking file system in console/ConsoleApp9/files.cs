using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class files : Ifiles
    {
        public string name = "";
      private  byte[] content;
      private string sconten;
        private DateTime dateofcreation;
        private DateTime dateoflastchange;

        public void setcontents(string s)
        {
            content = null;
            sconten = s;
            dateoflastchange = DateTime.Now;
        }
        public void setcontents(byte[] s)
        {
            sconten = null ;
               content = s;
            dateoflastchange = DateTime.Now;
        }

        public void setname(string s )
        {
            name = s;
            dateoflastchange = DateTime.Now;
        }
        public files(string n, Byte[] c)
        {
            name = n;
            content = c;
            dateofcreation = DateTime.Now;
            dateoflastchange = DateTime.Now;
        }
        public files(string n, string c)
        {
            name = n;
            sconten = c;
            dateofcreation = DateTime.Now;

            dateoflastchange = DateTime.Now;
        }


        public object getcontent()
        {

            if(sconten == null) {
                Console.WriteLine("the contents of this file is raw bytes "  );

                return content;
                    }
            else
            {
                Console.WriteLine("the contents of this file : " + sconten);

                return sconten;
            } 

            throw new NotImplementedException();
        }

        public DateTime getdateofcreation()
        {

            Console.WriteLine("date of creation is {0}", dateofcreation);
            return dateofcreation;

            throw new NotImplementedException();
        }

        public DateTime getdateoflastchange()
        {
            Console.WriteLine("last date of change is {0}", dateoflastchange);

            return dateoflastchange;
            throw new NotImplementedException();
        }

        public string getname()
        {
             Console.WriteLine("file name is {0}", name);

                return name;
            throw new NotImplementedException();
        }

        public string retname()
        {
            return name;
            throw new NotImplementedException();
        }
    }
}
