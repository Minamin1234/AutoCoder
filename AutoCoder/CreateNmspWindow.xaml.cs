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
    public partial class CreateNmspWindow : Window,IDataEditing<Namespace>
    {
        public Window WHandler = null;
        public SourceFile CurrentFile = null;
        protected Window SubWindow = null;
        protected int TargetNmspFileIdx = -1;

        public CreateNmspWindow() { }
        public CreateNmspWindow(Window whandler)
        {
            InitializeComponent();
            this.WHandler = whandler;
            this.Initialize();
            
        }
        public CreateNmspWindow(SourceFile TargetFile)
        {
            InitializeComponent();
            if (TargetFile == null) throw new ArgumentNullException();
            this.CurrentFile = TargetFile;
            this.Initialize();
        }

        public CreateNmspWindow(SourceFile TargetFile,int TargetIdx)
        {
            InitializeComponent();
            if (TargetFile == null) throw new ArgumentNullException();
            this.CurrentFile = TargetFile;
            this.TargetNmspFileIdx = TargetIdx;
            this.Initialize();
        }
        public void Initialize()
        {
            if(this.TargetNmspFileIdx != -1)
            {
                this.LB_Nmsps.ItemsSource =
                    DataControl.CreateListItem<Namespace>(
                        this.CurrentFile.Namespaces[this.TargetNmspFileIdx].Namespaces
                    );
                this.TB_Name.Text = 
                    this.CurrentFile.Namespaces[this.TargetNmspFileIdx].Name;
            }
            else
            {

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

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var currentbutton = (Button)sender;
            bool IsCreateMode = this.TargetNmspFileIdx == -1;

            if(currentbutton.Name == B_OK.Name)
            {
                if(IsCreateMode)
                {
                    var nNmsp = new Namespace(this.TB_Name.Text,
                        this.LB_Nmsps.ItemsSource.Cast<Namespace>()
                        );
                    this.CurrentFile.Namespaces.Add(nNmsp);
                }
                else
                {
                    var cnmsp = this.CurrentFile.Namespaces[this.TargetNmspFileIdx];
                    cnmsp.Name = TB_Name.Text;
                    cnmsp.Namespaces = new List<Namespace>(
                        this.LB_Nmsps.ItemsSource.Cast<Namespace>()
                        );
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

        }
    }
}


