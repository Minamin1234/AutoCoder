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
    /// <summary>
    /// NmspManagerWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class NmspManagerWindow : Window,IDataEditing
    {
        public WindowManager WinManager;
        public MainWindow WHander = null;
        public Window SubWindow = null;
        public SourceFile CurrentFile = null;
        public NmspManagerWindow()
        {
            InitializeComponent();
            this.Initialize();
        }
        public NmspManagerWindow(ref SourceFile TargetFile,MainWindow whandler)
        {
            InitializeComponent();
            this.Initialize();
        }

        public bool Initialize()
        {
            this.WinManager = new WindowManager(this);
            return true;
        }

        public bool CommitData(EDITPROPERTY editproperty)
        {
            return true;
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var CurentButton = (Button)sender;
            if(CurentButton.Name == B_Add.Name)
            {

            }
        }
    }
}
