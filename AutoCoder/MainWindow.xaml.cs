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
    /// <summary>
    /// 基本的な関数が集まったコンポーネント。
    /// </summary>
    public static class PrimitiveComponent
    {
        /// <summary>
        /// 指定したオブジェクトが有効かどうかを返します。
        /// ここでは、指定した型において有効であるかどうかを判定します。
        /// </summary>
        /// <typeparam name="T">対象のオブジェクトの型</typeparam>
        /// <param name="Object">対象のオブジェクト変数</param>
        /// <returns>有効であるかどうか</returns>
        public static bool IsValid<T>(ref T Object)
        {
            return Object != null ? true : false;
        }

        /// <summary>
        /// 指定したオブジェクトが有効であるかどうかを返します。
        /// </summary>
        /// <param name="Object">対象のオブジェクト</param>
        /// <returns>オブジェクトが有効であるかどうか。</returns>
        public static bool IsValid(ref object Object)
        {
            return Object != null ? true : false;
        }
    }

    /// <summary>
    /// データクラスのリストを操作する為の静的クラス。
    /// </summary>
    public static class DataControl
    {
        /// <summary>
        /// データクラスのリストにデータを追加します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List"></param>
        /// <param name="data"></param>
        /// <returns>追加に成功したかどうか</returns>
        public static bool AddData<T>(ref T[] List,T data)
        {
            Array.Resize(ref List, List.Length + 1);
            List[List.Length - 1] = data;
            return true;
        }

        /// <summary>
        /// 配列OriginからTargetに要素全てをコピーします
        /// </summary>
        /// <typeparam name="T">要素の型</typeparam>
        /// <param name="Origin">コピー元配列</param>
        /// <param name="Target">コピー先配列。同じサイズの配列にコピーしたい場合は、
        /// これには空の配列を用意すべきです。</param>
        /// <returns>コピーに成功したかどうか</returns>
        public static bool CopyData<T>(T[] Origin,ref T[] Target)
        {
            foreach(T itm in Origin)
            {
                Array.Resize(ref Target, Target.Length + 1);
                Target[Target.Length - 1] = itm;
            }
            return true;
        }

        /// <summary>
        /// リストボックスのアイテムコレクションを作成し、返します。
        /// </summary>
        /// <typeparam name="T">アイテムコレクションの型</typeparam>
        /// <param name="item">アイテムコレクションのアイテム配列</param>
        /// <returns>リストボックスのアイテムコレクション</returns>
        public static ObservableCollection<T> CreateListItem<T>(T[] item)
        {
            var list = new ObservableCollection<T>();
            foreach(T itm in item)
            {
                list.Add(itm);
            }
            return list;
        }
    }

    public interface IDataEditing
    {
        bool CommitData(EDITPROPERTY editproperty);
    }

    /// <summary>
    /// データの操作モードを指定する列挙体
    /// </summary>
    public enum EEditMode
    {
        /// <summary>
        /// 新規作成モード
        /// </summary>
        Create,
        /// <summary>
        /// 編集モード
        /// </summary>
        Edit
    }

    /// <summary>
    /// 操作されるデータ対象についてのプロパティクラス
    /// </summary>
    public class EDITPROPERTY
    {
        public EEditMode EditMode = EEditMode.Create;
        public ACObject[] TargetData = null;
        public uint Index = 0;
        public EDITPROPERTY() { }
        public EDITPROPERTY(ACObject[] target)
        {
            this.EditMode = EEditMode.Create;
            if (target != null) this.TargetData = target;
        }
        public EDITPROPERTY(ACObject[] target,uint index)
        {
            if (target != null) this.TargetData = target;
            this.Index = index;
            this.EditMode = EEditMode.Edit;
        }
    }

    //それぞれのウィンドウにサブのウィンドウを管理する為の変数や関数を提供する為のクラス。
    /// <summary>
    /// ウィンドウがウィンドウを管理・操作する為の動的クラス。
    /// </summary>
    public class WindowManager
    {
        /// <summary>
        /// このクラスを所有しているウィンドウ
        /// </summary>
        public Window Owner = null;
        /// <summary>
        /// 所有しているウィンドウがサブで開いているウィンドウ
        /// </summary>
        public Window SubWindow = null;
        /// <summary>
        /// この所有しているウィンドウがサブでウィンドウを開いており、データの編集中であるかどうか
        /// </summary>
        public bool IsEditing
        {
            get { return SubWindow != null; }
        }
        public WindowManager() { }
        /// <summary>
        /// インスタンスの作成と共に、所有者を指定します
        /// </summary>
        /// <param name="owner">このクラスを所有するウィンドウ</param>
        public WindowManager(Window owner)
        {
            if (owner != null) this.Owner = owner;
        }
        /// <summary>
        /// サブで開いているウィンドウを指定します。
        /// ウィンドウの表示は行いません。
        /// </summary>
        /// <param name="newWindow"></param>
        /// <returns>指定に成功したかどうか</returns>
        public bool SetSubWindow(Window newWindow)
        {
            if (newWindow != null) this.SubWindow = newWindow;
            else return false;
            return true;
        }
        /// <summary>
        /// 既に指定されたサブウィンドウを閉じ、新たなサブウィンドウを指定します。
        /// 同じウィンドウが指定されている場合、何も行わずFalseが返されます。
        /// </summary>
        /// <param name="newWindow"></param>
        /// <returns>指定に成功したかどうか。</returns>
        public bool SwapSubWindow(Window newWindow)
        {
            if (newWindow != null) { }
            else return false;
            if(this.SubWindow != newWindow)
            {
                this.SubWindow.Close();
                this.SubWindow = newWindow;
            }
            else return false;
            return true;
        }
        /// <summary>
        /// 開いているサブウィンドウを閉じ、サブウィンドウの指定を取り除きます。
        /// </summary>
        /// <returns>除去に成功したかどうか</returns>
        public bool ClearSubWindow()
        {
            if (this.IsEditing != true)
            {
                this.SubWindow.Close();
                this.SubWindow = null;
            }
            else return false;
            return true;
        }

        /// <summary>
        /// サブウィンドウを指定し、指定したウィンドウを開きます。
        /// 既に同じウィンドウが指定されていたり、開かれている場合にはfalseが返されます。
        /// </summary>
        /// <param name="nwindow"></param>
        /// <returns>サブウィンドウの指定に成功したかどうか</returns>
        public bool OpenSetSubWindow(Window nwindow)
        {
            if (nwindow != null) { }
            else return false;
            if (this.SubWindow == nwindow) return false;
            this.SubWindow = nwindow;
            nwindow.Show();
            return true;
        }
    }

    /// <summary>
    /// このプログラムで扱うオブジェクトの基底クラス
    /// </summary>
    public class ACObject
    {
        public ACObject() { }
    }

    /// <summary>
    /// プロジェクトのクラス
    /// </summary>
    public class Project : ACObject
    {
        public string Title = "Project";
        public SourceFile[] Files = new SourceFile[0];
        public Project() { }
        /// <summary>
        /// プロジェクトに空のファイルを作成し、リストに追加します。
        /// </summary>
        /// <returns>作成に成功したかどうか</returns>
        public bool CreateNewFile()
        {
            Array.Resize(ref this.Files, this.Files.Length + 1);
            this.Files[this.Files.Length - 1] = new SourceFile();
            return true;
        }
    }

    /// <summary>
    /// プロジェクト内のソースファイル要素
    /// </summary>
    public class SourceFile : ACObject
    {
        public string FileName = "File";
        public Namespace[] Namespaces = new Namespace[0];
        public SourceFile() { }
    }

    /// <summary>
    /// ソースファイル内の名前空間要素
    /// </summary>
    public class Namespace : ACObject
    {
        public string Name = "Nmsp";
        public Namespace[] Namespaces = new Namespace[0];
        public Namespace()
        {

        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public partial class MainWindow : Window
    {
        public Project CurrentProject = new Project();
        public SourceFile CurrentFile = null;
        public Namespace[] Namespaces = new Namespace[0];
        public Namespace CNamespace = null;
        public Window SubWindow = null;
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
        /// ウィンドウ内のどれかのボタンが押された時
        /// </summary>
        /// <param name="sender">押されたボタンクラス</param>
        /// <param name="e">イベントの情報</param>
        private void B_Clicked(object sender, RoutedEventArgs e)
        {
            var CurrentButton = (Button)sender;

            if(CurrentButton.Name == B_NmspMnger.Name)
            {

            }
        }
    }
}