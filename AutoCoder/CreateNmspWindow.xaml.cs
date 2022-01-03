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
    /// CreateNmspWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CreateNmspWindow : Window,IDataEditing
    {
        /// <summary>
        /// 本ウィンドウを所有するウィンドウ。
        /// </summary>
        public Window WHandler = null;
        /// <summary>
        /// 編集対象の名前空間データ
        /// </summary>
        protected Namespace TargetNmsp = null;
        /// <summary>
        /// 本ウィンドウのサブウィンドウ
        /// </summary>
        protected Window SubWindow = null;
        /// <summary>
        /// _このウィンドウではデータ編集モードであるかどうか。
        /// </summary>
        protected bool _IsEdit = false;
        /// <summary>
        /// （編集モードのみ）データリストから取得したデータインデックス
        /// -1は新規作成モードを表します。
        /// </summary>
        protected int TargetIdx = -1;
        /// <summary>
        /// このウィンドウではデータ編集モードであるかどうか。
        /// </summary>
        public bool IsEdit
        {
            get { return _IsEdit; }
        }

        /// <summary>
        /// この方法での初期化は推奨されません。
        /// </summary>
        public CreateNmspWindow() { }
        /// <summary>
        /// 新規作成モードでウィンドウを初期化します。
        /// </summary>
        /// <param name="whandler">このウィンドウを所有するウィンドウ（＝親ウィンドウ）</param>
        /// <exception cref="ArgumentNullException">指定した所有ウィンドウが無効の場合に発生します。</exception>
        public CreateNmspWindow(Window whandler)
        {
            InitializeComponent();
            if (whandler == null) throw new ArgumentNullException();
            this.WHandler = whandler;
            this._IsEdit = false;
            this.Initialize();
            
        }

        /// <summary>
        /// データ編集モードでウィンドウを初期化します。
        /// </summary>
        /// <param name="whandler">このウィンドウを所有するウィンドウ（＝親ウィンドウ）</param>
        /// <param name="targetnmsp">編集対象のデータ</param>
        /// <param name="targetidx">対象のデータがあるリストのインデックス</param>
        /// <exception cref="ArgumentNullException">指定した所有ウィンドウやデータが無効の場合に発生します。</exception>
        /// <exception cref="Error">インデックスが指定されていない場合に発生します。</exception>
        public CreateNmspWindow(Window whandler,Namespace targetnmsp,int targetidx)
        {
            InitializeComponent();
            if (whandler == null) throw new ArgumentNullException();
            if (targetnmsp == null) throw new ArgumentNullException();
            if (targetidx == -1) throw new Error("編集対象のインデックスが指定されていません。");
            this.TargetNmsp = targetnmsp;
            this.WHandler = whandler;
            this._IsEdit = true;
            this.TargetIdx = targetidx;
            this.Initialize();
        }

        /// <summary>
        /// 初期化処理。
        /// 新規作成モードは新規データを作成、
        /// 編集モードは編集対象のデータからパラメータをウィンドウに反映させます。
        /// </summary>
        public void Initialize()
        {
            if(this.TargetNmsp == null)
            {
                this.TargetNmsp = new Namespace();
            }
            else
            {
                this.TB_Name.Text = this.TargetNmsp.Name;
                this.LB_Nmsps.ItemsSource = this.TargetNmsp.Namespaces;
            }
        }

        /// <summary>
        /// リストボックスのデータを再読み込みします。
        /// </summary>
        public void ReLoadListData()
        {
            this.LB_Nmsps.ItemsSource =
                new List<Namespace>(this.TargetNmsp.Namespaces);
        }

        /// <summary>
        /// このウィンドウのサブウィンドウを登録します。表示は行いません。
        /// </summary>
        /// <param name="nwindow">登録するサブウィンドウ</param>
        /// <exception cref="ArgumentNullException">指定したサブウィンドウが無効の場合に発生します。</exception>
        /// <exception cref="Error">既にサブウィンドウが登録されている場合に発生します。</exception>
        public void SetSubWindow(Window nwindow)
        {
            if(nwindow == null) throw new ArgumentNullException();
            if (this.SubWindow == nwindow) return;
            if (this.SubWindow != null) throw new Error("既にウィンドウが開かれています。");
            this.SubWindow = nwindow;
        }

        /// <summary>
        /// 登録されているサブウィンドウを削除します。
        /// </summary>
        public void ClearSubWindow()
        {
            this.SubWindow = null;
            this.ReLoadListData();
        }

        /// <summary>
        /// 新規のデータが作成完了した際のイベント
        /// ここでは、作成したデータが送られ、受け取ったデータをデータリストに追加します。
        /// </summary>
        /// <param name="newData">新規作成したデータ</param>
        /// <exception cref="ArgumentNullException">指定したデータが無効の場合に発生します。</exception>
        void IDataEditing.CommitNewData(ACObject newData)
        {
            var cnewData = (Namespace)newData;
            if (cnewData == null) throw new ArgumentNullException();
            this.TargetNmsp.Namespaces.Add(cnewData);
        }

        /// <summary>
        /// 
        /// </summary>
        void IDataEditing.FinishedEditingData()
        {

        }

        /// <summary>
        /// 新規作成用にサブウィンドウを開きます。
        /// </summary>
        void IDataEditing.OpenCreateWindow()
        {
            if (this.SubWindow != null) return;
            var nwindow = new CreateNmspWindow(this);
            this.SetSubWindow(nwindow);
            nwindow.Show();
        }

        /// <summary>
        /// 編集用にサブウィンドウを開きます。
        /// </summary>
        /// <param name="targetdata"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Error"></exception>
        void IDataEditing.OpenCreateWindow(ACObject targetdata)
        {
            var cTargetdata = (Namespace)targetdata;
            if(cTargetdata == null) throw new ArgumentNullException();
            if (this.LB_Nmsps.SelectedIndex == -1) throw new Error("インデックスが指定されていません。");
            var nwindow = new CreateNmspWindow(
                this,
                cTargetdata,
                this.LB_Nmsps.SelectedIndex
                );
            this.SetSubWindow(nwindow);
            nwindow.Show();
        }

        /// <summary>
        /// ウィンドウ内のどれかのボタンが押された時。
        /// </summary>
        /// <param name="sender">イベントの発信したオブジェクト</param>
        /// <param name="e">イベント発信に伴うデータ</param>
        /// <exception cref="ArgumentNullException">選択したアイテムがない場合に発生します。</exception>
        private void BClicked(object sender, RoutedEventArgs e)
        {
            var currentbutton = (Button)sender;

            if(currentbutton.Name == B_OK.Name)
            {
                this.TargetNmsp.Name =
                    this.TB_Name.Text;
                if(this.LB_Nmsps.ItemsSource != null)
                {
                    this.TargetNmsp.Namespaces =
                    new List<Namespace>(this.LB_Nmsps.ItemsSource.Cast<Namespace>());
                }

                if (!this.IsEdit)
                {
                    var target = (IDataEditing)this.WHandler;
                    target.CommitNewData(this.TargetNmsp);
                }
                this.Close();
            }
            else if(currentbutton.Name == B_Cancel.Name)
            {
                this.Close();
            }
            else if(currentbutton.Name == B_Add.Name)
            {
                var cself = (IDataEditing)this;
                cself.OpenCreateWindow();
            }
            else if(currentbutton.Name == B_Edit.Name)
            {
                try
                {
                    var cself = (IDataEditing)this;
                    var target = (Namespace)LB_Nmsps.SelectedItem;
                    if (target == null) throw new Error("アイテムが選択されていません。");
                    cself.OpenCreateWindow(target);
                }
                catch (Error E)
                {
                    MessageBox.Show(E.Message, "エラー", default, MessageBoxImage.Information);
                }
            }
            else if(currentbutton.Name == B_Delete.Name)
            {
                this.TargetNmsp.Namespaces.RemoveAt(this.LB_Nmsps.SelectedIndex);
            }

            this.ReLoadListData();
        }

        /// <summary>
        /// このウィンドウが閉じられる時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //このウィンドウの所有者のインタフェースを通して
            //所有者のサブウィンドウの登録を消去します。
            var cwindow = (IDataEditing)this.WHandler;
            if (cwindow == null) return;
            cwindow.ClearSubWindow();
        }
    }
}


