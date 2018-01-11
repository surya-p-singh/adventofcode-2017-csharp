using System.Collections.Generic;

namespace Spiral_Memory
{
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

        public static IList<Coordinate> AdjacentCells(Coordinate currentCoordinate)
        {
            var list = new List<Coordinate>();
            for (var diffX = -1; diffX <= 1; diffX++)
            {
                for (var diffY = -1; diffY <= 1; diffY++)
                {
                    if (diffX == 0 && diffY == 0) continue;

                    var coordinate = new Coordinate(currentCoordinate.X + diffX, currentCoordinate.Y + diffY);
                    list.Add(coordinate);
                }
            }
            return list;
        }
    }
}