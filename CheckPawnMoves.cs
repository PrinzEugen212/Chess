using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    abstract class CheckPawnMoves 
    {
        public static bool CheckMove(ChessPiece pawn, Coordinate endCoordinate)
        {
            Coordinate[] Coordinates = Moves(pawn);
            foreach (var coordinateInArray in Coordinates)
            {
                if(coordinateInArray.ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static Coordinate[] Moves(ChessPiece pawn)
        {
            Coordinate[] pawnMoves;
            if (pawn.Color == "White" ){
                if (pawn.Coordinate.Horizontal == 2) // start horizontal for white
                {
                    pawnMoves = new Coordinate[2]; // only two cells for move
                    for (int i = 0; i < pawnMoves.Length; i++)
                    {
                        pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1);
                    }
                }
                else
                {
                    pawnMoves = new Coordinate[1]; // only one cells for move
                    for (int i = 0; i < pawnMoves.Length; i++)
                    {
                        pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1);
                    }
                }
            }
            else // color - black
            {
                if (pawn.Coordinate.Horizontal == 7) // start horizontal for black
                {
                    pawnMoves = new Coordinate[2]; // only two cells for move
                    for (int i = 0; i < pawnMoves.Length; i++)
                    {
                        pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1);
                    }
                }
                else
                {
                    pawnMoves = new Coordinate[1]; // only one cells for move
                    for (int i = 0; i < pawnMoves.Length; i++)
                    {
                        pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1);
                    }
                }
            }
            return pawnMoves;
        }
    }
}
