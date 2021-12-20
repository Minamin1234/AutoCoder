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
            else throw new Error("WindowManager:所有者クラスがnullでした");
        }
        /// <summary>
        /// サブで開いているウィンドウを指定します。
        /// ウィンドウの表示は行いません。
        /// </summary>
        /// <param name="newWindow"></param>
        /// <returns>指定に成功したかどうか</returns>
        public bool SetSubWindow(Window newWindow)
        {
            string FuncName = "SetSubWindow:";
            if (newWindow != null) this.SubWindow = newWindow;
            else throw new Error(FuncName + "設定しようとしたウィンドウがnullでした");
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
            string FuncName = "SwapSubWindow:";
            if (newWindow != null) { }
            else throw new Error(FuncName + "切り替えようとしたウィンドウがnullでした");
            if (this.SubWindow != newWindow)
            {
                this.SubWindow.Close();
                this.SubWindow = newWindow;
            }
            else throw new Error(FuncName + "同じウィンドウを切り替えようとしました");
            return true;
        }
        /// <summary>
        /// 開いているサブウィンドウを閉じ、サブウィンドウの指定を取り除きます。
        /// </summary>
        /// <returns>除去に成功したかどうか</returns>
        public bool ClearSubWindow()
        {
            string FuncName = "ClearSubWindow:";
            if (this.IsEditing == true)
            {
                this.SubWindow = null;
            }
            else throw new Error(FuncName + "すでにウィンドウは取り除かれています。");
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
            string FuncName = "OpenSetSubWindow:";
            if (nwindow != null) { }
            else throw new Error(FuncName + "設定しようとしたウィンドウがnullでした。");
            if (this.SubWindow == nwindow) throw new Error(FuncName + "既に設定されたウィンドウ");
            this.SubWindow = nwindow;
            nwindow.Show();
            return true;
        }
    }

}
