using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class CheckKnightMoves
    {
        public static bool CheckMove(ChessPiece knight, Coordinate endCoordinate)
        {
            Coordinate[] Coordinates = Moves(knight);
            foreach (var coordinateInArray in Coordinates)
            {
                if (coordinateInArray.ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static Coordinate[] Moves(ChessPiece knight)
        {
            Coordinate[] knightMoves;
            Coordinate[] possibleKnightMoves = new Coordinate[8];
            int length = 0;
            if(knight.Coordinate.Vertical + 1 < 9 && knight.Coordinate.Horizontal + 2 < 9 && knight.Coordinate.Vertical + 1 > 0 && knight.Coordinate.Horizontal + 2 > 0)
            {
                possibleKnightMoves[length] = new Coordinate(knight.Coordinate.Vertical + 1, knight.Coordinate.Horizontal + 2);
                length++;
            }
            if (knight.Coordinate.Vertical + 2 < 9 && knight.Coordinate.Horizontal + 1 < 9 && knight.Coordinate.Vertical + 2 >0 && knight.Coordinate.Horizontal + 1 >0)
            {
                possibleKnightMoves[length] = new Coordinate(knight.Coordinate.Vertical + 2, knight.Coordinate.Horizontal + 1);
                length++;
            }
            if (knight.Coordinate.Vertical + 2 < 9 && knight.Coordinate.Horizontal - 1 < 9 && knight.Coordinate.Vertical + 2 > 0 && knight.Coordinate.Horizontal - 1 > 0)
            {
                possibleKnightMoves[length] = new Coordinate(knight.Coordinate.Vertical + 2, knight.Coordinate.Horizontal -1);
                length++;
            }
            if (knight.Coordinate.Vertical + 1 < 9 && knight.Coordinate.Horizontal - 2 < 9 && knight.Coordinate.Vertical + 1 > 0 && knight.Coordinate.Horizontal - 2 > 0)
            {
                possibleKnightMoves[length] = new Coordinate(knight.Coordinate.Vertical + 1, knight.Coordinate.Horizontal - 2);
                length++;
            }
            if (knight.Coordinate.Vertical - 1 < 9 && knight.Coordinate.Horizontal - 2 < 9 && knight.Coordinate.Vertical - 1 > 0 && knight.Coordinate.Horizontal - 2 > 0)
            {
                possibleKnightMoves[length] = new Coordinate(knight.Coordinate.Vertical - 1, knight.Coordinate.Horizontal - 2);
                length++;
            }
            if (knight.Coordinate.Vertical - 2 < 9 && knight.Coordinate.Horizontal - 1 < 9 && knight.Coordinate.Vertical - 2 > 0 && knight.Coordinate.Horizontal - 1 > 0)
            {
                possibleKnightMoves[length] = new Coordinate(knight.Coordinate.Vertical - 2, knight.Coordinate.Horizontal - 1);
                length++;
            }
            if (knight.Coordinate.Vertical - 2 < 9 && knight.Coordinate.Horizontal + 1 < 9 && knight.Coordinate.Vertical - 2 > 0 && knight.Coordinate.Horizontal + 1 > 0)
            {
                possibleKnightMoves[length] = new Coordinate(knight.Coordinate.Vertical - 2, knight.Coordinate.Horizontal + 1);
                length++;
            }
            if (knight.Coordinate.Vertical - 1 < 9 && knight.Coordinate.Horizontal + 2 < 9 && knight.Coordinate.Vertical - 1 > 0 && knight.Coordinate.Horizontal + 2 > 0)
            {
                possibleKnightMoves[length] = new Coordinate(knight.Coordinate.Vertical - 1, knight.Coordinate.Horizontal + 2);
                length++;
            }
            knightMoves = new Coordinate[length];
            for (int i = 0; i < length; i++)
            {
                knightMoves[i] = possibleKnightMoves[i];
            }
            return knightMoves;
        }
        public static Coordinate[] Path(ChessPiece knight, Coordinate endCoordinate)
        {
            Coordinate[] Path = new Coordinate[1];
            if (CheckMove(knight, endCoordinate))
            {
                Path[0] = endCoordinate;
            }
            return Path;
        }
    }
}
