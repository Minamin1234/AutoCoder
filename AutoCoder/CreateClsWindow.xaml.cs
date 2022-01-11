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
        public Window WHandler = null;
        protected CLASS TargetCls = null;
        protected Window SubWindow = null;
        protected bool _IsEdit = false;
        protected int TargetIdx = -1;
        public bool IsEdit
        {
            get { return this._IsEdit; }
        }

        public CreateClsWindow()
        {
            InitializeComponent();
        }

        public CreateClsWindow(Window whandler)
        {
            InitializeComponent();
            if (whandler == null) throw new ArgumentNullException();
            this.WHandler = whandler;
            this._IsEdit = false;
            this.Initialize();
        }

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

        public void Initialize()
        {
            if(this.IsEdit)
            {
                this.TB_classname.Text = this.TargetCls.ClassName;
            }
            else
            {
                this.TargetCls = new CLASS();
            }
        }

        void IDataEditing.SetSubWindow(Window nwindow)
        {
            if (nwindow == null) throw new ArgumentNullException();
            if (this.SubWindow == nwindow) return;
            if (this.SubWindow != null) throw new Error("既にウィンドウが開かれています。");
            this.SubWindow = nwindow;
        }

        void IDataEditing.ClearSubWindow()
        {
            this.SubWindow = null;
        }

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
            /*var cTargetdata = (CLASS)targetdata;
            if (cTargetdata == null) throw new ArgumentNullException();*/
            
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
