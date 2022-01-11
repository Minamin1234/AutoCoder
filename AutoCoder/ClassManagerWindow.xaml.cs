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
    /// ClassManagerWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ClassManagerWindow : Window,IDataEditing
    {
        public MainWindow WHandler = null;
        public Namespace CurrentFile = null;
        protected Window SubWindow = null;
        public ClassManagerWindow()
        {
            InitializeComponent();
        }

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

        }

        void IDataEditing.SetSubWindow(Window nwindow)
        {

        }

        void IDataEditing.ClearSubWindow()
        {

        }

        void IDataEditing.CommitNewData(ACObject newData)
        {

        }

        void IDataEditing.FinishedEditingData()
        {

        }

        void IDataEditing.OpenCreateWindow()
        {

        }

        void IDataEditing.OpenCreateWindow(ACObject targetdata)
        {

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

            }
            else if(CurrentButton.Name == this.B_edit.Name)
            {

            }
            else if(CurrentButton.Name == this.B_delete.Name)
            {

            }
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
