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

    public partial class MainWindow : Window,IDataEditing
    {
        public Project CurrentProject = new Project();
        public WindowManager WinManager;
        protected Window SubWindow = null;
        public bool HasSubWindow
        {
            get { return this.SubWindow != null; }
        }

        public MainWindow()
        {
            InitializeComponent();
            
            //var nnmsp = new Namespace("Sample", new List<Namespace>());
            //CurrentProject.Files[0].Namespaces.Add(nnmsp);
            //var sflist = new ObservableCollection<SourceFile>(this.CurrentProject.Files);
            //this.CB_sourcefile.ItemsSource = sflist;
            this.CB_sourcefile.ItemsSource = this.CurrentProject.Files;
            var nmsps = this.CB_sourcefile.ItemsSource.Cast<SourceFile>();
            this.CB_namespace.ItemsSource = nmsps.ElementAt(0).Namespaces;
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

        void IDataEditing.SetSubWindow(Window nwindow)
        {
            if (nwindow == null) return;
            if (this.SubWindow == nwindow) return;
            this.SubWindow = nwindow;
            this.SubWindow.Show();
        }

        void IDataEditing.ClearSubWindow()
        {
            if (this.SubWindow == null) return;
            this.SubWindow = null;
        }

        void IDataEditing.OpenCreateWindow()
        {

        }

        void IDataEditing.OpenCreateWindow(ACObject targetdata)
        {

        }

        void IDataEditing.CommitNewData(ACObject newData)
        {

        }

        void IDataEditing.FinishedEditingData()
        {

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
            if (target == null) throw new Error("対象のデータが選択されていません。");
            try
            {
                var nwindow = new NmspManagerWindow(target, this);
                var iself = (IDataEditing)this;
                iself.SetSubWindow(nwindow);
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("対象のファイルがnullでした。", "エラー", default, MessageBoxImage.Error);
            }
            return true;
        }

        public bool OpenClsMngrWindow()
        {
            if (this.HasSubWindow == true) return false;
            var target = (Namespace)this.CB_namespace.SelectedItem;
            if (target == null) throw new Error("対象のデータが選択されていません．");
            try
            {
                var nwindow = new ClassManagerWindow(target, this);
                var iself = (IDataEditing)this;
                iself.SetSubWindow(nwindow);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("対象のファイルがnullでした。", "エラー", default, MessageBoxImage.Error);
            }
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

            if(CurrentButton.Name == this.B_NmspMnger.Name)
            {
                try { this.OpenNmspMngrWindow(); }
                catch (Error E)
                {
                    MessageBox.Show(E.Message, "エラー", default, MessageBoxImage.Information);
                }
            }
            else if(CurrentButton.Name == this.B_classmanager.Name)
            {
                this.OpenClsMngrWindow();
            }
        }
    }
}