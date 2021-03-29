using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace Chess
{

    public class Bishop : ChessPiece
    {
        public override char Type {get;} = 'B';
        public Bishop(string coordinate, bool color) : base(coordinate, color)
        {

        }

        public Bishop(Coordinate coordinate, string color) : base(coordinate, color)
        {

        }


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
            
            Bishop bishop = this;
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            int startVertical = bishop.Coordinate.Vertical, startHorizontal = bishop.Coordinate.Horizontal;
            int vertical = startVertical, horizontal = startHorizontal;
            while (vertical < 8 && horizontal < 8)
            {
                vertical++; horizontal++;
                moves.Add(new Coordinate(vertical, horizontal));
            }
            vertical = startVertical; horizontal = startHorizontal;
            while (vertical < 8 && horizontal > 1)
            {
                vertical++; horizontal--;
                moves.Add(new Coordinate(vertical, horizontal));
            }
            vertical = startVertical; horizontal = startHorizontal;
            while (horizontal < 8 && vertical > 1)
            {
                vertical--; horizontal++;
                moves.Add(new Coordinate(vertical, horizontal));
            }
            vertical = startVertical; horizontal = startHorizontal;
            while (vertical > 1 && horizontal > 1)
            {
                vertical--; horizontal--;
                moves.Add(new Coordinate(vertical, horizontal));
            }
            return moves;
        }

        public override DynamicArray<Coordinate> Path(Coordinate endCoordinate)
        {
            Bishop bishop = this;
            DynamicArray<Coordinate> moves = new DynamicArray<Coordinate>();
            int vertical = bishop.Coordinate.Vertical, horizontal = bishop.Coordinate.Horizontal;
            int endVertical = endCoordinate.Vertical, endHorizontal = endCoordinate.Horizontal;
            if (endVertical - vertical > 0 && endHorizontal - horizontal > 0)
            {
                while (vertical < endVertical && horizontal < endHorizontal)
                {
                    vertical++; horizontal++;
                    moves.Add(new Coordinate(vertical, horizontal));
                }
            }
            else if (endVertical - vertical < 0 && endHorizontal - horizontal < 0)
            {
                while (vertical > endVertical && horizontal > endHorizontal)
                {
                    vertical--; horizontal--;
                    moves.Add(new Coordinate(vertical, horizontal));
                }
            }
            else if (endVertical - vertical < 0 && endHorizontal - horizontal > 0)
            {
                while (vertical > endVertical && horizontal < endHorizontal)
                {
                    vertical--; horizontal++;
                    moves.Add(new Coordinate(vertical, horizontal));
                }
            }
            else if (endVertical - vertical > 0 && endHorizontal - horizontal < 0)
            {
                while (vertical < endVertical && horizontal > endHorizontal)
                {
                    vertical++; horizontal--;
                    moves.Add(new Coordinate(vertical, horizontal));
                }
            }
            return moves;
        }
    }
}
