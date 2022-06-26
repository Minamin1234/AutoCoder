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

namespace AutoCoder
{
    public partial class MFunction : MDefines
    {
        protected List<MExec> Execs;
        protected List<MArg> Args;
        protected E_AccessLevel AccessLevel = E_AccessLevel.PUBLIC;

        /// <summary>
        /// 関数名
        /// </summary>
        protected string FunctionName
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }

        public MFunction()
        {
            this.FunctionName = "function";
        }

        /// <summary>
        /// 関数に処理を追加します。
        /// </summary>
        /// <param name="newexec">新しい処理</param>
        public void AddExec(MExec newexec)
        {
            this.Execs.Add(newexec);
        }

        /// <summary>
        /// 引数を追加します。
        /// </summary>
        /// <param name="newarg">新しい引数</param>
        public void AddArg(MArg newarg)
        {
            this.Args.Add(newarg);
        }

        /// <summary>
        /// 関数のアクセス制限を設定します。
        /// </summary>
        /// <param name="newaccesslevel">変更後のアクセスレベル</param>
        public void SetAccessLevel(E_AccessLevel newaccesslevel)
        {
            this.AccessLevel = newaccesslevel;
        }

        /// <summary>
        /// 関数定義の部分を生成します。
        /// </summary>
        /// <param name="CallArgs"></param>
        /// <returns></returns>
        public string Generate_Function(List<MVar> CallArgs)
        {
            string res = "";

            return "";
        }
    }
}
