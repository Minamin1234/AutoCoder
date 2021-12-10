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
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3 };
            DataControl.AddData(ref numbers, 1);
            DataControl.AddData(ref numbers, 2);
            foreach(var itm in numbers)
            {
                Console.WriteLine(itm);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
