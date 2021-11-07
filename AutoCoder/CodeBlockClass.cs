using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Collections.ObjectModel;

namespace AutoCoder
{
    public class Project
    {
        public MainWindow MWHandler
        {
            get { return this.NmspMngr.MWHandler; }
            set { this.NmspMngr.MWHandler = value; }
        }
        public NamespaceBlock MainProgram = new NamespaceBlock();
        public NamespaceManager NmspMngr = new NamespaceManager();
        public Project() { }
        public Project(MainWindow mwHandler) { this.MWHandler = mwHandler; }
    }

    public class Manager
    {
        public MainWindow MWHandler;
        public Window MngrWindow;
        public bool MngrWndIsOpend = false;
        public CodeBlock[] Contents = { new CodeBlock() };
        public Manager() { this.Initialize(); }
        public Manager(MainWindow mwHandler)
        {
            this.Initialize();
            this.MWHandler = mwHandler;
        }

        public virtual void Initialize() { }

        public ObservableCollection<CodeBlock> GetItmSrc()
        {
            var itmsrc = new ObservableCollection<CodeBlock>();
            foreach(var itm in this.Contents)
            {
                itmsrc.Add(itm);
            }
            return itmsrc;
        }

        public void AddContent(CodeBlock content)
        {
            Array.Resize(ref this.Contents, this.Contents.Length + 1);
            this.Contents.Append(content);
        }

        public virtual bool OpenMngrWnd()
        {
            if (this.MngrWndIsOpend) return false;
            if (this.MngrWindow == null) return false;
            this.MngrWindow.Show();
            this.MngrWndIsOpend = true;
            return true;
        }
    }

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
