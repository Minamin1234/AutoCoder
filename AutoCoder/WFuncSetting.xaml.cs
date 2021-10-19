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
    /// WFuncSetting.xaml の相互作用ロジック
    /// </summary>
    public partial class WFuncSetting : Window
    {
        public MainWindow WHandler;
        public WFuncSetting()
        {
            InitializeComponent();
        }

        public WFuncSetting(MainWindow Handler)
        {
            WHandler = Handler;
            this.Show();
        }
    }
}
