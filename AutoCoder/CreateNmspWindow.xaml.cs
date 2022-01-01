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
        public NmspManagerWindow WNmspMngrHandler = null;
        public CreateNmspWindow WCrtNmspHandler = null;
        protected Namespace TargetNmsp = null;
        protected Window SubWindow = null;
        protected bool _IsEdit = false;
        protected bool IsFromMngrWnd = false;
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

        public CreateNmspWindow(Window whandler,Namespace targetnmsp)
        {
            InitializeComponent();
            if (whandler == null) throw new ArgumentNullException();
            if (targetnmsp == null) throw new ArgumentNullException();
            this.TargetNmsp = targetnmsp;
            this.WHandler = whandler;
            this._IsEdit = true;
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
        }

        void IDataEditing.CommitNewData(ACObject newData)
        {
            var cnewData = (Namespace)newData;
            if (cnewData == null) throw new ArgumentNullException();

        }

        void IDataEditing.CommitEditData(ACObject editData)
        {

        }

        public void OpenCreateWindow()
        {
            if (this.SubWindow != null) return;

        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var currentbutton = (Button)sender;

            if(currentbutton.Name == B_OK.Name)
            {
                this.TargetNmsp.Name =
                    this.TB_Name.Text;
                this.TargetNmsp.Namespaces =
                    new List<Namespace>(
                        this.LB_Nmsps.ItemsSource.Cast<Namespace>()
                        );

                var target = (IDataEditing)this.WHandler;
                if (this.IsEdit)
                {
                    target.CommitEditData(this.TargetNmsp);
                }
                else
                {
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

            }
            else if(currentbutton.Name == B_Edit.Name)
            {

            }
            else if(currentbutton.Name == B_Delete.Name)
            {

            }
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var cwindow = (IDataEditing)this.WHandler;
            if (cwindow == null) return;
            cwindow.ClearSubWindow();
            this.Close();
        }
    }
}


