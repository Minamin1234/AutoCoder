using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoder
{
    public class Interface : ACObject
    {
        public string InterfaceName
        {
            get { return this.Name == "ACObject" ? "interface" : this.Name; }
            set { this.Name = value; }
        }

        public override string ToString()
        {
            return this.InterfaceName;
        }
    }
}
