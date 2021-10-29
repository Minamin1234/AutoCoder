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
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        //Window
        public WVarSetting W_VarSetting;
        public WFuncSetting W_FuncSetting;
        public WClassSetting W_ClassSetting;
        public WNamespaceSetting W_NamespaceSetting;

        //BlocksManager
        public NamespaceBox CurrentNamespaceBox;
        public NamespaceBox[] Namespaces;
        public FunctionBox CurrentFunctionBox;
        public MainFunctionBox MainFunction;
        public SourceBox CurrentSourceBox;

        //BoxManagers
        public NamespaceManager NmspMng;

        public ObservableCollection<NamespaceBox> CItems;
        public MainWindow()
        {
            InitializeComponent();
            this.CItems = new ObservableCollection<NamespaceBox>();
            foreach(NamespaceBox o in Namespaces)
            {
                this.CItems.Add(o);
            }
            this.CB_currentnamespace.ItemsSource = this.CItems;
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
            this.W_VarSetting = new WVarSetting(this);
            return true;
        }

        public bool AddExec()
        {

            return true;
        }

        public bool OpenFuncManager()
        {
            this.W_FuncSetting = new WFuncSetting(this);
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
            if(BCurrent.Name == B_New.Name)
            {
                this.New();
            }
            else if(BCurrent.Name == B_Save.Name)
            {
                this.Save();
            }
            else if(BCurrent.Name == B_Load.Name)
            {
                this.Load();
            }

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

        private void CB_Closed(object sender, ContextMenuEventArgs e)
        {
            ComboBox current = (ComboBox)sender;
            
            if(current.Name == CB_currentfunc.Name)
            {

            }
            else if(current.Name == CB_currentnamespace.Name)
            {
                this.CurrentNamespaceBox = this.NmspMng.Namespaces[current.SelectedIndex];
            }

        }

        private void CB_Opened(object sender, ContextMenuEventArgs e)
        {
            ComboBox current = (ComboBox)sender;

            if(current.Name == CB_currentfunc.Name)
            {
                
            }
            else if(current.Name == CB_currentnamespace.Name)
            {
                var NmspList = this.NmspMng.GetNmspList();
                CB_currentnamespace.ItemsSource = NmspList;
            }
        }
    }
}
