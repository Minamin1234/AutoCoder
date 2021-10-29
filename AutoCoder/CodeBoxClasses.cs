using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoder
{
    public class Project
    {
        public Project()
        {

        }
    }
    public class CodeBoxClass
    {
        public CodeBoxClass()
        {

        }
    }

    public class UsingBox : CodeBoxClass
    {
        public UsingBox()
        {

        }
    }

    public class NamespaceBox : CodeBoxClass
    {
        public string Name;
        public UsingBox[] Usings;
        public ClassBlock[] Classes;
        public FunctionBlock[] Functions;
        public NamespaceBox()
        {

        }
    }

    public class MainFunctionBox : CodeBoxClass
    {
        public Function[] MainFunctions;
        public MainFunctionBox()
        {

        }
    }

    public class FunctionBox : CodeBoxClass
    {
        public Function[] Tasks;
        public FunctionBox()
        {

        }
    }

    public class SourceBox : CodeBoxClass
    {
        CodeBlockClass[] Codes;
        public SourceBox()
        {

        }
    }
}
