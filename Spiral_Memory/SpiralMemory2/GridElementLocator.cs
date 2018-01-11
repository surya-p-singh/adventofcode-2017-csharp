using System;

namespace Spiral_Memory
{
    public class GridElementLocator
    {
        public Coordinate FindNextCoordinate(Coordinate currentCoordinate, Grid grid)
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
            if (grid.DoesBlockOnTheRightExist(currentCoordinate))
            {
                return Coordinate.ImmediateBelow(currentCoordinate);
            }
            if (grid.DoesBlockAboveExist(currentCoordinate))
            {
                return Coordinate.ImmediateRight(currentCoordinate);
            }

            throw new NotImplementedException();
        }

        public int Calculate(Coordinate currentCoordinate, Grid grid)
        {
            if (currentCoordinate.X == 0 && currentCoordinate.Y == 0)
            {
                return 1;
            }

            var number = 0;

            foreach (var adjacentCell in Coordinate.AdjacentCells(currentCoordinate))
            {
                number += grid.Get(adjacentCell.X, adjacentCell.Y);
            }

            return number;
        }
    }
}