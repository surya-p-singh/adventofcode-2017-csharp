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


    public class Rootobject
    {
        public Data data { get; set; }
        public Included[] included { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes attributes { get; set; }
        public Relationships relationships { get; set; }
        public Links links { get; set; }
    }

    public class Attributes
    {
    }

    public class Relationships
    {
        public Voidables voidables { get; set; }
    }

    public class Voidables
    {
        public Datum[] data { get; set; }
        public Meta meta { get; set; }
    }

    public class Meta
    {
        public string count { get; set; }
    }

    public class Datum
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public CreateVoidContext createvoidcontext { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
        public Meta1 meta { get; set; }
    }

    public class Meta1
    {
        public string method { get; set; }
        public string accept { get; set; }
    }

    public class CreateVoidContext
    {
        public string href { get; set; }
        public Meta2 meta { get; set; }
    }

    public class Meta2
    {
        public string method { get; set; }
        public string accept { get; set; }
    }

    public class Included
    {
        public string id { get; set; }
        public string type { get; set; }
        public Attributes1 attributes { get; set; }
        public Relationships1 relationships { get; set; }
        public Links1 links { get; set; }
    }

    public class Attributes1
    {
        public Policy[] policies { get; set; }
    }

    public class Policy
    {
        public string policy { get; set; }
        public bool isVoidable { get; set; }
        public DateTime expiryTimestampUtc { get; set; }
        public Reason reason { get; set; }
    }

    public class Reason
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Relationships1
    {
    }

    public class Links1
    {
        public Self1 self { get; set; }
    }

    public class Self1
    {
        public string href { get; set; }
        public Meta3 meta { get; set; }
    }

    public class Meta3
    {
        public string method { get; set; }
        public string accept { get; set; }
    }

}
