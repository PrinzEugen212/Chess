using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class CheckQueenMoves
    {
        public static bool CheckMove(ChessPiece queen, Coordinate endCoordinate)
        {
            Coordinate[] Coordinates = Moves(queen);
            foreach (var coordinateInArray in Coordinates)
            {
                if (coordinateInArray.ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static Coordinate[] Moves(ChessPiece queen)
        {
            Coordinate[] queenMoves;
            Coordinate[] Bishop = CheckBishopMoves.Moves(queen), Rock = CheckRockMoves.Moves(queen);
            int length = Bishop.Length + Rock.Length;
            queenMoves = new Coordinate[length]; // rock always have maximum 14 moves, they do not depend on the piece color
            for (int i = 0; i < Bishop.Length; i++)
            {
                queenMoves[i] = Bishop[i];
            }
            for (int i = 0; i < Rock.Length; i++)
            {
                queenMoves[i + Bishop.Length] = Rock[i];
            }
            return queenMoves;
        }
    }
}
