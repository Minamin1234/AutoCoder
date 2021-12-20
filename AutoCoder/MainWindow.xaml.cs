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
        public Namespace[] Namespaces = new Namespace[0];
        public Namespace CNamespace = null;
        public Window SubWindow = null;
        public WindowManager WinManager;
        public bool IsEditing
        {
            get { return this.CurrentFile != null; }
        }

        public MainWindow()
        {
            InitializeComponent();

            //
            var nlist = new ObservableCollection<Namespace>();
            foreach (var itm in this.Namespaces)
            {
                nlist.Add(itm);
            }
            this.CB_namespace.ItemsSource = nlist;//
            this.WinManager = new WindowManager(this);
            this.CurrentProject.CreateNewFile();
            this.Load();
        }
        
        /// <summary>
        /// 指定したプロジェクトファイルからソースファイルを読み込みます。
        /// 読み込めない場合にはfalseが返されます
        /// </summary>
        /// <returns>読み込みに成功したかどうか</returns>
        public bool Load()
        {
            try
            {
                this.CurrentFile = this.CurrentProject.Files[0];
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("NotFoundSourceFile");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 名前空間の管理ウィンドウを表示します。
        /// エラーの場合は戻り値はfalseを返します。
        /// </summary>
        /// <returns>ウィンドウの表示に成功したかどうか。</returns>
        public bool OpenNmspMngrWindow()
        {
            string FuncName = "OpenNmspMngrWindw:";
            if (this.WinManager == null) throw new Error(FuncName + "開こうとしたウィンドウがnullでした");
            if (this.WinManager.IsEditing) throw new Error(FuncName + "既に別のウィンドウを開いています");
            this.WinManager.OpenSetSubWindow(new NmspManagerWindow(ref this.CurrentFile, this));
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