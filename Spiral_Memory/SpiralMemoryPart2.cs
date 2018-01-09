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
            if (currentCoord.X == 0 && currentCoord.Y == 0)
            {
                return new Coord(1,0);
            }

            if (grid.DoesBlockOnTheLeftExist(currentCoord))
            {
                if (grid.DoesBlockAboveExist(currentCoord))
                {
                    return Coord.ImmediateRight(currentCoord);
                }
                return Coord.ImmediateAbove(currentCoord); 
            }
            else if (grid.DoesBlockBelowExist(currentCoord))
            {
                return Coord.ImmediateLeft(currentCoord);
            }
            else if (grid.DoesBlockOnTheRigthExist(currentCoord))
            {
                return Coord.ImmediateBelow(currentCoord);
            }
            else if (grid.DoesBlockAboveExist(currentCoord))
            {
                return Coord.ImmediateRight(currentCoord);
            }

            throw new NotImplementedException();
        }
        
        private int Calculate(Coord currentCoord, Grid grid)
        {
            if (currentCoord.X == 0 && currentCoord.Y == 0)
            {
                return 1;
            }
            
            return 1;
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

        public static Coord ImmediateLeft(Coord currentCoord)
        {
            return new Coord(currentCoord.X - 1, currentCoord.Y);
        }

        public static Coord ImmediateRight(Coord currentCoord)
        {
            return new Coord(currentCoord.X +1, currentCoord.Y);
        }


        public static Coord ImmediateBelow(Coord currentCoord)
        {
            return new Coord(currentCoord.X, currentCoord.Y-1);
        }

        public static Coord ImmediateAbove(Coord currentCoord)
        {
            return new Coord(currentCoord.X, currentCoord.Y + 1);
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

        public bool DoesBlockExist(Coord currentCoord)
        {
            return Get(currentCoord.X, currentCoord.Y) != 0;
        }


        public bool DoesBlockOnTheLeftExist(Coord currentCoord)
        {
            return DoesBlockExist(Coord.ImmediateLeft(currentCoord));
        }

        public bool DoesBlockOnTheRigthExist(Coord currentCoord)
        {
            return DoesBlockExist(Coord.ImmediateRight(currentCoord));
        }

        public bool DoesBlockBelowExist(Coord currentCoord)
        {
            return DoesBlockExist(Coord.ImmediateBelow(currentCoord));
        }

        public bool DoesBlockAboveExist(Coord currentCoord)
        {
            return DoesBlockExist(Coord.ImmediateAbove(currentCoord));
        }

        private string GetKey(int x, int y)
        {
            return $"{x},{y}";
        }
    }
}