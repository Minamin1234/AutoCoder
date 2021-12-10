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
        public EDITPROPERTY EditProperty = null;
        public CreateNmspWindow()
        {
            InitializeComponent();
            this.Initialize();
        }
        public CreateNmspWindow(Window whandler)
        {
            InitializeComponent();
            this.Initialize();
            this.WHandler = whandler;
        }
        public CreateNmspWindow(Window whandler, EDITPROPERTY editproperty)
        {
            InitializeComponent();
            this.WHandler = whandler;
            if (editproperty == null) throw new ArgumentNullException();
            else this.EditProperty = editproperty;
            this.Initialize();
            
        }
        public void Initialize()
        {
            if (this.EditProperty != null) { }
            if (this.EditProperty.EditMode == EEditMode.Create)
            {
                DataControl.AddData(ref this.EditProperty.TargetData, new Namespace());
            }
            if(this.EditProperty.EditMode == EEditMode.Edit)
            {
                var currentNmsp = (Namespace)this.EditProperty.TargetData[this.EditProperty.Index];
                this.TB_Name.Text = currentNmsp.Name;
                var list = new ObservableCollection<Namespace>();
                foreach(var nmsp in currentNmsp.Namespaces)
                {
                    list.Add(nmsp);
                }
                this.LB_Nmsps.ItemsSource = list;
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
                        var nmsp = new Namespace();
                        nmsp.Name = this.TB_Name.Text;
                        foreach(var itm in this.LB_Nmsps.Items)
                        {
                            DataControl.AddData(ref nmsp.Namespaces, (Namespace)itm);
                        }
                        DataControl.AddData(ref this.EditProperty.TargetData, nmsp);
                        Console.WriteLine(this.EditProperty.TargetData.Length);
                        foreach(var itm in this.EditProperty.TargetData)
                        {
                            Console.WriteLine(itm);
                        }
                        break;

                    case EEditMode.Edit:
                        var data = (Namespace)this.EditProperty.TargetData[this.EditProperty.Index];
                        data.Name = this.TB_Name.Text;
                        foreach(var itm in this.LB_Nmsps.Items)
                        {
                            
                        }
                        break;

                    default:
                        break;
                }
                //ウィンドウに入力された情報をもとに名前空間のデータを作成・格納
                var nmspmngr = (NmspManagerWindow)this.WHandler;
                nmspmngr.CommitData(this.EditProperty);

                var nmspwindw = (NmspManagerWindow)this.WHandler;
                nmspwindw.WinManager.ClearSubWindow();
            }
        }
    }
}


