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
    public partial class MObject
    {
        protected string Name = "MObject";
        protected string EQUAL = "=";
        protected string ACCESS = ".";
        protected string BLOCK_BEGIN = "{";
        protected string BLOCK_END = "}";
        protected string SMALL_BEGIN = "(";
        protected string SMALL_END = ")";
        protected string LINE_END = ";";
        protected string SPRT = ":";
        protected string COMMA = ",";
        protected string POINTER = "*";
        protected string CALC_ADD = " + ";
        protected string CALC_SUB = " - ";
        protected string CALC_MULTI = " * ";
        protected string CALC_DIV = " / ";
        protected string CALC_ADD_S = "+=";
        protected string CALC_SUB_S = "-=";
        protected string CALC_MULTI_S = "*=";
        protected string CALC_DIV_S = "/=";
        protected string TAB = "\t";
        protected string SPACE = " ";

        public override string ToString()
        {
            return this.Name;
        }

        public MObject()
        {

        }
    }
}
