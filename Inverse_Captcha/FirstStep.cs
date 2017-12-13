using System.Collections.Generic;
using System.Linq;

namespace Inverse_Captcha_01
{
    public class FirstStep
    {
        public List<int> FindDuplicates(string str)
        {
            var splitted = str.ToArray();
            var duplicates = new List<int>();
            for (int i = 0; i < splitted.Length-1; i++)
            {
                var current = splitted[i];
                var next = splitted[i + 1];
                if (current == next)
                {
                    duplicates.Add(ConvertToInt(current));
                }
            }

            if (splitted.First() == splitted.Last())
            {
                duplicates.Add(ConvertToInt(splitted.First()));
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