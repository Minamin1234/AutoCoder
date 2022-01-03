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
        public Window WHandler = null;
        protected Namespace TargetNmsp = null;
        protected Window SubWindow = null;
        protected bool _IsEdit = false;
        protected bool IsFromMngrWnd = false;
        protected int TargetIdx = -1;
        public bool IsEdit
        {
            get { return _IsEdit; }
        }

        public CreateNmspWindow() { }
        public CreateNmspWindow(Window whandler)
        {
            InitializeComponent();
            if (whandler == null) throw new ArgumentNullException();
            this.WHandler = whandler;
            this._IsEdit = false;
            this.Initialize();
            
        }

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

        public void ReLoadListData()
        {
            this.LB_Nmsps.ItemsSource =
                new List<Namespace>(this.TargetNmsp.Namespaces);
        }

        public void SetSubWindow(Window nwindow)
        {
            if(nwindow == null) throw new ArgumentNullException();
            if (this.SubWindow == nwindow) return;
            if (this.SubWindow != null) throw new Error("既にウィンドウが開かれています。");
            this.SubWindow = nwindow;
        }

        public void ClearSubWindow()
        {
            this.SubWindow = null;
            this.ReLoadListData();
        }

        void IDataEditing.CommitNewData(ACObject newData)
        {
            var cnewData = (Namespace)newData;
            if (cnewData == null) throw new ArgumentNullException();
            this.TargetNmsp.Namespaces.Add(cnewData);
        }

        void IDataEditing.FinishedEditingData()
        {

        }

        void IDataEditing.OpenCreateWindow()
        {
            if (this.SubWindow != null) return;
            var nwindow = new CreateNmspWindow(this);
            this.SetSubWindow(nwindow);
            nwindow.Show();
        }

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
                var cself = (IDataEditing)this;
                var target = (Namespace)LB_Nmsps.SelectedItem;
                if(target == null) throw new ArgumentNullException("target");
                cself.OpenCreateWindow(target);
            }
            else if(currentbutton.Name == B_Delete.Name)
            {
                this.TargetNmsp.Namespaces.RemoveAt(this.LB_Nmsps.SelectedIndex);
            }

            this.ReLoadListData();
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cwindow = (IDataEditing)this.WHandler;
            if (cwindow == null) return;
            cwindow.ClearSubWindow();
        }
    }
}


