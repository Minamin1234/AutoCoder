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
    /// CreateNmspWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class CreateNmspWindow : Window
    {
        public Window WHandler = null;
        public EEditMode EditMode = EEditMode.Create;
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
        public CreateNmspWindow(Window whandler,EEditMode editmode)
        {
            InitializeComponent();
            this.Initialize();
            this.WHandler = whandler;
            this.EditMode = editmode;
        }
        public void Initialize()
        {
            //this.Show();
        }
    }
}
