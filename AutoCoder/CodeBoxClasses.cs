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
        public UsingBox[] Usings;
        public ClassBlock[] Classes;
        public FunctionBlock[] Functions;
        public NamespaceBox()
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
