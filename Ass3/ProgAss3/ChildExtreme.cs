using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgAss3
{
    sealed class ChildExtreme : SuperExtreme
    {
        private string Password;
        public ChildExtreme()
        {
        }

        public ChildExtreme(string name, string pass)
        {
            Name = name;
            Password = pass;
        }

        public string Pass
        {
            get { return Password; }
            set { Password = value; }
        }
    }
}
