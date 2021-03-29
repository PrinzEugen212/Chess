using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Chess
{
    public class Queen : ChessPiece
    {
        public override char Type { get; } = 'Q';
        public Queen(string coordinate, bool color) : base(coordinate, color)
        {

        }
        public Queen(Coordinate coordinate, string color) : base(coordinate, color)
        {

        }

        public override bool CheckMove(Coordinate endCoordinate)
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
            Queen queen = this;
            Bishop bishop = new Bishop(queen.Coordinate, queen.Color); Rock rock = new Rock(queen.Coordinate, queen.Color);
            DynamicArray<Coordinate> Bishop = bishop.Moves(), Rock = rock.Moves();
            DynamicArray<Coordinate> queenMoves = new DynamicArray<Coordinate>(); // rock always have maximum 14 moves, they do not depend on the piece color
            for (int i = 0; i < Bishop.Count(); i++)
            {
                queenMoves.Add(Bishop[i]);
            }
            for (int i = 0; i < Rock.Count(); i++)
            {
                queenMoves.Add(Rock[i]);
            }
            return queenMoves;
        }
        public override DynamicArray<Coordinate> Path(Coordinate endCoordinate)
        {
            Queen queen = this;
            DynamicArray<Coordinate> queenPath;
            
            if (Math.Abs(queen.Coordinate.Vertical - endCoordinate.Vertical) != 0 && Math.Abs(queen.Coordinate.Horizontal - endCoordinate.Horizontal) != 0)
            {
                Bishop bishop = new Bishop(queen.Coordinate, queen.Color);
                queenPath = bishop.Path(endCoordinate);
            }
            else
            {
                Rock rock = new Rock(queen.Coordinate, queen.Color);
                queenPath = rock.Path(endCoordinate);
            }
            return queenPath;
        }
    }
}
