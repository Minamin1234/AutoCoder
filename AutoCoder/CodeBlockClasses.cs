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
    }

    public class UsingBlock : CodeBlockClass
    {
        public UsingBlock()
        {

        }
    }

    public class ExpressionBlock : CodeBlockClass
    {
        public ExpressionBlock()
        {

        }
    }

    public class StatementExpBlock : CodeBlockClass
    {
        public StatementExpBlock()
        {

        }
    }

    public enum FAccessLevel
    {
        Public,
        Private,
        Grobal
    }

    public class Type
    {
        public ClassBlock TypeDef;
        public Type()
        {

        }
    }

    public class Function : CodeBlockClass
    {
        public enum ELanguage
        {
            CPP,
            CS,
            PY,
            JS
        }

        public Function()
        {

        }
    }

    public class PrimitiveFunctionMethod : Function
    {
        public string FunctionName = "";
        public FAccessLevel AccessLevel = FAccessLevel.Grobal;
        public Type ReturnType;
        public Type[] Arguments;
        public ELanguage language = ELanguage.CS;

        public PrimitiveFunctionMethod()
        {
        }

    }

    public class FunctionBlock : Function
    {
        public string FunctionName = "";
        public FAccessLevel AccessLevel = FAccessLevel.Private;
        public Type ReturnType;
        public Type[] Arguments;

        public FunctionBlock()
        {

        }
    }

    public class MethodBlock : FunctionBlock
    {
        public MethodBlock()
        {

        }
    }

    public class Variable : CodeBoxClass
    {
        public string VariableName = "";
        public FAccessLevel AccessLevel = FAccessLevel.Private;
        public Type VariableType;
        public string InitialValue;

        public Variable()
        {

        }
    }

    public class VariableBlock : Variable
    {
        public VariableBlock()
        {

        }
    }

    public class ClassBlock : CodeBlockClass
    {
        public string ClassName = "";
        public Function[] Constructor;
        public Function[] MemberFunctions;
        public Variable[] MemberVariables;

        public ClassBlock()
        {

        }
    }

    public class StateBlock : CodeBlockClass
    {
        public StateBlock()
        {

        }
    }

    public class LoopBlock : CodeBlockClass
    {
        public LoopBlock()
        {

        }
    }
}
