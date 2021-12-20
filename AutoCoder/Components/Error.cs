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
    /// このプロジェクト内でのエラーを表します。引数にはエラーの概要を記述します。
    /// </summary>
    public class Error : System.Exception
    {
        public Error(string Desc) : base(Desc) { }
    }
}
