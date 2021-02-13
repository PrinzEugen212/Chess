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
        /// <summary>
        /// Создаёт экземпляр класса с переданной координатой
        /// </summary>
        /// <param name="Coordinate">Координата, формат должен быть аналогичен E4</param>
        public Coordinate(string Coordinate)
        {
            StringCoordinate = Coordinate;
            Horizontal = HorizontalFactory(Coordinate[1]);
            Vertical = VerticalFactory(Coordinate[0]);
        }

        /// <summary>
        /// Создаёт экземпляр класса по номеру вертикали и горизонтали
        /// </summary>
        /// <param name="vertical">Номер вертикали, от 1 до 8</param>
        /// <param name="horizontal">Номер горизонтали, от 1 до 8</param>
        public Coordinate(int vertical, int horizontal)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            StringCoordinate = VerticalFactory(vertical).ToString() + horizontal.ToString();
        }
        private int VerticalFactory(char vertical) // from char to int
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
        private char VerticalFactory(int vertical) // from int to cahr
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
        private int HorizontalFactory(char horizontal) // from char to int
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
        /// <summary>
        /// Возвращает координату в виде строки, например E4
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return StringCoordinate;
        }
        //public void SetCoordinate(int vertical, int horizontal)
        //{
        //    Vertical = vertical;
        //    Horizontal = horizontal;
        //}
        //public void SetCoordinate(int number, bool verticalOrNot)
        //{
        //    if (verticalOrNot)
        //    {
        //        Vertical = number;
        //    }
        //    else
        //    {
        //        Horizontal = number;
        //    }
        //}
    }
}
