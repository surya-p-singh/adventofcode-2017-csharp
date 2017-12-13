using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inverse_Captcha_01
{

    public class SecondStepHalfwayAround
    {
        public List<int> FindDuplicates(string str)
        {
            var splitted = str.ToArray();
            var duplicates = new List<int>();

            int midLength = splitted.Length / 2;
            for (int i = 0; i < splitted.Length; i++)
            {
                var current = splitted[i];
                int nextIndex;

                if (i + midLength >= splitted.Length)
                    nextIndex = (i + midLength) - splitted.Length;
                else
                    nextIndex = i + midLength;

                var next = splitted[nextIndex];

                if (current == next)
                {
                    duplicates.Add(ConvertToInt(current));
                }
            }

            return duplicates;
        }

        public int Sum(List<int> list)
        {
            return list.Sum(x => x);
        }

        private static int ConvertToInt(char current)
        {
            int duplicateItem;
            int.TryParse(current.ToString(), out duplicateItem);
            return duplicateItem;
        }
    }
}
