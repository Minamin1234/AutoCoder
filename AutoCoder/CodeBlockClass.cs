using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCoder
{
    public class CodeBlockClass
    {
        public CodeBlockClass()
        {
            
        }

        public virtual string ToCode()
        {
            return "";
        }
    }

    public class Project
    {
        public NamespaceBlock MainProgram = new NamespaceBlock();
        public NamespaceBlock[] Namespaces = { new NamespaceBlock() };
        public Project() { }
    }

    public class NamespaceBlock : CodeBlockClass
    {
        public ClassBlock[] Classes = { new ClassBlock() };
        public NamespaceBlock() { }
    }

    public class Type : CodeBlockClass
    {
        public string TypeName = "type";
        public Type()
        {

        }
    }

    public class VariableBlock : CodeBlockClass
    {
        public VariableBlock()
        {

        }
    }

    public class Function : CodeBlockClass
    {
        public string FunctionName = "func";
        public Type ReturnType = new Type();
        public VariableBlock[] Args = { new VariableBlock() };
        public MethodBlock[] Executions = { new MethodBlock() };
        public Function()
        {

        }
    }

    public class FunctionBlock : Function
    {
        
        public FunctionBlock()
        {

        }
    }

    public class MethodBlock : Function
    {
        public MethodBlock()
        {

        }
    }

    public class ClassBlock : CodeBlockClass
    {
        public string ClassName = "cls";
        public FunctionBlock Constructor = new FunctionBlock();
        public FunctionBlock[] Fuctions = { new FunctionBlock() };
        public VariableBlock[] Variables = { new VariableBlock() };

        public ClassBlock()
        {

        }
    }
}
