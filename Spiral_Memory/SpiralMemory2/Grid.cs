using System.Collections.Generic;

namespace Spiral_Memory
{
    public class Grid
    {
        private readonly Dictionary<string, int> _dict = new Dictionary<string, int>();

        public int Get(int x, int y)
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
        }

        private bool DoesBlockExist(Coordinate currentCoordinate)
        {
            return Get(currentCoordinate.X, currentCoordinate.Y) != 0;
        }

        public bool DoesBlockOnTheLeftExist(Coordinate currentCoordinate)
        {
            return DoesBlockExist(Coordinate.ImmediateLeft(currentCoordinate));
        }

        public bool DoesBlockOnTheRightExist(Coordinate currentCoordinate)
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