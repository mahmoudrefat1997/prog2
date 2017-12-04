using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class devices : Idevices
    {
        public devices()
        {

        }
        public devices(string s )
        {
            name = s;

        }
        string name = " default name " ;

        public void setname(string s)
        {
            name = s;
        }
        public void usedevice()
        {
            Console.WriteLine("the device {0} is being used", name);

        }
    }
}
