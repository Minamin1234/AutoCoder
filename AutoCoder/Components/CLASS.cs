using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoder
{
    public class CLASS : ACObject
    {
        public string ClassName = "Class";
        public CLASS() { }
        public override string ToString()
        {
            return this.ClassName;
        }
    }
}
