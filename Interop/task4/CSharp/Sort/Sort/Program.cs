using System;
using BenchmarkDotNet.Running;
using Sort;

class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<Benchmark>();
    }
}