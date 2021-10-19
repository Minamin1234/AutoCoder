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
    /// WVarSetting.xaml の相互作用ロジック
    /// </summary>
    public partial class WVarSetting : Window
    {
        public MainWindow WHandler;
        public WVarSetting()
        {
            InitializeComponent();
        }

        public WVarSetting(MainWindow Handler)
        {
            WHandler = Handler;
            this.Show();
        }
    }
}
