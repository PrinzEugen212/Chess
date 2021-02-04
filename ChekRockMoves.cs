using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    abstract class ChekRockMoves
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
            Coordinate[] rockMoves;
            rockMoves = new Coordinate[14]; // rock always have maximum 14 moves, they do not depend on the piece color
            Coordinate startCoord = rock.Coordinate;
            for (int i = 0; i < rockMoves.Length/2; i++)
            {
                rockMoves[i] =  new Coordinate(rock.Coordinate.Vertical, i + 2); // all available horizontals
                rockMoves[i+7] = new Coordinate(i+2, rock.Coordinate.Horizontal); // all available verticals
            }
            return rockMoves;
        }
    }
}

