using System;
using BenchmarkDotNet.Running;

namespace parallelFileReadingBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<FileReaderTester>();
        }
    }
}
