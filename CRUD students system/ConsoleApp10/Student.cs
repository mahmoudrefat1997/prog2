using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{

    public class student : IData
    {
       
            
                public student() { }



        public student( string name1, string email1, string number1, string major1, string gender1)
        {
            this.name = name1;
            this.major = major1;
            this.email = email1;
            this.number = number1;
            this.gender = gender1;

        }
        int id;
        string email = "";
        string name = "";
        string number = "";
        string major = "";
        string gender = "";
        public void setgender(string q)
        {
            gender = q;
        }
        public void setmajor(string q)
        {
            major = q;
        }
        public void setnumber(string q)
        {
            number = q;
        }
        public void setemail(string q)
        {
            email = q;
        }
        public void setname(string q)
        {
            name = q;
        }


        public string getemail()
        {
            return email;
            throw new NotImplementedException();
        }

        public string getgender()
        {
            return gender;

            throw new NotImplementedException();
        }

        public string getmajor()
        {
            return major;

            throw new NotImplementedException();
        }

        public string getname()
        {
            return name;

            throw new NotImplementedException();
        }

        public string getnumber()
        {
            return number;

            throw new NotImplementedException();
        }
    }

}
