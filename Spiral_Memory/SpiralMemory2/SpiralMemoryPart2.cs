using System;
using NUnit.Framework;

namespace Spiral_Memory
{
    public class SpiralMemoryPart2
    {
        [Test]
        public void Start()
        {
            var input = 500000;

            var grid = new Grid();

            var currentCoordinate = new Coordinate(0, 0);
            int newValue = 1;
            grid.Set(currentCoordinate, newValue);
            var gridElementLocator = new GridElementLocator();
            while (newValue < input)
            {
                currentCoordinate = gridElementLocator.FindNextCoordinate(currentCoordinate, grid);
               // Console.WriteLine($"Current coordinate:{currentCoordinate.X},{currentCoordinate.Y}");

                newValue = gridElementLocator.Calculate(currentCoordinate, grid);
                Console.WriteLine($"    New value:{newValue}");

                grid.Set(currentCoordinate, newValue);
            }
        }

        
    }
}