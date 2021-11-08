using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Collections.ObjectModel;

namespace AutoCoder
{
    /// <summary>
    /// ユーザーが構築したコードブロック要素をまとめるプロジェクトクラス。
    /// </summary>
    public class Project
    {
        public MainWindow MWHandler
        {
            get { return this.NmspMngr.MWHandler; }
            set { this.NmspMngr.MWHandler = value; }
        }
        /// <summary>
        /// エントリーポイントとなる名前空間
        /// </summary>
        public NamespaceBlock MainProgram = new NamespaceBlock();
        /// <summary>
        /// このプロジェクトに定義された名前空間を管理するクラス。
        /// </summary>
        public NamespaceManager NmspMngr = new NamespaceManager();
        public Project() { }
        /// <summary>
        /// このプロジェクトクラスを所有するクラス（メインウィンドウ）を指定します。
        /// </summary>
        /// <param name="mwHandler">このプロジェクトクラスを所有するクラス</param>
        public Project(MainWindow mwHandler) { this.MWHandler = mwHandler; }
    }

    /// <summary>
    /// 開いているウィンドウを管理するためのクラス。
    /// </summary>
    public class WindowState
    {
        /// <summary>
        /// 一つでも開いているウィンドウがあればtrueを返します。（メインウィンドウは除外）
        /// </summary>
        public bool IsOpend
        {
            get { return this.OpendWndws.Length >= 1 ? true : false; }
        }
        /// <summary>
        /// 開いているウィンドウのリスト。
        /// </summary>
        public Window[] OpendWndws = new Window[0];

        public WindowState() { }

        /// <summary>
        /// 開いたウィンドウをリストに追加します。追加が完了したらtrue,
        /// すでに追加されていた場合はfalseを返します。
        /// </summary>
        /// <param name="opendwnd">リストへ追加するウィンドウ</param>
        /// <returns>リストに追加できたかどうか。</returns>
        public bool AddOpendWnd(Window opendwnd)
        {
            if (this.CheckIsOpend(opendwnd)) return false;
            Array.Resize(ref this.OpendWndws, this.OpendWndws.Length + 1);
            this.OpendWndws.Append(opendwnd);
            return true;
        }

        /// <summary>
        /// 指定したウィンドウがリストに存在し、ウィンドウが開かれているかどうかを返します。
        /// 開かれている場合はtrueを返します。
        /// </summary>
        /// <param name="chkwnd"></param>
        /// <returns>指定したウィンドウが開かれているかどうか。</returns>
        public bool CheckIsOpend(Window chkwnd)
        {
            if (this.OpendWndws == null) return false;
            foreach(var wnd in this.OpendWndws)
            {
                if (chkwnd == wnd) return true;
            }
            return false;
        }

        public bool RemoveWnd(Window removWnd)
        {
            return true;
        }
    }

    /// <summary>
    /// ユーザーが定義したコードブロック要素を管理する基底クラス。
    /// リスト管理するための基本的なメソッドを提供します。
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// このクラスを所有するクラス。（メインウィンドウ）
        /// </summary>
        public MainWindow MWHandler;
        /// <summary>
        /// ユーザーがリストを編集するためのウィンドウクラス。
        /// </summary>
        public Window MngrWindow;
        /// <summary>
        /// コードブロック要素を格納するリスト配列。
        /// </summary>
        public CodeBlock[] Contents = new CodeBlock[1];
        /// <summary>
        /// 編集用ウィンドウを管理するためのクラス。
        /// 所有者クラスから取得、設定する。
        /// </summary>
        public WindowState MWndState
        {
            get { return this.MWHandler.WndSte; }
            set { this.MWHandler.WndSte = value; }
        }
        public Manager() { this.Initialize(); }
        /// <summary>
        /// このクラスを所有するクラスを指定します。
        /// </summary>
        /// <param name="mwHandler"></param>
        public Manager(MainWindow mwHandler)
        {
            this.Initialize();
            this.MWHandler = mwHandler;
        }

        public virtual void Initialize() { }

        //Methods
        /// <summary>
        /// コンボボックスに表示するためのリストを返します。
        /// </summary>
        /// <returns>コンボボックスに入れるべきItemSource</returns>
        public ObservableCollection<CodeBlock> GetItmSrc()
        {
            var itmsrc = new ObservableCollection<CodeBlock>();
            foreach(var itm in this.Contents)
            {
                itmsrc.Add(itm);
            }
            return itmsrc;
        }

        /// <summary>
        /// リストにクラスを追加します。
        /// </summary>
        /// <param name="content"></param>
        public void AddContent(CodeBlock content)
        {
            Array.Resize(ref this.Contents, this.Contents.Length + 1);
            this.Contents.Append(content);
        }

        /// <summary>
        /// 要素を編集するためのウィンドウを表示します。
        /// 表示に成功したらtrueを返します。
        /// 編集用ウィンドウクラスが指定されていない場合、falseを返します。
        /// </summary>
        /// <returns></returns>
        public virtual bool OpenMngrWnd()
        {
            if (this.MngrWindow == null) return false;
            if (this.MWndState.CheckIsOpend(this.MngrWindow)) return false;
            this.MngrWindow.Show();
            this.MWHandler.WndSte.AddOpendWnd(this.MngrWindow);
            return true;
        }

        //Events
        public virtual void RecieveWndClose(Window sendfrom)
        {
            sendfrom.Close();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NamespaceManager : Manager
    {
        public WNamespaceManager WNmspMngr
        {
            get { return (WNamespaceManager)this.MngrWindow; }
            set { this.MngrWindow = value; }
        }
        public NamespaceManager() { this.Initialize(); }
        public NamespaceManager(MainWindow mwHandler) : base(mwHandler)
        {
            this.Initialize();
            this.MWHandler = mwHandler;
        }
        public override void Initialize()
        {
            base.Initialize();
            this.Contents[0] = new NamespaceBlock();
        }
    }

    public class CodeBlock
    {
        public string Name = "";
        public CodeBlock() { }
    }

    public class NamespaceBlock : CodeBlock
    {
        public string NamespaceName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        public NamespaceBlock()
        {
            this.NamespaceName = "nmsp";
        }

        public override string ToString()
        {
            return this.NamespaceName;
        }
    }
    
    public class ClassBlock : CodeBlock
    {
        public string ClassName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }

        public ClassBlock() { }

        public override string ToString()
        {
            return this.ClassName;
        }
    }
}
