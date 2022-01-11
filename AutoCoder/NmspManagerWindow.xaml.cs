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

        /// <summary>
        /// このウィンドウのサブウィンドウを登録します。
        /// </summary>
        /// <param name="nwindow">登録するサブウィンドウ</param>
        /// <exception cref="ArgumentNullException">指定したサブウィンドウが無効場合に発生します。</exception>
        void IDataEditing.SetSubWindow(Window nwindow)
        {
            if(nwindow == null) throw new ArgumentNullException();
            if (this.SubWindow == nwindow) return;
            this.SubWindow = nwindow;
            this.SubWindow.Show();
        }

        /// <summary>
        /// このウィンドウのサブウィンドウの登録を削除します。
        /// </summary>
        void IDataEditing.ClearSubWindow()
        {
            this.SubWindow = null;
            this.ReLoadListData();
        }

        /// <summary>
        /// 新規データの作成が完了した際に呼ばれるイベント。
        /// 送られた新規データをデータリストに追加します。
        /// </summary>
        /// <param name="newData">新規データ</param>
        /// <exception cref="ArgumentNullException">送る新規データが無効の場合に発生します。</exception>
        void IDataEditing.CommitNewData(ACObject newData)
        {
            var cnewdata = (Namespace)newData;
            if (cnewdata == null) throw new ArgumentNullException();
            this.CurrentFile.Namespaces.Add(cnewdata);
        }

        void IDataEditing.FinishedEditingData()
        {
        }

        /// <summary>
        /// 初期化処理
        /// ソースファイルデータから名前空間データをリストボックスに反映させます。
        /// </summary>
        /// <returns>成功したかどうか</returns>
        public bool Initialize()
        {
            this.LB_Nmsp.ItemsSource = this.CurrentFile.Namespaces;
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
        public void ReLoadListData()
        {
            this.LB_Nmsp.ItemsSource =
                new List<Namespace>(this.CurrentFile.Namespaces);
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

        /// <summary>
        /// ウィンドウ内のどれかのボタンが押された時。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                try
                {
                    var item = (Namespace)this.LB_Nmsp.SelectedItem;
                    iself.OpenCreateWindow(item);
                }
                catch (Error E)
                {
                    MessageBox.Show(
                        E.Message,
                        "エラー",
                        default,
                        MessageBoxImage.Information
                        );
                }
            }
            else if(CurrentButton.Name == B_Delete.Name)
            {
                this.CurrentFile.Namespaces.RemoveAt(this.LB_Nmsp.SelectedIndex);
            }
            else if(CurrentButton.Name == B_OK.Name)
            {
                this.Close();
            }
            this.ReLoadListData();
        }
    }
}
