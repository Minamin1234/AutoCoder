using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoder
{
    public class CLASS : ACObject
    {
        public string ClassName
        {
            get { return this.Name == "ACObject" ? "CLASS" : this.Name; }
            set { this.Name = value; }
        }
        public List<CLASS> Classes = new List<CLASS>();
        public CLASS() { }
        public override string ToString()
        {
            return this.ClassName;
        }
    }
}
