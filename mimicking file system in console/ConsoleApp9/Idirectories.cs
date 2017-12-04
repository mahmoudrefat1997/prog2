using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    interface Idirectories: Ifilesystem
    {

      LinkedList<Ifilesystem>  getcontents();
        string getname();
        DateTime getdateoflastchange();

    }
}
