``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Monterey 12.1 (21C52) [Darwin 21.2.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.200
  [Host]     : .NET 6.0.2 (6.0.222.6406), Arm64 RyuJIT
  DefaultJob : .NET 6.0.2 (6.0.222.6406), Arm64 RyuJIT


```
|             Method | arraySize |          Mean |     Error |    StdDev | Allocated |
|------------------- |---------- |--------------:|----------:|----------:|----------:|
| **BenchmarkMergeSort** |       **100** |      **4.410 μs** | **0.0183 μs** | **0.0171 μs** |         **-** |
| **BenchmarkMergeSort** |     **10000** | **38,500.292 μs** | **7.9914 μs** | **7.4752 μs** |      **52 B** |
