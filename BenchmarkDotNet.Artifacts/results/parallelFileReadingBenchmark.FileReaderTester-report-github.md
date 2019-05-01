``` ini

BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.4 (18E226) [Darwin 18.5.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100-preview3-010431
  [Host]     : .NET Core 3.0.0-preview3-27503-5 (CoreCLR 4.6.27422.72, CoreFX 4.7.19.12807), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0-preview3-27503-5 (CoreCLR 4.6.27422.72, CoreFX 4.7.19.12807), 64bit RyuJIT


```
|       Method |     Mean |     Error |    StdDev |    Gen 0 |    Gen 1 | Gen 2 | Allocated |
|------------- |---------:|----------:|----------:|---------:|---------:|------:|----------:|
| ParallelTest | 1.116 ms | 0.0093 ms | 0.0087 ms | 378.9063 | 146.4844 |     - | 107.03 KB |
|   NormalTest | 1.028 ms | 0.0121 ms | 0.0113 ms | 287.1094 |  93.7500 |     - | 563.03 KB |
