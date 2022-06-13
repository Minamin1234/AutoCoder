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
        protected List<MArg> Args;
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

        public string Generate_CallExec(List<MArg> CallArgs)
        {
            string Res = "";
            Res += this.ExecutionName;
            Res += this.SMALL_BEGIN;
            foreach(var v in CallArgs)
            {
                //Res += v.VerName;
                Res += this.COMMA;
            }
            Res += this.SMALL_END;
            Res += this.LINE_END;
            return "";
        }
    }
}