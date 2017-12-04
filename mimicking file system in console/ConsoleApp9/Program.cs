using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] con = { Convert.ToByte('f') , Convert.ToByte(5) };
            files f = new files("asdf", "qwef");
           files fi = new files("hghgh" , con);
           directories d = new directories("newfolder");
           directories dd = new directories("newfolder(2)", d);
           devices w = new devices();

            w.setname("usb");
            //testing files class
            f.getcontent();
            f.getdateofcreation();
            f.getdateoflastchange();
            f.setname("hjkgh");
            f.getdateoflastchange();
            f.setcontents(con);
            f.getcontent();
            fi.getcontent();
            // testing directories class
            d.getname();
            d.getcontents();
            dd.getcontents();
            d.moveto(ref dd);
            dd.append(f);
            dd.getcontents();
            d.getcontents();
            // testing devices
            w.usedevice();
            while (true) { }

        }
    }
}
