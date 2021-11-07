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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoCoder
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public Project CurrentProject;
        public NamespaceManager CNmspMnger;
        public MainWindow()
        {
            InitializeComponent();
            this.Initialize();
        }

        public void Initialize()
        {
            this.CurrentProject = new Project(this);
            this.CNmspMnger = this.CurrentProject.NmspMngr;
            this.CB_namespace.ItemsSource = this.CNmspMnger.GetItmSrc();
        }

        private void CB_Closed(object sender, EventArgs e)
        {

        }

        private void BClicked(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if(button.Name == B_nmspmngr.Name)
            {
                
            }
        }
    }
}
