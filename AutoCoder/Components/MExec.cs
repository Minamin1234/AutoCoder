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
    public partial class MExec : MDefines
    {
        protected List<MArg> Args = new List<MArg>();
        protected string ExecutionName
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

        public MExec()
        {
            this.Name = "exec";
        }

        /// <summary>
        /// 引数を追加します．
        /// </summary>
        /// <param name="newarg">追加する引数</param>
        public void AddArg(MArg newarg)
        {
            this.Args.Add(newarg);
        }

        public string Generate_CallExec()
        {
            string Res = "";
            Res += this.ExecutionName;
            Res += this.SMALL_BEGIN;
            foreach(var v in this.Args)
            {
                //Res += v.VerName;
                Res += v.GenerateEntity();
                Res += this.COMMA;
            }
            Res = Res.Remove(Res.Count() - 1,1);
            Res += this.SMALL_END;
            Res += this.LINE_END;
            return Res;
        }
    }
}