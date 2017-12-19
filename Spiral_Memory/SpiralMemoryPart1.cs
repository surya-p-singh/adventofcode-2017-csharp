using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Spiral_Memory
{
    [TestFixture]
    public class Class1
    {
        [TestCase(27, 4)]
        [TestCase(35, 4)]
        [TestCase(42, 5)]
        [TestCase(48, 5)]
        [TestCase(18, 3)]
        [TestCase(43, 6)]
        [TestCase(37, 6)]
        [TestCase(31, 6)]
        [TestCase(49, 6)]
        [TestCase(26, 5)]
        [TestCase(25, 4)]
        [TestCase(9, 2)]
        [TestCase(8, 1)]
        [TestCase(2, 1)]
        [TestCase(10, 3)]
        [TestCase(347991, 480)]
        public void A(int input, int expected)
        {

            //var input = 27;
            //var input = 347991;
            int lastSpiralLength = 0;

            var sqrt = Math.Sqrt(input);
            
            if (IsAOddInteger(sqrt))
            {
                lastSpiralLength = (int)sqrt;
            }
            else if (IsAEvenInteger(sqrt))
            {
                lastSpiralLength = (int) sqrt +1;
            }
            else
            {
                lastSpiralLength = (int)sqrt + 2;
            }

            var lastSpiralMax = Math.Pow(lastSpiralLength, 2);

            double lastSpiralLengthDividedByTwo = lastSpiralLength / 2;
            var centrePoint = Math.Floor(lastSpiralLengthDividedByTwo);

            var position = Math.Abs(input - lastSpiralMax);

            var bottomRightPoint = lastSpiralMax;
            var bottomLeftPoint = lastSpiralMax - (lastSpiralLength-1);
            var topLeftPoint = bottomLeftPoint - (lastSpiralLength - 1);
            var topRightPoint = topLeftPoint - (lastSpiralLength - 1);

            var right = topRightPoint - input;
            var top = topLeftPoint - input;
            var left = bottomLeftPoint - input;
            var bottom = bottomRightPoint - input;

            double value = 0;
            if (right < lastSpiralLength && right >= 0)
            {
                value = topRightPoint - centrePoint - input;
                Console.WriteLine(value + (int)centrePoint);
            }

            if (top < lastSpiralLength && top >= 0)
            {
                value = topLeftPoint - centrePoint - input;
                Console.WriteLine(Math.Abs(value) + (int)centrePoint);
            }

            if (left < lastSpiralLength && left >= 0)
            {
                value = bottomLeftPoint - centrePoint - input;
                Console.WriteLine(Math.Abs(value) + (int)centrePoint);
            }

            if (bottom < lastSpiralLength && bottom >= 0)
            {
                value = bottomRightPoint - centrePoint - input;
                Console.WriteLine(Math.Abs(value) + (int)centrePoint);
            }

            Assert.That((int)(Math.Abs(value) + (int)centrePoint), Is.EqualTo(expected));
        }

        private static bool IsAEvenInteger(double sqrt)
        {
            return Math.Floor(sqrt) % 2 == 0;
        }

        private static bool IsAOddInteger(double sqrt)
        {
            return sqrt % 1 == 0 && sqrt % 2 == 1;
        }
    }
}
