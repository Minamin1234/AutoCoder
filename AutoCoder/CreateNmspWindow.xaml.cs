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
    public partial class CreateNmspWindow : Window
    {
        public Window WHandler = null;
        public SourceFile CurrentFile = null;

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
        }
        public void Initialize()
        {
        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var currentbutton = (Button)sender;

            if(currentbutton.Name == B_OK.Name)
            {
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
            this.Close();
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}


