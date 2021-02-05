using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    abstract class CheckRockMoves
    {
        public static bool CheckMove(ChessPiece rock, Coordinate endCoordinate)
        {
            Coordinate[] Coordinates = Moves(rock);
            foreach (var coordinateInArray in Coordinates)
            {
                if (coordinateInArray.ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static Coordinate[] Moves(ChessPiece rock)
        {
            Coordinate[] rockMoves = new Coordinate[14];
            int length = 0;
            int startVertical = rock.Coordinate.Vertical, startHorizontal = rock.Coordinate.Horizontal;
            int vertical = startVertical, horizontal = startHorizontal;
            while (vertical < 8)
            {
                vertical++;
                rockMoves[length] = new Coordinate(vertical, horizontal);
                length++;
            }
            vertical = startVertical;
            while (horizontal > 1)
            {
                horizontal--;
                rockMoves[length] = new Coordinate(vertical, horizontal);
                length++;
            }
            horizontal = startHorizontal;
            while (horizontal < 8)
            {
                horizontal++;
                rockMoves[length] = new Coordinate(vertical, horizontal);
                length++;
            }
            horizontal = startHorizontal;
            while (vertical > 1)
            {
                vertical--;
                rockMoves[length] = new Coordinate(vertical, horizontal);
                length++;
            }
            return rockMoves;
        }
    }
}

