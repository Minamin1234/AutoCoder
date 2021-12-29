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

using System.Collections.ObjectModel;

namespace AutoCoder
{

    public partial class MainWindow : Window
    {
        public Project CurrentProject = new Project();
        public SourceFile CurrentFile = null;
        public WindowManager WinManager;
        protected Window SubWindow = null;
        public bool HasSubWindow
        {
            get { return this.SubWindow != null; }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            //
            CurrentProject.CreateNewFile();
            var sflist = new ObservableCollection<SourceFile>(this.CurrentProject.Files);
            this.CB_sourcefile.ItemsSource = sflist;
            this.WinManager = new WindowManager(this);
            this.Load();
        }
        
        /// <summary>
        /// 指定したプロジェクトファイルからソースファイルを読み込みます。
        /// 読み込めない場合にはfalseが返されます
        /// </summary>
        /// <returns>読み込みに成功したかどうか</returns>
        public bool Load()
        {
            return true;
        }

        protected void SetSubWindow(Window nwindow)
        {
            if (nwindow == null) return;
            if (this.SubWindow == nwindow) return;
            this.SubWindow = nwindow;
            this.SubWindow.Show();
        }

        /// <summary>
        /// 名前空間の管理ウィンドウを表示します。
        /// エラーの場合は戻り値はfalseを返します。
        /// </summary>
        /// <returns>ウィンドウの表示に成功したかどうか。</returns>
        public bool OpenNmspMngrWindow()
        {
            if(this.HasSubWindow == true) return false;
            var target = (SourceFile)this.CB_sourcefile.SelectedItem;
            if(target == null) return false;
            var nwindow = new NmspManagerWindow(target,this);
            this.SetSubWindow(nwindow);
            return true;
        }


        /// <summary>
        /// ウィンドウ内のどれかのボタンが押された時
        /// </summary>
        /// <param name="sender">押されたボタンクラス</param>
        /// <param name="e">イベントの情報</param>
        private void B_Clicked(object sender, RoutedEventArgs e)
        {
            var CurrentButton = (Button)sender;

            if(CurrentButton.Name == B_NmspMnger.Name)
            {
                this.OpenNmspMngrWindow();
            }
        }
    }
}