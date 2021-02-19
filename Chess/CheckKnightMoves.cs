using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Chess
{
    class CheckKnightMoves
    {
        public static bool CheckMove(ChessPiece knight, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> Coordinates = Moves(knight);
            for (int i = 0; i < Coordinates.Count(); i++)
            {
                if (Coordinates[i].ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static DynamicArray<Coordinate> Moves(ChessPiece knight)
        {
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            if(knight.Coordinate.Vertical + 1 < 9 && knight.Coordinate.Horizontal + 2 < 9 && knight.Coordinate.Vertical + 1 > 0 && knight.Coordinate.Horizontal + 2 > 0)
                moves.Add(new Coordinate(knight.Coordinate.Vertical + 1, knight.Coordinate.Horizontal + 2));
            if (knight.Coordinate.Vertical + 2 < 9 && knight.Coordinate.Horizontal + 1 < 9 && knight.Coordinate.Vertical + 2 >0 && knight.Coordinate.Horizontal + 1 >0)
                moves.Add(new Coordinate(knight.Coordinate.Vertical + 2, knight.Coordinate.Horizontal + 1));
            if (knight.Coordinate.Vertical + 2 < 9 && knight.Coordinate.Horizontal - 1 < 9 && knight.Coordinate.Vertical + 2 > 0 && knight.Coordinate.Horizontal - 1 > 0)
                moves.Add(new Coordinate(knight.Coordinate.Vertical + 2, knight.Coordinate.Horizontal - 1));
            if (knight.Coordinate.Vertical + 1 < 9 && knight.Coordinate.Horizontal - 2 < 9 && knight.Coordinate.Vertical + 1 > 0 && knight.Coordinate.Horizontal - 2 > 0)
                moves.Add(new Coordinate(knight.Coordinate.Vertical + 1, knight.Coordinate.Horizontal - 2));
            if (knight.Coordinate.Vertical - 1 < 9 && knight.Coordinate.Horizontal - 2 < 9 && knight.Coordinate.Vertical - 1 > 0 && knight.Coordinate.Horizontal - 2 > 0)
                moves.Add(new Coordinate(knight.Coordinate.Vertical - 1, knight.Coordinate.Horizontal - 2));
            if (knight.Coordinate.Vertical - 2 < 9 && knight.Coordinate.Horizontal - 1 < 9 && knight.Coordinate.Vertical - 2 > 0 && knight.Coordinate.Horizontal - 1 > 0)
                moves.Add(new Coordinate(knight.Coordinate.Vertical - 2, knight.Coordinate.Horizontal - 1));
            if (knight.Coordinate.Vertical - 2 < 9 && knight.Coordinate.Horizontal + 1 < 9 && knight.Coordinate.Vertical - 2 > 0 && knight.Coordinate.Horizontal + 1 > 0)
                moves.Add(new Coordinate(knight.Coordinate.Vertical - 2, knight.Coordinate.Horizontal + 1));
            if (knight.Coordinate.Vertical - 1 < 9 && knight.Coordinate.Horizontal + 2 < 9 && knight.Coordinate.Vertical - 1 > 0 && knight.Coordinate.Horizontal + 2 > 0)
                moves.Add(new Coordinate(knight.Coordinate.Vertical - 1, knight.Coordinate.Horizontal + 2));
            return moves;
        }
        public static DynamicArray<Coordinate> Path(ChessPiece knight, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            if (CheckMove(knight, endCoordinate))
                moves[0] = endCoordinate;
            return moves;
        }
    }
}
