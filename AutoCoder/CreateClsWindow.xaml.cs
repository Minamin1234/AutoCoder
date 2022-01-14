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

namespace AutoCoder
{
    /// <summary>
    /// CreateClsWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CreateClsWindow : Window,IDataEditing
    {
        /// <summary>
        /// 本ウィンドウを所有するウィンドウ。
        /// </summary>
        public Window WHandler = null;
        /// <summary>
        /// 編集対象のクラスデータ
        /// </summary>
        protected CLASS TargetCls = null;
        /// <summary>
        /// 本ウィンドウのサブウィンドウ
        /// </summary>
        protected Window SubWindow = null;
        /// <summary>
        /// _このウィンドウではデータを編集中かどうかを格納します。
        /// </summary>
        protected bool _IsEdit = false;
        /// <summary>
        /// データリストのインデックス
        /// </summary>
        protected int TargetIdx = -1;
        /// <summary>
        /// このウィンドウではデータを編集しているかどうかを返します。
        /// </summary>
        public bool IsEdit
        {
            get { return this._IsEdit; }
        }

        /// <summary>
        /// この方法での初期化は推奨されません。
        /// </summary>
        public CreateClsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 新規作成モードでウィンドウを初期化します。
        /// </summary>
        /// <param name="whandler">このウィンドウを所有するウィンドウ</param>
        /// <exception cref="ArgumentNullException">指定したウィンドウがnullだった場合</exception>
        public CreateClsWindow(Window whandler)
        {
            InitializeComponent();
            if (whandler == null) throw new ArgumentNullException();
            this.WHandler = whandler;
            this._IsEdit = false;
            this.Initialize();
        }

        /// <summary>
        /// 編集モードでウィンドウを初期化します。
        /// </summary>
        /// <param name="whandler">このウィンドウを所有するウィンドウ</param>
        /// <param name="targetcls">編集するクラスデータ</param>
        /// <param name="targetidx">クラスデータが格納されているデータリストのインデックス</param>
        /// <exception cref="ArgumentNullException">引数のどれかがnullだった場合</exception>
        /// <exception cref="Error">インデックスが-1以外のに指定されなかった場合</exception>
        public CreateClsWindow(Window whandler,CLASS targetcls,int targetidx)
        {
            InitializeComponent();
            if (whandler == null || targetcls == null) throw new ArgumentNullException();
            if (targetidx == -1) throw new Error("編集対象のインデックスが指定されていません。");
            this.WHandler = whandler;
            this.TargetCls = targetcls;
            this.TargetIdx = targetidx;
            this._IsEdit = true;
            this.Initialize();
        }

        /// <summary>
        /// これはどのコンストラクタでも呼ばれます。
        /// モードに応じてウィンドウを初期化します。
        /// </summary>
        public void Initialize()
        {
            if(this.IsEdit)
            {
                this.TB_classname.Text = this.TargetCls.ClassName;
                this.LB_classes.ItemsSource = this.TargetCls.Classes;
                this.LB_interfaces.ItemsSource = this.TargetCls.Interfaces;
                switch (this.TargetCls.AccessLevel)
                {
                    case EAccessLevel.PUBLIC:
                        this.RB_public.IsChecked = true;
                        break;

                    case EAccessLevel.PRIVATE:
                        this.RB_private.IsChecked = true;
                        break;

                    case EAccessLevel.PROTECTED:

                    case EAccessLevel.INTERNAL:

                    case EAccessLevel.PROTECTED_INTERNAL:

                    case EAccessLevel.PRIVATE_PROTECTED:

                    default:
                        throw new Error("これらの設定は許可されていません．");
                }
            }
            else
            {
                this.TargetCls = new CLASS();
            }
        }

        /// <summary>
        /// サブウィンドウとして、ウィンドウを登録します。
        /// </summary>
        /// <param name="nwindow">サブウィンドウとして登録するウィンドウ</param>
        /// <exception cref="ArgumentNullException">指定したウィンドウがnullだった場合</exception>
        /// <exception cref="Error">既に別のウィンドウが登録されていたり、開かれている場合</exception>
        void IDataEditing.SetSubWindow(Window nwindow)
        {
            if (nwindow == null) throw new ArgumentNullException();
            if (this.SubWindow == nwindow) return;
            if (this.SubWindow != null) throw new Error("既にウィンドウが開かれています。");
            this.SubWindow = nwindow;
        }

        /// <summary>
        /// 登録したサブウィンドウを削除します
        /// </summary>
        void IDataEditing.ClearSubWindow()
        {
            this.SubWindow = null;
        }

        /// <summary>
        /// サブウィンドウからの編集が完了した際に呼ばれ、編集したデータを受け取ります。
        /// </summary>
        /// <param name="newData">編集したデータ</param>
        /// <exception cref="ArgumentNullException">指定したデータがnullだった場合</exception>
        void IDataEditing.CommitNewData(ACObject newData)
        {
            var cnewData = (CLASS)newData;
            if (cnewData == null) throw new ArgumentNullException();
            this.TargetCls.Classes.Add(cnewData);
        }

        void IDataEditing.FinishedEditingData()
        {

        }

        void IDataEditing.OpenCreateWindow()
        {
            if (this.SubWindow != null) return;
            var nwindow = new CreateClsWindow(this);
            var iself = (IDataEditing)this;
            iself.SetSubWindow(nwindow);
            nwindow.Show();
        }

        void IDataEditing.OpenCreateWindow(ACObject targetdata)
        {
            var iself = (IDataEditing)this;
            var cTargetdata = (CLASS)targetdata;
            if (cTargetdata == null) throw new ArgumentNullException();
            if (this.LB_classes.SelectedIndex == -1) throw new Error("インデックスが指定されていません。");
            var nwindow = new CreateClsWindow(
                this,
                cTargetdata,
                this.LB_classes.SelectedIndex
                );
            iself.SetSubWindow(nwindow);
            nwindow.Show();
            
        }

        private void B_Clicked(object sender, RoutedEventArgs e)
        {
            var CurrentButton = (Button)sender;
            var iself = (IDataEditing)this;

            if(CurrentButton.Name == this.B_variablemanager.Name)
            {

            }
            else if(CurrentButton.Name == this.B_functionmanager.Name)
            {

            }
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var iwhandler = (IDataEditing)this.WHandler;
            if (iwhandler == null) return;
            iwhandler.ClearSubWindow();
        }
    }
}
