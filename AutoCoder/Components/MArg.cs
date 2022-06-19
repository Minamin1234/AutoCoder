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
    public partial class MArg : MValue
    {
        //protected MVar Variable;
        protected E_TYPE Type = E_TYPE.MINT;
        protected string Value = "";
        protected string DefaultValue = "";
        protected bool IsDefaultArg = false;    
        
        protected string ArgName
        {
            get { return this.Name; }
            set { this.Name = value; }
        }
        protected bool IsExpr = false;
        public MArg() { }

        /// <summary>
        /// 定義時の引数名を設定します。
        /// </summary>
        /// <param name="name">引数名</param>
        public void SetArgName(string name)
        {
            this.ArgName = name;
        }

        /// <summary>
        /// 引数をデフォルト引数として設定します。
        /// </summary>
        /// <param name="defaultarg">デフォルト引数として定義するかどうか</param>
        public void SetDefaultArg(bool defaultarg=true)
        {
            this.IsDefaultArg = defaultarg;
        }

        /// <summary>
        /// 引数の型を変更します。
        /// </summary>
        /// <param name="newType">変更後の引数型</param>
        public void SetType(E_TYPE newType)
        {
            this.Type = newType;
        }

        /// <summary>
        /// 呼び出し時の引数の値を適用し値として格納します。
        /// </summary>
        /// <param name="val">関数呼び出し時の引数値</param>
        public void AttatchValue(string val)
        {
            switch (this.Type)
            {
                case E_TYPE.MSTRING:
                    this.Value += "\"";
                    this.Value += val;
                    this.Value += "\"";
                    break;
                case E_TYPE.MCHAR:
                    this.Value += "\'";
                    this.Value += val;
                    this.Value += "\'";
                    break;
                case E_TYPE.MOBJECT:
                case E_TYPE.MBOOL:
                case E_TYPE.MINT:
                case E_TYPE.MFLOAT:
                case E_TYPE.MENUM:
                case E_TYPE.MSTRUCT:
                    this.Value = val;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 定義時のデフォルト引数として適用させます。
        /// </summary>
        /// <param name="val">デフォルト値</param>
        public void AttatchDefaultValue(string val)
        {
            switch (this.Type)
            {
                case E_TYPE.MSTRING:
                    this.DefaultValue += "\"";
                    this.DefaultValue += val;
                    this.DefaultValue += "\"";
                    break;
                case E_TYPE.MCHAR:
                    this.DefaultValue += "\'";
                    this.DefaultValue += val;
                    this.DefaultValue += "\'";
                    break;
                case E_TYPE.MOBJECT:
                case E_TYPE.MBOOL:
                case E_TYPE.MINT:
                case E_TYPE.MFLOAT:
                case E_TYPE.MENUM:
                case E_TYPE.MSTRUCT:
                    this.DefaultValue = val;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 定義時の引数定義を文字列として返します。
        /// </summary>
        /// <returns></returns>
        public string GenerateArgDefine()
        {
            string res = "";
            res += this.GetTypeName(this.Type);
            res += " ";
            res += this.ArgName;
            if(this.IsDefaultArg)
            {
                res += this.EQUAL;
                res += this.DefaultValue;
            }
            return res;
        }

        /// <summary>
        /// 関数呼び出し用の引数の値を文字列として返します。
        /// </summary>
        /// <returns></returns>
        public string GenerateEntity()
        {
            return this.Value;
        }
    }
}