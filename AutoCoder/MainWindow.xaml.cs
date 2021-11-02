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
        public ComboBoxItem[] list = {new ComboBoxItem()};
        public MainWindow()
        {
            InitializeComponent();
            
            for(int i = 0;i < 10;i++)
            {
                Array.Resize(ref list, list.Length + 1);
                this.list[i] = new ComboBoxItem();
                this.list[i].Content = "A";
            }
            this.Add();
        }

        public void Add()
        {
            foreach(ComboBoxItem CBI in this.list)
            {
                Console.WriteLine(CBI);
                this.CB_namespace.Items.Add(CBI);
            }
        }
    }
}
