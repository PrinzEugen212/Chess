using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Chess
{
    class CheckQueenMoves
    {
        public static bool CheckMove(ChessPiece queen, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> Coordinates = Moves(queen);
            for (int i = 0; i < Coordinates.Count(); i++)
            {
                if (Coordinates[i].ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static DynamicArray<Coordinate> Moves(ChessPiece queen)
        {
            DynamicArray<Coordinate> Bishop = CheckBishopMoves.Moves(queen), Rock = CheckRockMoves.Moves(queen);
            DynamicArray<Coordinate> queenMoves = new DynamicArray<Coordinate>(); // rock always have maximum 14 moves, they do not depend on the piece color
            for (int i = 0; i < Bishop.Count(); i++)
            {
                queenMoves[i] = Bishop[i];
            }
            for (int i = 0; i < Rock.Count(); i++)
            {
                queenMoves[i + Bishop.Count()] = Rock[i];
            }
            return queenMoves;
        }
        public static DynamicArray<Coordinate> Path(ChessPiece queen, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> queenPath;
            if(Math.Abs(queen.Coordinate.Vertical - endCoordinate.Vertical) == 1 && Math.Abs(queen.Coordinate.Horizontal - endCoordinate.Horizontal) == 1)
            {
                queenPath = CheckBishopMoves.Path(queen, endCoordinate);
            }
            else
            {
                queenPath = CheckRockMoves.Path(queen, endCoordinate);
            }
            return queenPath;
        }
    }
}
