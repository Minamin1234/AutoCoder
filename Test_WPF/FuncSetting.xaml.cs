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

namespace Test_WPF
{
    /// <summary>
    /// FuncSetting.xaml の相互作用ロジック
    /// </summary>
    public partial class FuncSetting : Window
    {
        public MainWindow W_Parent;
        public FuncSetting()
        {
            InitializeComponent();
        }

        public FuncSetting(Window Parent)
        {
            InitializeComponent();
        }

        public bool OK()
        {
            this.W_Parent.W_FuncSetting = null;
            this.Close();
            return true;
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            Button BCurrent = (Button)sender;

            switch(BCurrent.Content)
            {
                case "OK":
                    this.Close();
                    break;

                default:
                    break;
            }
        }
    }
}
