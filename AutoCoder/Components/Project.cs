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
    /// プロジェクトのクラス
    /// </summary>
    public class Project : ACObject
    {
        public string Title = "Project";
        public List<SourceFile> Files = new List<SourceFile>();
        public Project() { }
        /// <summary>
        /// プロジェクトに空のファイルを作成し、リストに追加します。
        /// </summary>
        /// <returns>作成に成功したかどうか</returns>
        public bool CreateNewFile()
        {
            this.Files.Add(new SourceFile());
            return true;
        }
    }
}