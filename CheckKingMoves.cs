using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class CheckKingMoves
    {
        public static bool CheckMove(ChessPiece king, Coordinate endCoordinate)
        {
            Coordinate[] Coordinates = Moves(king);
            foreach (var coordinateInArray in Coordinates)
            {
                if (coordinateInArray.ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static Coordinate[] Moves(ChessPiece king)
        {
            Coordinate[] kingMoves;
            Coordinate[] allPossibleKingMoves = new Coordinate[8];
            int length = 0;
            int vertical = king.Coordinate.Vertical, horizontal = king.Coordinate.Horizontal;
            if(vertical + 1 < 9)
            {
                allPossibleKingMoves[length] = new Coordinate(vertical + 1, horizontal);
                length++;
            }
            if (vertical - 1 > 0)
            {
                allPossibleKingMoves[length] = new Coordinate(vertical - 1, horizontal);
                length++;
            }
            if (horizontal + 1 < 9)
            {
                allPossibleKingMoves[length] = new Coordinate(vertical, horizontal + 1);
                length++;
            }
            if (horizontal - 1 > 0)
            {
                allPossibleKingMoves[length] = new Coordinate(vertical, horizontal - 1);
                length++;
            }
            if (horizontal - 1 > 0 && vertical - 1 > 0)
            {
                allPossibleKingMoves[length] = new Coordinate(vertical - 1, horizontal - 1);
                length++;
            }
            if (horizontal - 1 > 0 && vertical + 1 < 9)
            {
                allPossibleKingMoves[length] = new Coordinate(vertical + 1, horizontal - 1);
                length++;
            }
            if (horizontal + 1 < 9 && vertical - 1 > 0)
            {
                allPossibleKingMoves[length] = new Coordinate(vertical - 1, horizontal + 1);
                length++;
            }
            if (horizontal + 1 < 9 && vertical + 1 < 9)
            {
                allPossibleKingMoves[length] = new Coordinate(vertical + 1, horizontal + 1);
                length++;
            }
            kingMoves = new Coordinate[length];
            for (int i = 0; i < length; i++)
            {
                kingMoves[i] = allPossibleKingMoves[i];
            }
            return kingMoves;
        }
    }
}
