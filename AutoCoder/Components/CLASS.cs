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
        public EAccessLevel AccessLevel = EAccessLevel.PUBLIC;
        public bool IsStatic = false;
        public CLASS Parent = null;
        public List<Interface> Interfaces = new List<Interface>();
        public List<CLASS> Classes = new List<CLASS>();
        public CLASS() { }
        public override string ToString()
        {
            return this.ClassName;
        }
    }
}
