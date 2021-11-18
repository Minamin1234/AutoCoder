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

namespace AutoCoder
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public ACObject[] Nmsp = { new ACObject()};
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                var nwitm = new ACObject();
                Manager.AddCtnt(ref this.Nmsp, nwitm);
            }
            this.CB_namespace.ItemsSource = Manager.GetItmSrc(this.Nmsp);

            foreach(var itm in this.Nmsp)
            {
                Console.WriteLine(itm.Name);
            }
        }
    }
}