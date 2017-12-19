using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Spiral_Memory
{
    [TestFixture]
    public class SpiralMemoryPart1
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
            int numberOfElementsInLastSpiral;

            var sqrt = Math.Sqrt(input);
            
            if (IsOddInteger(sqrt))
            {
                numberOfElementsInLastSpiral = (int)sqrt;
            }
            else if (IsEvenInteger(sqrt))
            {
                numberOfElementsInLastSpiral = (int) sqrt + 1;
            }
            else
            {
                numberOfElementsInLastSpiral = (int)sqrt + 2;
            }

            var maxNumberInLastSpiral = Math.Pow(numberOfElementsInLastSpiral, 2);

            double lastSpiralLengthDividedByTwo = numberOfElementsInLastSpiral / 2;
            var centralPoint = Math.Floor(lastSpiralLengthDividedByTwo);

            var bottomRightCornerNumber = maxNumberInLastSpiral;
            var bottomLeftCornerNumber = maxNumberInLastSpiral - (numberOfElementsInLastSpiral-1);
            var topLeftCornerNumber = bottomLeftCornerNumber - (numberOfElementsInLastSpiral - 1);
            var topRightCornerNumber = topLeftCornerNumber - (numberOfElementsInLastSpiral - 1);

            double value = 0;
            if (IsNumberExistInRightSideOfSquare(topRightCornerNumber, input, numberOfElementsInLastSpiral))
            {
                value = topRightCornerNumber - centralPoint - input;
            }

            if (IsNumberExistInTopSideOfSquare(topLeftCornerNumber, input, numberOfElementsInLastSpiral))
            {
                value = topLeftCornerNumber - centralPoint - input;
            }

            if (IsNumberExistInLeftSideOfSquare(bottomLeftCornerNumber, input, numberOfElementsInLastSpiral))
            {
                value = bottomLeftCornerNumber - centralPoint - input;
            }

            if (IsNumberExistInBottomSideOfSquare(bottomRightCornerNumber, input, numberOfElementsInLastSpiral))
            {
                value = bottomRightCornerNumber - centralPoint - input;
            }

            var distanceFromCenter = (int)(Math.Abs(value) + (int)centralPoint);

            Assert.That(distanceFromCenter, Is.EqualTo(expected));
        }

        private static bool IsOddInteger(double sqrt)
        {
            return sqrt % 1 == 0 && sqrt % 2 == 1;
        }

        private static bool IsEvenInteger(double sqrt)
        {
            return Math.Floor(sqrt) % 2 == 0;
        }

        private bool IsNumberExistInBottomSideOfSquare(double bottomRightCornerNumber, int input, int numberOfElementsInLastSpiral)
        {
            var calculation = bottomRightCornerNumber - input;
            return calculation < numberOfElementsInLastSpiral && calculation >= 0;
        }

        private bool IsNumberExistInLeftSideOfSquare(double bottomLeftCornerNumber, int input, int numberOfElementsInLastSpiral)
        {
            var calculation = bottomLeftCornerNumber - input;
            return calculation < numberOfElementsInLastSpiral && calculation >= 0;
        }

        private bool IsNumberExistInTopSideOfSquare(double topLeftCornerNumber, int input, int numberOfElementsInLastSpiral)
        {
            var calculation = topLeftCornerNumber - input;
            return calculation < numberOfElementsInLastSpiral && calculation >= 0;
        }

        private static bool IsNumberExistInRightSideOfSquare(double topRightCornerNumber, double input, int numberOfElementsInLastSpiral)
        {
            var calculation = topRightCornerNumber - input;
            return calculation < numberOfElementsInLastSpiral && calculation >= 0;
        }
    }
}
