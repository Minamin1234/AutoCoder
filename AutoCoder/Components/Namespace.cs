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
        public string Name = "Nmsp";
        public List<Namespace> Namespaces = new List<Namespace>();
        public Namespace()
        {

        }

        public Namespace(string name, IEnumerable<Namespace> Nmsps)
        {
            this.Name = name;
            foreach (var itm in Nmsps)
            {
                if (itm == null) throw new Error("new Namespace():名前空間のリスト内にnullが含まれています。");
                this.Namespaces.Add(itm);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
