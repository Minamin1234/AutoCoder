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
        public EDITPROPERTY<Namespace> EditProperty = null;

        public CreateNmspWindow(Window whandler, EDITPROPERTY<Namespace> editproperty)
        {
            InitializeComponent();
            this.WHandler = whandler;
            if (editproperty == null) throw new ArgumentNullException();
            else this.EditProperty = editproperty;
            this.Initialize();
            
        }
        public void Initialize()
        {
            switch(this.EditProperty.EditMode)
            {
                case EEditMode.Edit:
                    var nlist = new ObservableCollection<Namespace>(
                        this.EditProperty.TargetData[this.EditProperty.Index].Namespaces);
                    this.LB_Nmsps.ItemsSource = nlist;
                    this.TB_Name.Text =
                        this.EditProperty.TargetData[this.EditProperty.Index].Name;
                    break;
                case EEditMode.Create:
                    var nulllist = new ObservableCollection<Namespace>();
                    this.LB_Nmsps.ItemsSource = nulllist;
                    break;
            }
        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var currentbutton = (Button)sender;

            if(currentbutton.Name == B_OK.Name)
            {
                switch(this.EditProperty.EditMode)
                {
                    case EEditMode.Create:
                        var cNmsp = new Namespace(this.TB_Name.Text,
                            this.LB_Nmsps.ItemsSource.Cast<Namespace>());
                        this.EditProperty.TargetData.Add(cNmsp);
                        break;
                    case EEditMode.Edit:
                        this.EditProperty.TargetData[this.EditProperty.Index].Name =
                            this.TB_Name.Text;
                        this.EditProperty.TargetData[this.EditProperty.Index].Namespaces =
                            new List<Namespace>(this.LB_Nmsps.ItemsSource.Cast<Namespace>());
                        break;
                    default:
                        break;
                }
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
            var nmspmngr = (NmspManagerWindow)this.WHandler;
            nmspmngr.CommitData(this.EditProperty);
            this.Close();
        }

        private void WClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.EditProperty = null;
            var NmspMngrWnd = (NmspManagerWindow)this.WHandler;
            NmspMngrWnd.WinManager.ClearSubWindow();
        }
    }
}


