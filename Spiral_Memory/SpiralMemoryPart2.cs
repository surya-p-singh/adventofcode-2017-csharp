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

            var currentCoordinate = new Coordinate(0, 0);
            int newValue = 1;
            grid.Set(currentCoordinate, newValue);

            while (newValue < input)
            {
                currentCoordinate = FindNextCoordinate(currentCoordinate, grid);
                Console.WriteLine($"Current coordinate:{currentCoordinate.X},{currentCoordinate.Y}");

                newValue = Calculate(currentCoordinate, grid);
                Console.WriteLine($"    New value:{newValue}");

                grid.Set(currentCoordinate, newValue);
            }
        }

        private Coordinate FindNextCoordinate(Coordinate currentCoordinate, Grid grid)
        {
            if (currentCoordinate.X == 0 && currentCoordinate.Y == 0)
            {
                return new Coordinate(1, 0);
            }

            if (grid.DoesBlockOnTheLeftExist(currentCoordinate))
            {
                if (grid.DoesBlockAboveExist(currentCoordinate))
                {
                    return Coordinate.ImmediateRight(currentCoordinate);
                }
                return Coordinate.ImmediateAbove(currentCoordinate);
            }
            if (grid.DoesBlockBelowExist(currentCoordinate))
            {
                return Coordinate.ImmediateLeft(currentCoordinate);
            }
            if (grid.DoesBlockOnTheRigthExist(currentCoordinate))
            {
                return Coordinate.ImmediateBelow(currentCoordinate);
            }
            if (grid.DoesBlockAboveExist(currentCoordinate))
            {
                return Coordinate.ImmediateRight(currentCoordinate);
            }

            throw new NotImplementedException();
        }

        private int Calculate(Coordinate currentCoordinate, Grid grid)
        {
            if (currentCoordinate.X == 0 && currentCoordinate.Y == 0)
            {
                return 1;
            }

            return 1;
        }
    }

    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate ImmediateLeft(Coordinate currentCoordinate)
        {
            return new Coordinate(currentCoordinate.X - 1, currentCoordinate.Y);
        }

        public static Coordinate ImmediateRight(Coordinate currentCoordinate)
        {
            return new Coordinate(currentCoordinate.X + 1, currentCoordinate.Y);
        }

        public static Coordinate ImmediateBelow(Coordinate currentCoordinate)
        {
            return new Coordinate(currentCoordinate.X, currentCoordinate.Y - 1);
        }

        public static Coordinate ImmediateAbove(Coordinate currentCoordinate)
        {
            return new Coordinate(currentCoordinate.X, currentCoordinate.Y + 1);
        }
    }

    public class Grid
    {
        private readonly Dictionary<string, int> _dict = new Dictionary<string, int>();

        private int Get(int x, int y)
        {
            var key = GetKey(x, y);
            if (!_dict.ContainsKey(key)) return 0;
            return _dict[key];
        }

        public void Set(Coordinate coordinate, int value)
        {
            Set(coordinate.X, coordinate.Y, value);
        }

        public void Set(int x, int y, int value)
        {
            var key = GetKey(x, y);
            _dict.Add(key, value);
            // it will throw exception if value already exists, which good for us
        }

        private bool DoesBlockExist(Coordinate currentCoordinate)
        {
            return Get(currentCoordinate.X, currentCoordinate.Y) != 0;
        }

        public bool DoesBlockOnTheLeftExist(Coordinate currentCoordinate)
        {
            return DoesBlockExist(Coordinate.ImmediateLeft(currentCoordinate));
        }

        public bool DoesBlockOnTheRigthExist(Coordinate currentCoordinate)
        {
            return DoesBlockExist(Coordinate.ImmediateRight(currentCoordinate));
        }

        public bool DoesBlockBelowExist(Coordinate currentCoordinate)
        {
            return DoesBlockExist(Coordinate.ImmediateBelow(currentCoordinate));
        }

        public bool DoesBlockAboveExist(Coordinate currentCoordinate)
        {
            return DoesBlockExist(Coordinate.ImmediateAbove(currentCoordinate));
        }

        private string GetKey(int x, int y)
        {
            return $"{x},{y}";
        }
    }
}