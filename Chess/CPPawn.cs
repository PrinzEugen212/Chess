using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Chess
{
    public class Pawn : ChessPiece
    {
        public override char Type { get; } = 'P';
        public Pawn(string coordinate, bool color) : base(coordinate, color)
        {

        }
        public Pawn(Coordinate coordinate, string color) : base(coordinate, color)
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
            Pawn pawn = this;
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            if (pawn.Color == "White")
            {
                if (pawn.Coordinate.Horizontal == 2) // start horizontal for white
                {
                    if (pawn.Coordinate.Vertical == 1)// side vertical check
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1));
                        }
                        moves.Add(new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal + 1));
                    }
                    else if (pawn.Coordinate.Vertical == 8)// side vertical check
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1));
                        }
                        moves.Add(new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal + 1));
                    }
                    else
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1));
                        }
                        moves.Add(new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal + 1));
                        moves.Add(new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal + 1));
                    }
                }
                else
                {
                    if (pawn.Coordinate.Horizontal + 1 < 9)
                    {
                        if (pawn.Coordinate.Vertical == 1)// side vertical check
                        {
                            for (int i = 0; i < 3 / 2; i++)
                            {
                                moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1));
                            }
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal + 1));
                        }
                        else if (pawn.Coordinate.Vertical == 8)// side vertical check
                        {
                            for (int i = 0; i < 3 / 2; i++)
                            {
                                moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1));
                            }
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal + 1));
                        }
                        else
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + 1));
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal + 1));
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal + 1));
                        }
                    }
                }
            }
            else // color - black
            {
                if (pawn.Coordinate.Horizontal == 7) // start horizontal for black
                {
                    if (pawn.Coordinate.Vertical == 1)// side vertical check
                    {
                        for (int i = 0; i < 4 / 2; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1));
                        }
                        moves.Add(new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal - 1));
                    }
                    else if (pawn.Coordinate.Vertical == 8)// side vertical check
                    {
                        for (int i = 0; i < 4 / 2; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1));
                        }
                        moves.Add(new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal - 1));
                    }
                    else
                    {
                        for (int i = 0; i < 4 / 2; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1));
                        }
                        moves.Add(new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal - 1));
                        moves.Add(new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal - 1));
                    }
                }
                else
                {
                    if (pawn.Coordinate.Horizontal - 1 > 0)
                    {
                        if (pawn.Coordinate.Vertical == 1) // side vertical check
                        {
                            for (int i = 0; i < 3 / 2; i++)
                            {
                                moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1));
                            }
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal - 1));
                        }
                        else if (pawn.Coordinate.Vertical == 8)// side vertical check
                        {
                            for (int i = 0; i < 3 / 2; i++)
                            {
                                moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1));
                            }
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal - 1));
                        }
                        else
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - 1));
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical - 1, pawn.Coordinate.Horizontal - 1));
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical + 1, pawn.Coordinate.Horizontal - 1));
                        }
                    }
                }
            }
            return moves;
        }
        public override DynamicArray<Coordinate> Path(Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            Pawn pawn = this;
            if (CheckMove(endCoordinate))
            {
                if (pawn.Color == "White")
                {
                    if (Math.Abs(pawn.Coordinate.Vertical - endCoordinate.Vertical) == 1)
                    {
                        moves.Add(endCoordinate);
                        return moves;
                    }
                    else if (pawn.Coordinate.Horizontal == 2)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1));
                        }
                        return moves;
                    }
                    else
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal + i + 1));
                        }
                        return moves;
                    }
                }
                else
                {
                    if (Math.Abs(pawn.Coordinate.Vertical - endCoordinate.Vertical) == 1)
                    {
                        moves.Add(endCoordinate);
                        return moves;
                    }
                    else if (pawn.Coordinate.Horizontal == 7)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1));
                        }
                        return moves;
                    }
                    else
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            moves.Add(new Coordinate(pawn.Coordinate.Vertical, pawn.Coordinate.Horizontal - i - 1));
                        }
                        return moves;
                    }
                }
            }
            else
            {
                return moves;
            }
        }
    }
}
