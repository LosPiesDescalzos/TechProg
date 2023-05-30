``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), Arm64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), Arm64 RyuJIT


```
|             Method | arraySize |        Mean |     Error |   StdDev |     Gen 0 | Allocated |
|------------------- |---------- |------------:|----------:|---------:|----------:|----------:|
| **BenchmarkMergeSort** |       **100** |    **24.17 μs** |  **0.249 μs** | **0.208 μs** |   **10.8643** |     **22 KB** |
| **BenchmarkMergeSort** |     **10000** | **3,055.87 μs** | **11.448 μs** | **9.559 μs** | **1347.6563** |  **2,758 KB** |
