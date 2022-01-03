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
        public SourceFile CurrentFile = null;
        protected Window SubWindow = null;
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
        public NmspManagerWindow(SourceFile TargetFile,MainWindow whandler)
        {
            InitializeComponent();
            if (TargetFile == null || whandler == null) throw new ArgumentNullException();
            this.WHander = whandler;
            this.CurrentFile = TargetFile;
            this.Initialize();
        }

        void IDataEditing.SetSubWindow(Window nwindow)
        {
            if(nwindow == null) throw new ArgumentNullException();
            if (this.SubWindow == nwindow) return;
            this.SubWindow = nwindow;
            this.SubWindow.Show();
        }

        void IDataEditing.ClearSubWindow()
        {
            this.SubWindow = null;
        }

        void IDataEditing.CommitNewData(ACObject newData)
        {
            var cnewdata = (Namespace)newData;
            if (cnewdata == null) throw new ArgumentNullException();
            this.CurrentFile.Namespaces.Add(cnewdata);
        }

        void IDataEditing.FinishedEditingData()
        {

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
        void IDataEditing.OpenCreateWindow()
        {
            var cself = (IDataEditing)this;
            var nwindow = new CreateNmspWindow(this);
            cself.SetSubWindow(nwindow);
        }

        /// <summary>
        /// 編集用にウィンドウを開きます。
        /// </summary>
        /// <param name="target">編集対象のインデックス</param>
        void IDataEditing.OpenCreateWindow(ACObject targetdata)
        {
            var ctargetdata = (Namespace)targetdata;
            if (ctargetdata == null) return;
            if (this.CurrentFile.Namespaces == null) throw new Error("CurrentFile.Namespacesがnullでした");
            if (this.LB_Nmsp.SelectedItem == null || this.LB_Nmsp.SelectedIndex == -1) throw new Error("アイテムが選択されていません。");
            var cself = (IDataEditing)this;
            var nwindow = new CreateNmspWindow(
                this,
                ctargetdata,
                this.LB_Nmsp.SelectedIndex
                );
            cself.SetSubWindow(nwindow);
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
            var iwhandler = (IDataEditing)this.WHander;
            if (iwhandler == null) throw new Error("インタフェースを持つウィンドウクラスではありません。");
            iwhandler.ClearSubWindow();
        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var CurrentButton = (Button)sender;
            var iself = (IDataEditing)this;

            if(CurrentButton.Name == B_Add.Name)
            {
                iself.OpenCreateWindow();
            }
            else if(CurrentButton.Name == B_Edit.Name)
            {
                var item = (Namespace)this.LB_Nmsp.SelectedItem;
                iself.OpenCreateWindow(item);
            }
            else if(CurrentButton.Name == B_Delete.Name)
            {
                this.CurrentFile.Namespaces.RemoveAt(this.LB_Nmsp.SelectedIndex);
            }
            else if(CurrentButton.Name == B_OK.Name)
            {
                this.Close();
            }
        }
    }
}
