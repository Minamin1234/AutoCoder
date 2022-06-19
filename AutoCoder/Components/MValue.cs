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
    public partial class MValue : MObject
    {
        protected string MINT_Name = "int";
        protected string MFLOAT_Name = "float";
        protected string MSTRING_Name = "string";
        protected string MBOOL_Name = "bool";
        protected string MCHAR_Name = "char";
        protected string MENUM_Name = "enum";
        
        public MValue()
        {

        }

        public string GetTypeName(E_TYPE type)
        {
            string res = "";
            switch (type)
            {
                case E_TYPE.MOBJECT:
                    res = "";
                    break;
                case E_TYPE.MBOOL:
                    res = this.MBOOL_Name;
                    break;
                case E_TYPE.MINT:
                    res = this.MINT_Name;
                    break;
                case E_TYPE.MFLOAT:
                    res = this.MFLOAT_Name;
                    break;
                case E_TYPE.MSTRING:
                    res = this.MSTRING_Name;
                    break;
                case E_TYPE.MCHAR:
                    res = this.MCHAR_Name;
                    break;
                case E_TYPE.MENUM:
                    res = this.MENUM_Name;
                    break;
                case E_TYPE.MSTRUCT:
                    res = "";
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}