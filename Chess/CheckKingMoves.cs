using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Chess
{
    class CheckKingMoves
    {
        public static bool CheckMove(ChessPiece king, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> Coordinates = Moves(king);
            for (int i = 0; i < Coordinates.Count(); i++)
            {
                if (Coordinates[i].ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static DynamicArray<Coordinate> Moves(ChessPiece king)
        {
            DynamicArray<Coordinate> kingMoves = new DynamicArray<Coordinate>();
            int vertical = king.Coordinate.Vertical, horizontal = king.Coordinate.Horizontal;
            if (vertical + 1 < 9)
                kingMoves.Add(new Coordinate(vertical + 1, horizontal));
            if (vertical - 1 > 0)
                kingMoves.Add(new Coordinate(vertical - 1, horizontal));
            if (horizontal + 1 < 9)
                kingMoves.Add(new Coordinate(vertical, horizontal + 1));
            if (horizontal - 1 > 0)
                kingMoves.Add(new Coordinate(vertical, horizontal - 1));
            if (horizontal - 1 > 0 && vertical - 1 > 0)
                kingMoves.Add(new Coordinate(vertical - 1, horizontal - 1));
            if (horizontal - 1 > 0 && vertical + 1 < 9)
                kingMoves.Add(new Coordinate(vertical + 1, horizontal - 1));
            if (horizontal + 1 < 9 && vertical - 1 > 0)
                kingMoves.Add(new Coordinate(vertical - 1, horizontal + 1));
            if (horizontal + 1 < 9 && vertical + 1 < 9)
                kingMoves.Add(new Coordinate(vertical + 1, horizontal + 1));
            return kingMoves;
        }
        public static DynamicArray<Coordinate> Path(ChessPiece king, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            if (CheckMove(king, endCoordinate))
            {
                moves.Add(endCoordinate);
                return moves;
            }
            else
            {
                return moves;
            }
        }
    }
}
