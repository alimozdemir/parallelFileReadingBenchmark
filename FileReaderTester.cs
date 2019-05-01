using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace parallelFileReadingBenchmark
{
    [MemoryDiagnoser]
    public class FileReaderTester
    {
        [Benchmark]
        public void ParallelTest()
        {
            var counter = new ConcurrentDictionary<string, float> ();

            Parallel.ForEach(File.ReadLines("data.csv"), (line) => {
                ProcessLineParallel(counter, line);
            });

            if (counter.Count != 1000)
                throw new Exception("Not expected count of persons.");
        }

        [Benchmark]
        public void NormalTest()
        {
            var counter = new Dictionary<string, float> ();
            var allLines = File.ReadAllLines("data.csv");
            foreach (var line in allLines)
            {
                ProcessLine(counter, line);
            }

            if (counter.Count != 1000)
                throw new Exception("Not expected count of persons.");
        }


        public void ProcessLine(Dictionary<string, float> counter, string line)
        {
            if (string.IsNullOrEmpty(line))
                return;

            var splitted = line.Split(',');
            var personName = splitted[0];

            var total = 0f;
            for (int i = 1; i < 5; i++)
            {
                var transaction = splitted[i];

                if (float.TryParse(transaction, out var t))
                    total += t;
                else
                    throw new Exception("The line is corrupted");
            }

            counter.Add(personName, total);
        }

        public void ProcessLineParallel(ConcurrentDictionary<string, float> counter, string line)
        {
            if (string.IsNullOrEmpty(line))
                return;

            var splitted = line.Split(',');
            var personName = splitted[0];

            var total = 0f;
            for (int i = 1; i < 5; i++)
            {
                var transaction = splitted[i];

                if (float.TryParse(transaction, out var t))
                    total += t;
                else
                    throw new Exception("The line is corrupted");
            }

            if (!counter.TryAdd(personName, total))
                throw new Exception("Can't add person to dictionary.");
        }
    }
}