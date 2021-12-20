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
    public class EDITPROPERTY<T>
    {
        public EEditMode EditMode = EEditMode.Create;
        public List<T> TargetData = null;
        public int Index = 0;
        public EDITPROPERTY() { }
        public EDITPROPERTY(List<T> target)
        {
            this.EditMode = EEditMode.Create;
            if (target != null) this.TargetData = target;
        }
        public EDITPROPERTY(List<T> target, int index)
        {
            if (target != null) this.TargetData = target;
            this.Index = index;
            this.EditMode = EEditMode.Edit;
        }
    }

}
