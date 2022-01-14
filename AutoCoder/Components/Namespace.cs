using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Collections.ObjectModel;

namespace AutoCoder
{
    /// <summary>
    /// ソースファイル内の名前空間要素
    /// </summary>
    public class Namespace : ACObject
    {
        public string NamespaceName
        {
            get { return this.Name == "ACObject" ? "Nmsp" : this.Name; }
            set { this.Name = value; }
        }
        public List<Namespace> Namespaces = new List<Namespace>();
        public List<CLASS> Classes = new List<CLASS>();
        public Namespace()
        {
        }

        public Namespace(string name)
        {
            this.NamespaceName = name;
            this.Namespaces.Add(new Namespace());
        }

        public Namespace(string name, IEnumerable<Namespace> Nmsps)
        {
            this.NamespaceName = name;
            foreach (var itm in Nmsps)
            {
                if (itm == null) throw new Error("new Namespace():名前空間のリスト内にnullが含まれています。");
                this.Namespaces.Add(itm);
            }
        }

        public Namespace(string name,IEnumerable<Namespace> Nmsps,IEnumerable<CLASS> Clses)
        {
            if (Nmsps == null || Clses == null) throw new ArgumentNullException();
            this.NamespaceName = name;
            this.Namespaces = new List<Namespace>(Nmsps);
            this.Classes = new List<CLASS>(Clses);
        }

        public override string ToString()
        {
            return this.NamespaceName;
        }
    }
}
