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

namespace AutoCoder
{
    /// <summary>
    /// Window_Single.xaml の相互作用ロジック
    /// </summary>
    public partial class Window_Single : Window
    {
        public MainWindow H_Handler;

        public Window_Single()
        {
            InitializeComponent();
        }

        public Window_Single(MainWindow Parent)
        {
            H_Handler = Parent;
        }
    }
}
