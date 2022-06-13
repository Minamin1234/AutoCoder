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
    public partial class MArg : MDefines
    {
        protected MVar Variable;
        
        protected string ArgName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        protected bool IsExpr = false;
        public MArg() { }

        //定義時の引数定義を文字列として返します。
        public string GenerateArgDefine()
        {
            string Res = "";
            Res += Variable.VarType.TypeName;
            Res += " ";
            Res += this.ArgName;
            return Res;
        }

        public string GenerateEntity()
        {
            if (this.IsExpr) ;
            return this.ArgName;
        }
    }
}