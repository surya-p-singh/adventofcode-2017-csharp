using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Spiral_Memory
{
    public class SpiralMemoryPart2
    {
        [Test]
        public void Start()
        {
            var input = 10;

            var grid = new Grid();

            var currentCoord = new Coord(0,0);
            int newValue = 1;
            grid.Set(currentCoord, newValue);
            
            while (newValue < input)
            {
                currentCoord = FindNewCoord(currentCoord, grid);
                Console.WriteLine($"Current coordinate:{currentCoord.X},{currentCoord.Y}");

                newValue = Calculate(currentCoord, grid);
                Console.WriteLine($"    New value:{newValue}");

                grid.Set(currentCoord, newValue);
            }
        }

        private Coord FindNewCoord(Coord currentCoord, Grid grid)
        {
            throw new NotImplementedException();
        }


        private int Calculate(Coord currentCoord, Grid grid)
        {
            throw new NotImplementedException();
        }
    }

    public class Coord
    {
        public int X { get;  }
        public int Y { get; }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Grid
    {
        private readonly Dictionary<string,int> _dict = new Dictionary<string, int>();

        public int Get(int x, int y)
        {
            var key = GetKey(x, y);
            if (!_dict.ContainsKey(key)) return 0;
            return _dict[key];
        }

        public void Set(Coord coord, int value)
        {
            Set(coord.X, coord.Y, value);
        }

        public void Set(int x, int y, int value)
        {
            var key = GetKey(x, y);
            _dict.Add(key,value);            
            // it will throw exception if value already exists, which good for us
        }

        private string GetKey(int x, int y)
        {
            return $"{x},{y}";
        }


    }
}