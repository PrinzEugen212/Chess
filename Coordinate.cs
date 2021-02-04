using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Coordinate
    {
        public int Horizontal { get; private set; }
        public int Vertical { get; private set; }
        private string StringCoordinate;
        public Coordinate(string Coordinate)
        {
            StringCoordinate = Coordinate;
            Horizontal = HorizontalFactory(Coordinate[1]);
            Vertical = VerticalFactory(Coordinate[0]);
        }
        public Coordinate(int vertical, int horizontal)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            StringCoordinate = VerticalFactory(vertical).ToString() + horizontal.ToString();
        }
        public int VerticalFactory(char vertical) // from char to int
        {
            switch (vertical)
            {
                case 'A': return 1;
                case 'B': return 2;
                case 'C': return 3;
                case 'D': return 4;
                case 'E': return 5;
                case 'F': return 6;
                case 'G': return 7;
                case 'H': return 8;
                default:
                    return 0;
            }
        }
        public char VerticalFactory(int vertical) // from int to cahr
        {
            switch (vertical)
            {
                case 1: return 'A';
                case 2: return 'B';
                case 3: return 'C';
                case 4: return 'D';
                case 5: return 'E';
                case 6: return 'F';
                case 7: return 'G';
                case 8: return 'H';
                default:
                    return 'U';
            }
        }
        public int HorizontalFactory(char horizontal) // from char to int
        {
            switch (horizontal)
            {
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                default:
                    return 0;
            }
        }
        public override string ToString()
        {
            return StringCoordinate;
        }
    }
}
