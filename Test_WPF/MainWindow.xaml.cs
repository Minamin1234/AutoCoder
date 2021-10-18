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

namespace Test_WPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public Window W_FuncManage;
        public FuncSetting W_FuncSetting;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Command Events

        public bool New()
        {

            return true;
        }

        public bool Save()
        {

            return true;
        }

        public bool Load()
        {

            return true;
        }

        public bool OpenVarManager()
        {

            return true;
        }

        public bool AddExec()
        {

            return true;
        }

        public bool OpenFuncManager()
        {
            this.W_FuncSetting = new FuncSetting();
            this.W_FuncSetting.Show();
            return true;
        }

        public bool DelExec()
        {

            return true;
        }

        //UI Events
        private void B_Clicked(object sender, RoutedEventArgs e)
        {
            Button BCurrent = (Button)sender;
            switch (BCurrent.Name)
            {
                case "B_New":
                    this.New();
                    break;

                case "B_Save":
                    this.Save();
                    break;

                case "B_Load":
                    this.Load();
                    break;

                case "B_01vm":
                    this.OpenVarManager();
                    break;

                case "B_02ae":
                    this.AddExec();
                    break;

                case "B_03fm":
                    this.OpenFuncManager();
                    break;

                case "B_04de":
                    this.DelExec();
                    break;

                default:
                    break;
            }
        }
    }
}
