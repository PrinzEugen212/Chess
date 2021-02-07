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
                    if (pawn.Coordinate.Vertical == 1)// side vertical check
                    {
                        pawnMoves = new Coordinate[3]; // only two cells for move and one for take
                        for (int i = 0; i < pawnMoves.Length / 2; i++)
                        {
                            pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1);
                        }
                        pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal + 1);
                    }
                    else if (pawn.Coordinate.Vertical == 8)// side vertical check
                    {
                        pawnMoves = new Coordinate[3]; // only two cells for move and one for take
                        for (int i = 0; i < pawnMoves.Length / 2; i++)
                        {
                            pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1);
                        }
                        pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal + 1);
                    }
                    else
                    {
                        pawnMoves = new Coordinate[4]; // only two cells for move and two for take
                        for (int i = 0; i < pawnMoves.Length / 2; i++)
                        {
                            pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1);
                        }
                        pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal + 1);
                        pawnMoves[3] = new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal + 1);
                    }
                }
                else
                {
                    if(pawn.Coordinate.Horizontal + 1 < 9)
                    {
                        if (pawn.Coordinate.Vertical == 1)// side vertical check
                        {
                            pawnMoves = new Coordinate[3]; // only two cells for move and one for take
                            for (int i = 0; i < pawnMoves.Length / 2; i++)
                            {
                                pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1);
                            }
                            pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal + 1);
                        }
                        else if (pawn.Coordinate.Vertical == 8)// side vertical check
                        {
                            pawnMoves = new Coordinate[3]; // only two cells for move and one for take
                            for (int i = 0; i < pawnMoves.Length / 2; i++)
                            {
                                pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1);
                            }
                            pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal + 1);
                        }
                        else
                        {
                            pawnMoves = new Coordinate[3]; // only one cells for move and two for take
                            pawnMoves[0] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + 1);
                            pawnMoves[1] = new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal + 1);
                            pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal + 1);
                        }
                    }
                    else
                    {
                        pawnMoves = new Coordinate[0];
                    }
                }
            }
            else // color - black
            {
                if (pawn.Coordinate.Horizontal == 7) // start horizontal for black
                {
                    if(pawn.Coordinate.Vertical == 1)// side vertical check
                    {
                        pawnMoves = new Coordinate[3]; // only two cells for move and two for take
                        for (int i = 0; i < pawnMoves.Length / 2; i++)
                        {
                            pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1);
                        }
                        pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal - 1);
                    }
                    else if (pawn.Coordinate.Vertical == 8)// side vertical check
                    {
                        pawnMoves = new Coordinate[3]; // only two cells for move and two for take
                        for (int i = 0; i < pawnMoves.Length / 2; i++)
                        {
                            pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1);
                        }
                        pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal - 1);
                    }
                    else
                    {
                        pawnMoves = new Coordinate[4]; // only two cells for move and two for take
                        for (int i = 0; i < pawnMoves.Length / 2; i++)
                        {
                            pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1);
                        }
                        pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal - 1);
                        pawnMoves[3] = new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal - 1);
                    }
                }
                else
                {
                    if (pawn.Coordinate.Horizontal - 1 > 0)
                    {
                        if (pawn.Coordinate.Vertical == 1) // side vertical check
                        {
                            pawnMoves = new Coordinate[3]; // only two cells for move and one for take
                            for (int i = 0; i < pawnMoves.Length / 2; i++)
                            {
                                pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1);
                            }
                            pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal - 1);
                        }
                        else if (pawn.Coordinate.Vertical == 8)// side vertical check
                        {
                            pawnMoves = new Coordinate[3]; // only two cells for move and one for take
                            for (int i = 0; i < pawnMoves.Length / 2; i++)
                            {
                                pawnMoves[i] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1);
                            }
                            pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal - 1);
                        }
                        else
                        {
                            pawnMoves = new Coordinate[3]; // only one cells for move and two for take
                            pawnMoves[0] = new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - 1);
                            pawnMoves[1] = new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal - 1);
                            pawnMoves[2] = new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal - 1);
                        }
                    }
                    else
                    {
                        pawnMoves = new Coordinate[0];
                    }
                }
            }
            return pawnMoves;
        }
    }
}
