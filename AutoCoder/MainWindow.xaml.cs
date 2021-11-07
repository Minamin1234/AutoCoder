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
    /// 開いているウィンドウを管理するための構造体。
    /// </summary>
    public struct SWindowState
    {
        /// <summary>
        /// 一つでも開いているウィンドウがあればtrueを返します。(メインウィンドウは除外)
        /// </summary>
        public bool IsOpend
        {
            get { return OpendWndws.Length >= 2 ? true : false; }
        }
        /// <summary>
        /// 開いているウィンドウのリスト
        /// </summary>
        public Window[] OpendWndws;
        public SWindowState(Window[] Wndws)
        {
            if (Wndws == null) this.OpendWndws = new Window[1] { new Window() };
            OpendWndws = Wndws;
        }
        /// <summary>
        /// 新たに開いたウィンドウをリストに追加します。追加が完了したらtrueを返します。
        /// すでに同じウィンドウを追加している場合はfalseを返します。
        /// </summary>
        /// <param name="opendwnd"></param>
        /// <returns>ウィンドウの追加が完了したかどうか</returns>
        public bool AddOpendWnd(Window opendwnd)
        {
            if (CheckIsOpend(opendwnd)) return false;
            Array.Resize(ref this.OpendWndws, this.OpendWndws.Length + 1);//nullでエラー
            this.OpendWndws.Append(opendwnd);
            return true;
        }
        /// <summary>
        /// 指定したウィンドウが開かれているかどうかを返します。開かれている場合はtrueを返します。
        /// </summary>
        /// <param name="chkwnd">調べたいウィンドウクラス</param>
        /// <returns>指定したウィンドウが開かれているかどうか</returns>
        public bool CheckIsOpend(Window chkwnd)
        {
            if (this.OpendWndws == null) return false;
            foreach(var wnd in this.OpendWndws)
            {
                if (chkwnd == wnd) return true;
            }
            return false;
        }
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public Project CurrentProject;
        public NamespaceManager CNmspMnger;
        public SWindowState WndSte = new SWindowState(null);
        public MainWindow()
        {
            InitializeComponent();
            this.Initialize();
        }

        public void Initialize()
        {
            this.CurrentProject = new Project(this);
            this.CNmspMnger = this.CurrentProject.NmspMngr;
            this.CNmspMnger.MngrWindow = new WNamespaceManager(this);
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
                this.CNmspMnger.OpenMngrWnd();
            }
        }
    }
}
