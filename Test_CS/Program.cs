using System;

namespace Test_CS
{
    public static class DataControl
    {
        public static bool AddData<T>(ref T[] List, T data)
        {
            Array.Resize(ref List, List.Length + 1);
            List[List.Length - 1] = data;
            return true;
        }
    }

    public static class PrimitiveComponent
    {
        /// <summary>
        /// 指定したオブジェクトが有効かどうかを返します。
        /// ここでは、指定した型において有効であるかどうかを判定します。
        /// </summary>
        /// <typeparam name="T">対象のオブジェクトの型</typeparam>
        /// <param name="Object">対象のオブジェクト変数</param>
        /// <returns>有効であるかどうか</returns>
        public static bool IsValid<T>(ref T Object)
        {
            return Object != null ? true : false;
        }

        /// <summary>
        /// 指定したオブジェクトが有効であるかどうかを返します。
        /// </summary>
        /// <param name="Object">対象のオブジェクト</param>
        /// <returns>オブジェクトが有効であるかどうか。</returns>
        public static bool IsValid(ref object Object)
        {
            return Object != null ? true : false;
        }
    }

    public class TestClass
    {
        public string Name = "Test";
        public TestClass() { }
        public override string ToString()
        {
            return this.Name;
        }
    }

    public class TestClass2 : TestClass
    {
        public string SubName = "Test2";
        public TestClass2() { }
        public override string ToString()
        {
            return this.SubName ;
        }
    }

    public class Error : Exception
    {
        public Error(string Desc) : base(Desc) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestClass t1 = new TestClass2();
            TestClass t2 = null;
            Console.WriteLine("IsValid<>(ref t1):");
            Console.WriteLine(PrimitiveComponent.IsValid<TestClass>(ref t1));
            Console.WriteLine("IsValid<>(ref t2:");
            Console.WriteLine(PrimitiveComponent.IsValid<TestClass>(ref t2));

            Console.WriteLine("IsValid(ref t1):");
            Console.WriteLine(PrimitiveComponent.IsValid(ref t1));
            Console.WriteLine("IsValid(ref t2):");
            Console.WriteLine(PrimitiveComponent.IsValid(ref t2));
            throw new Error("Error");//例外クラスのテスト
        }
    }
}
