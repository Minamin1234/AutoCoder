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
    /// クラスデータを管理するウィンドウ
    /// </summary>
    public partial class ClassManagerWindow : Window,IDataEditing
    {
        /// <summary>
        /// このウィンドウを所有するメインウィンドウ
        /// </summary>
        public MainWindow WHandler = null;
        /// <summary>
        /// 管理対象のクラスデータが含まれる名前空間データ
        /// </summary>
        public Namespace CurrentFile = null;
        /// <summary>
        /// このウィンドウが所有するサブウィンドウ
        /// </summary>
        protected Window SubWindow = null;
        /// <summary>
        /// この方法での初期化は推奨されません。
        /// </summary>
        public ClassManagerWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 管理対象のクラスデータリストが含まれる名前空間データを渡し，このウィンドウを所有するウィンドウを
        /// 指定します．
        /// </summary>
        /// <param name="TargetFile">管理対象のクラスデータリストが含まれる名前空間データ</param>
        /// <param name="whandler">このウィンドウを所有するウィンドウ</param>
        /// <exception cref="ArgumentNullException">指定したどちらかの値がnullだった場合</exception>
        public ClassManagerWindow(Namespace TargetFile,MainWindow whandler)
        {
            InitializeComponent();
            if (TargetFile == null || whandler == null) throw new ArgumentNullException();
            this.WHandler = whandler;
            this.CurrentFile = TargetFile;
            this.Initialize();
        }

        public void Initialize()
        {
            this.LB_classes.ItemsSource = this.CurrentFile.Classes;
        }

        void IDataEditing.SetSubWindow(Window nwindow)
        {
            if (nwindow == null) throw new ArgumentNullException();
            if (this.SubWindow == nwindow) return;
            if (this.SubWindow != null) throw new Error("他のウィンドウが開かれています。");
            this.SubWindow = nwindow;
        }

        void IDataEditing.ClearSubWindow()
        {
            this.SubWindow = null;
        }

        void IDataEditing.CommitNewData(ACObject newData)
        {
            var cnewdata = (CLASS)newData;
            if (cnewdata == null) throw new ArgumentNullException();
            this.CurrentFile.Classes.Add(cnewdata);
        }

        void IDataEditing.FinishedEditingData()
        {

        }

        void IDataEditing.OpenCreateWindow()
        {
            var iself = (IDataEditing)this;
            var nwindow = new CreateClsWindow(this);
            iself.SetSubWindow(nwindow);
        }

        void IDataEditing.OpenCreateWindow(ACObject targetdata)
        {
            var ctargetdata = (CLASS)targetdata;
            if (targetdata == null) throw new Error("targetdataがnullでした");
            if (this.LB_classes.SelectedItem == null) throw new Error("データが選択されていません。");
            var iself = (IDataEditing)this;
            var nwindow = new CreateClsWindow(
                this,
                ctargetdata,
                this.LB_classes.SelectedIndex
                );
            iself.SetSubWindow(nwindow);
        }

        public void ReloadListData()
        {

        }

        private void B_Clicked(object sender, RoutedEventArgs e)
        {
            var CurrentButton = (Button)sender;
            var iself = (IDataEditing)this;

            if(CurrentButton.Name == this.B_add.Name)
            {
                iself.OpenCreateWindow();
            }
            else if(CurrentButton.Name == this.B_edit.Name)
            {
                try
                {
                    var item = (CLASS)this.LB_classes.SelectedItem;
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
            else if(CurrentButton.Name == this.B_delete.Name)
            {
                this.CurrentFile.Classes.RemoveAt(this.LB_classes.SelectedIndex);
            }
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var iwhandler = (IDataEditing)this.WHandler;
            if (iwhandler == null) throw new Error("インタフェースを持つウィンドウクラスではありません。");
            iwhandler.ClearSubWindow();
        }
    }
}
