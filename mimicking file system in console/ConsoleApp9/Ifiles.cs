using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    interface Ifiles: Ifilesystem
    {
       object getcontent();
        string getname();
        DateTime getdateofcreation();
        DateTime getdateoflastchange();
    }
}
