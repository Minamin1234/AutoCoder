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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.ObjectModel;

namespace AutoCoder
{
    public class Namespace
    {
        public string Name = "Nmsp";
        public Namespace()
        {

        }

        public override string ToString()
        {
            return this.Name;
        }
    }


    public partial class MainWindow : Window
    {
        public Namespace[] Namespaces = new Namespace[0];
        public Namespace CNamespace = null;

        public MainWindow()
        {
            InitializeComponent();

            var nlist = new ObservableCollection<Namespace>();
            foreach (var itm in this.Namespaces)
            {
                nlist.Add(itm);
            }
            this.CB_namespace.ItemsSource = nlist;
        }
    }
}