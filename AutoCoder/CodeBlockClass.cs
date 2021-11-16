using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoder
{
    public class ACObject
    {
        public string Name = "ACObject";

        public ACObject() { }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
