using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Corruption_Checksum
{
    [TestFixture]
    public class FirstStepChecksumCalculator
    {
        [Test]
        public void Calculate()
        {
            var tabSeparatedLines = File.ReadAllLines(@"input.txt");

            List<List<int>> rows = new List<List<int>>();
            foreach (var tabSeparatedLine in tabSeparatedLines)
            {
                var row = tabSeparatedLine.Split('\t');

                var rowOfInts = row.Select(x => Convert.ToInt32(x));
                rows.Add(rowOfInts.ToList());
            }

            int sum = 0;
            foreach (var row in rows)
            {
                var min = row.Min();
                var max = row.Max();
                var diff = max - min;
                sum += diff;
            }

            Console.WriteLine(sum);

        }
    }
}
