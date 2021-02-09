using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class CheckBishopMoves
    {
        public static bool CheckMove(ChessPiece bishop, Coordinate endCoordinate)
        {
            Coordinate[] Coordinates = Moves(bishop);
            foreach (var coordinateInArray in Coordinates)
            {
                if (coordinateInArray.ToString() == endCoordinate.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        public static Coordinate[] Moves(ChessPiece bishop)
        {
            Coordinate[] bishopMoves;
            Coordinate[] possibleBishopMoves = new Coordinate[13];
            int length = 0;
            int startVertical = bishop.Coordinate.Vertical, startHorizontal = bishop.Coordinate.Horizontal;
            int vertical = startVertical, horizontal = startHorizontal;
            while (vertical < 8 && horizontal < 8)
            {
                vertical++;horizontal++;
                possibleBishopMoves[length] = new Coordinate(vertical, horizontal);
                length++;
            }
            vertical = startVertical; horizontal = startHorizontal;
            while (vertical < 8 && horizontal > 1)
            {
                vertical++; horizontal--;
                possibleBishopMoves[length] = new Coordinate(vertical, horizontal);
                length++;
            }
            vertical = startVertical; horizontal = startHorizontal;
            while (horizontal < 8 && vertical > 1)
            {
                vertical--; horizontal++;
                possibleBishopMoves[length] = new Coordinate(vertical, horizontal);
                length++;
            }
            vertical = startVertical; horizontal = startHorizontal;
            while (vertical > 1 && horizontal > 1)
            {
                vertical--; horizontal--;
                possibleBishopMoves[length] = new Coordinate(vertical, horizontal);
                length++;
            }
            bishopMoves = new Coordinate[length];
            for (int i = 0; i < length; i++)
            {
                bishopMoves[i] = possibleBishopMoves[i];
            }
            return bishopMoves;
        }
        public static Coordinate[] Path(ChessPiece bishop, Coordinate endCoordinate)
        {
            Coordinate[] bishopPath, bishopLine = new Coordinate[7];
            int vertical = bishop.Coordinate.Vertical, horizontal = bishop.Coordinate.Horizontal;
            int endVertical = endCoordinate.Vertical, endHorizontal = endCoordinate.Horizontal;
            int counter = 0;
            if (endVertical - vertical > 0 && endHorizontal - horizontal > 0)
            {
                while (vertical < endVertical && horizontal < endHorizontal)
                {
                    vertical++; horizontal++;
                    bishopLine[counter] = new Coordinate(vertical, horizontal);
                    counter++;
                }
            }
            else if (endVertical - vertical < 0 && endHorizontal - horizontal < 0)
            {
                while (vertical > endVertical && horizontal > endHorizontal)
                {
                    vertical--; horizontal--;
                    bishopLine[counter] = new Coordinate(vertical, horizontal);
                    counter++;
                }
            }
            else if (endVertical - vertical < 0 && endHorizontal - horizontal > 0)
            {
                while (vertical > endVertical && horizontal < endHorizontal)
                {
                    vertical--; horizontal++;
                    bishopLine[counter] = new Coordinate(vertical, horizontal);
                    counter++;
                }
            }
            else if (endVertical - vertical > 0 && endHorizontal - horizontal < 0)
            {
                while (vertical < endVertical && horizontal > endHorizontal)
                {
                    vertical++; horizontal--;
                    bishopLine[counter] = new Coordinate(vertical, horizontal);
                    counter++;
                }
            }
            bishopPath = new Coordinate[counter];
            for (int i = 0; i < counter; i++)
            {
                bishopPath[i] = bishopLine[i];
            }
            return bishopPath;
        }
    }
}
