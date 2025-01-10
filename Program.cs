using System;

namespace ObfuscarIssue1
{
    interface IFace<T>
    {
        // Obfuscar will keep the names different.
        string Method1(int a, T b);
        string Method2(T a, int b);

        // This one would be allowed here but makes explicit implementation impossible.
        //string Method2(int a, int b);

        // Obfuscar will use the same name for those.
        string Method3(int a, out T b);
        string Method4(T a, out int b);
    }

    class Program : IFace<int>
    {
        string IFace<int>.Method1(int a, int b)
        {
            return "Method1";
        }

        string IFace<int>.Method2(int a, int b)
        {
            return "Method2";
        }

        string IFace<int>.Method3(int a, out int b)
        {
            b = 42;
            return "Method3";
        }

        string IFace<int>.Method4(int a, out int b)
        {
            b = 42;
            return "Method4";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, my name is " + typeof(Program).Name);
            var inst = (IFace<int>)new Program();
            Console.WriteLine(inst.Method1(1, 2));
            Console.WriteLine(inst.Method2(1, 2));
            Console.WriteLine(inst.Method3(1, out var _));
            Console.WriteLine(inst.Method4(1, out _));
        }
    }
}
