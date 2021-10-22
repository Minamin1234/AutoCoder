using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoder
{
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
        public SourceBox[] Codes;
        public NamespaceBox()
        {

        }
    }

    public class FunctionBox : CodeBoxClass
    {
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
