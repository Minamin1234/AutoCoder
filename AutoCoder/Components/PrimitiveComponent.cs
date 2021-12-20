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
}
