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
    public partial class NmspManagerWindow : Window,IDataEditing<Namespace>
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
        /// 管理用ウィンドウを表示するには参照対象のソースファイルを渡し、
        /// このウィンドウを所有するメインウィンドウを指定します。
        /// </summary>
        /// <param name="TargetFile">参照対象のソースファイルクラス</param>
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
            var list = new ObservableCollection<Namespace>(this.CurrentFile.Namespaces);
            this.LB_Nmsp.ItemsSource = list;
            return true;
        }

        /// <summary>
        /// 新規作成用に編集ウィンドウを開きます。
        /// </summary>
        /// <exception cref="Error">ウィンドウ表示時に何かしらのエラーを返します。</exception>
        public void OpenCreateWindow()
        {
        }

        public void OpenCreateWindow(int target)
        {
            if (target == -1) return;
        }

        /// <summary>
        /// サブウィンドウから編集・作成が完了した時（ウィンドウが閉じられる時）
        /// に呼ばれます
        /// </summary>
        /// <param name="editproperty"></param>
        /// <returns></returns>
        public bool CommitData(EDITPROPERTY<Namespace> editproperty)
        {
            return true;
        }

        /// <summary>
        /// リストアイテム更新を反映させるために、リストアイテムに再代入します。
        /// </summary>
        public void FetchListData()
        {
        }

        /// <summary>
        /// このウィンドウが閉じられるとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var CurrentButton = (Button)sender;
            if(CurrentButton.Name == B_Add.Name)
            {
            }
            else if(CurrentButton.Name == B_Edit.Name)
            {
            }
            else if(CurrentButton.Name == B_Delete.Name)
            {
            }
            else if(CurrentButton.Name == B_OK.Name)
            {
                this.Close();
            }
        }
    }
}
