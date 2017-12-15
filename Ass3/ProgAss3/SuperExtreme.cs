using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAss3
{
     abstract class SuperExtreme                    //super class
    {
         protected string Name;

         public SuperExtreme()                      //constructor
         {
         }

         public string name
         {
             get { return Name; }
             set { Name = value; }
         }
    }
}
