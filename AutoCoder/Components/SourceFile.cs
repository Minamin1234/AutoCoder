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
    /// プロジェクト内のソースファイル要素
    /// </summary>
    public class SourceFile : ACObject
    {
        public string FileName = "File";
        public List<Namespace> Namespaces = new List<Namespace>();
        public SourceFile() { }
    }
}
