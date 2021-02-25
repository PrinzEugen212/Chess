using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Chess
{
    public class King : ChessPiece
    {
        public override char Type { get; } = 'K';
        public King(string coordinate, bool color) : base(coordinate, color)
        {

        }
        public King(Coordinate coordinate, string color) : base(coordinate, color)
        {

        }
        public King() { }

        public override bool CheckMove( Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> Coordinates = Moves();
            for (int i = 0; i < Coordinates.Count(); i++)
            {
                if (Coordinates[i].ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public override DynamicArray<Coordinate> Moves()
        {
            King king = this;
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
        public override DynamicArray<Coordinate> Path(Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            if (CheckMove(endCoordinate))
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
