using System;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;
using BenchmarkDotNet.Attributes;
using System.Threading;
using BenchmarkDotNet.Running;

namespace Sort;

[MemoryDiagnoser]
public class Benchmark
{
    static void Swap(int e1, int e2)
    {
        (e1, e2) = (e2, e1);
    }
    static int[] BubbleSort(int[] array)
    {
        var len = array.Length;
        for (var i = 1; i < len; i++)
        {
            for (var j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array[j], array[j + 1]);
                }
            }
        }
        return array;
    }
    
    public static int[] sort(int[] massive)
    {
        if (massive.Length == 1)
            return massive;
        int mid_point = massive.Length / 2;
        return merge(sort(massive.Take(mid_point).ToArray()), sort(massive.Skip(mid_point).ToArray()));
    }
    public static int[] merge(int[] mass1, int[] mass2)
    {
        int a = 0, b = 0;
        int[] merged = new int[mass1.Length + mass2.Length];
        for (int i = 0; i < mass1.Length + mass2.Length; i++)
        {
            if (b < mass2.Length && a < mass1.Length)
                if (mass1[a] > mass2[b] && b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            else
            if (b < mass2.Length)
                merged[i] = mass2[b++];
            else
                merged[i] = mass1[a++];
        }
        return merged;
    }
    
    
    [Params(100, 10000)]
    public int arraySize;
    public int[] myArray;


    [GlobalSetup]
    public void Setup() {
        Random rand = new Random();
        myArray = new int[arraySize];
        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = rand.Next(20);
        }
    }

    [Benchmark]
    public void BenchmarkMergeSort()
    {
        sort(myArray);
    }
}
