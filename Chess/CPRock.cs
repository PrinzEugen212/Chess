using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Chess
{
    public class Rock : ChessPiece
    {
        public override char Type { get; } = 'R';
        public Rock(string coordinate, bool color) : base(coordinate, color)
        {

        }
        public Rock(Coordinate coordinate, string color) : base(coordinate, color)
        {

        }
        public Rock() { }
        public override bool CheckMove(ChessPiece rock, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> Coordinates = Moves(rock);

            for (int i = 0; i < Coordinates.Count(); i++)
            {
                if (Coordinates[i].ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public override DynamicArray<Coordinate> Moves(ChessPiece rock)
        {
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            int startVertical = rock.Coordinate.Vertical, startHorizontal = rock.Coordinate.Horizontal;
            int vertical = startVertical, horizontal = startHorizontal;
            while (vertical < 8)
            {
                vertical++;
                moves.Add(new Coordinate(vertical, horizontal));
            }
            vertical = startVertical;
            while (horizontal > 1)
            {
                horizontal--;
                moves.Add(new Coordinate(vertical, horizontal));
            }
            horizontal = startHorizontal;
            while (horizontal < 8)
            {
                horizontal++;
                moves.Add(new Coordinate(vertical, horizontal));
            }
            while (vertical > 1)
            {
                vertical--;
                moves.Add(new Coordinate(vertical, horizontal));
            }
            return moves;
        }
        public override DynamicArray<Coordinate> Path(ChessPiece rock, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            int vertical, horizontal;
            if (rock.Coordinate.Vertical > endCoordinate.Vertical)
            {
                vertical = rock.Coordinate.Vertical;
                while (vertical > endCoordinate.Vertical)
                {
                    vertical--;
                    moves.Add(new Coordinate(vertical, rock.Coordinate.Horizontal));
                }
            }
            else if (rock.Coordinate.Vertical < endCoordinate.Vertical)
            {
                vertical = rock.Coordinate.Vertical;
                while (vertical < endCoordinate.Vertical)
                {
                    vertical++;
                    moves.Add(new Coordinate(vertical, rock.Coordinate.Horizontal));
                }
            }
            else if (rock.Coordinate.Horizontal > endCoordinate.Horizontal)
            {
                horizontal = rock.Coordinate.Horizontal;
                while (horizontal > endCoordinate.Horizontal)
                {
                    horizontal--;
                    moves.Add(new Coordinate(rock.Coordinate.Vertical, horizontal));
                }
            }
            else if (rock.Coordinate.Horizontal < endCoordinate.Horizontal)
            {
                horizontal = rock.Coordinate.Horizontal;
                while (horizontal < endCoordinate.Horizontal)
                {
                    horizontal++;
                    moves.Add(new Coordinate(rock.Coordinate.Vertical, horizontal));
                }

            }
            return moves;
        }
    }
}

