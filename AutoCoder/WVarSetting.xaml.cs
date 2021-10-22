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
    public partial class CodeBox
    {
        public string Title = "";
        public string SubTitle = "";
        public CodeBox(string a,string b)
        {
            this.Title = a;
            this.SubTitle = b;
        }

        public override string ToString()
        {
            return this.Title + "-" + this.SubTitle;
        }
    }
    /// <summary>
    /// WVarSetting.xaml の相互作用ロジック
    /// </summary>
    public partial class WVarSetting : Window
    {
        public MainWindow WHandler;
        public ObservableCollection<CodeBox> CodeList;
        public WVarSetting()
        {
            InitializeComponent();
            this.Init();
        }

        public WVarSetting(MainWindow Handler)
        {
            InitializeComponent();
            this.Init();
            WHandler = Handler;
            this.Show();
        }

        public bool Init()
        {
            var item = new CodeBox("Setting", "Value");
            CodeList = new ObservableCollection<CodeBox>();
            CodeList.Add(item);
            LB_list.ItemsSource = CodeList;

            return true;
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            Button BCurrent = (Button)sender;

            switch(BCurrent.Name)
            {
                case "B_ok":
                    this.Close();
                    this.WHandler.W_VarSetting = null;
                    break;

                case "B_cancel":
                    break;

                default:
                    break;
            }
        }
    }
}
