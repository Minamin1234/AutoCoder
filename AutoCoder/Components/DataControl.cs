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
        public static bool AddData<T>(ref T[] List, T data)
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
        public static bool CopyData<T>(T[] Origin, ref T[] Target)
        {
            foreach (T itm in Origin)
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
            foreach (T itm in item)
            {
                list.Add(itm);
            }
            return list;
        }

        public static ObservableCollection<T> CreateListItem<T>(List<T> item)
        {
            return new ObservableCollection<T>(item);
        }

        /// <summary>
        /// リストボックスのアイテムを反映させます。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listdata"></param>
        /// <param name="listbox"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool FetchListData<T>(List<T> listdata,ListBox listbox)
        {
            if (listdata == null || listbox == null) throw new ArgumentNullException();
            var list = new ObservableCollection<T>(listdata);
            listbox.ItemsSource = list;
            return true;
        }
        public static bool OpenCreateWindow<DT,WT>(WindowManager winmngr,List<DT> datalist)
            where WT : Window
        {
            return true;
        }
    }

}
