using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace lab1
{
    internal class Program
    {
        [DllImport("/Users/kate/Desktop/TechProg/lab-1/task1/CSharpCpp/cmake-build-debug/libtask1.dylib",
            CallingConvention = CallingConvention.Cdecl)]
        private static extern int sum(int a, int b);

        public static void Main(string[] args )
        {
            Console.WriteLine(sum(5,9));
        }

    }
}
