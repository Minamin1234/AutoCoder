using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace AutoCoder
{
    public class NamespaceManager
    {
        public MainWindow WHandler;
        public NamespaceBox[] Namespaces = { new NamespaceBox() };

        public NamespaceManager()
        {

        }

        public NamespaceManager(MainWindow WHandle)
        {
            this.WHandler = WHandle;
        }

        public bool AddNamespace(NamespaceBox NewNmspBX)
        {
            foreach(NamespaceBox NmspBX in this.Namespaces)
            {
                if (NmspBX.Name == NewNmspBX.Name) return false;
            }
            this.Namespaces.Append(NewNmspBX);
            return true;
        }

        public ObservableCollection<NamespaceBox> GetNmspList()
        {
            var list = new ObservableCollection<NamespaceBox>();
            foreach(NamespaceBox NmspBox in this.Namespaces)
            {
                list.Add(NmspBox);
            }
            return list;
        }
    }
}
