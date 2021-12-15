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
        /// <summary>
        /// 編集用ウィンドウを表示するには編集対象のソースファイルを渡し、
        /// このウィンドウを所有するメインウィンドウを指定します。
        /// </summary>
        /// <param name="TargetFile">編集対象のソースファイルクラス</param>
        /// <param name="whandler">このウィンドウを所有するメインウィンドウ</param>
        /// <exception cref="ArgumentNullException"></exception>
        public NmspManagerWindow(ref SourceFile TargetFile,MainWindow whandler)
        {
            InitializeComponent();
            if (TargetFile == null || whandler == null) throw new ArgumentNullException();
            this.WHander = whandler;
            this.CurrentFile = TargetFile;
            this.Initialize();
        }

        public bool Initialize()
        {
            this.WinManager = new WindowManager(this);
            this.CurrentFile = this.WHander.CurrentFile;
            return true;
        }

        /// <summary>
        /// 新規作成用に編集ウィンドウを開きます。
        /// </summary>
        /// <exception cref="Error">ウィンドウ表示時に何かしらのエラーを返します。</exception>
        public void OpenCreateWindow()
        {
            string FuncName = "OpenCreateWindow:";
            var EditProperty = new EDITPROPERTY(this.CurrentFile.Namespaces);
            if (this.WinManager == null) throw new Error(FuncName + "WinManagerがnullでした");
            if (this.WinManager.IsEditing) throw new Error(FuncName + "編集中です");
            this.WinManager.OpenSetSubWindow(new CreateNmspWindow(this, EditProperty));
        }

        public bool CommitData(EDITPROPERTY editproperty)
        {
            return true;
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.WHander.WinManager.ClearSubWindow();
        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var CurentButton = (Button)sender;
            if(CurentButton.Name == B_Add.Name)
            {
                this.OpenCreateWindow();
            }
        }
    }
}
