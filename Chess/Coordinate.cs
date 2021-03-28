using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Coordinate
    {
        public int Horizontal { get; private set; }
        public int Vertical { get; private set; }
        private string StringCoordinate;
        private readonly Dictionary<int, string> fromInt = new Dictionary<int, string>
        {
            [1] = "A",
            [2] = "B",
            [3] = "C",
            [4] = "D",
            [5] = "E",
            [6] = "F",
            [7] = "G",
            [8] = "H"
        };
        public readonly Dictionary<string, int> fromChar = new Dictionary<string, int>
        {
            ["A"] = 1,
            ["B"] = 2,
            ["C"] = 3,
            ["D"] = 4,
            ["E"] = 5,
            ["F"] = 6,
            ["G"] = 7,
            ["H"] = 8
        };
        /// <summary>
        /// Создаёт экземпляр класса с переданной координатой
        /// </summary>
        /// <param name="Coordinate">Координата, формат должен быть аналогичен E4</param>
        public Coordinate(string Coordinate)
        {
            StringCoordinate = Coordinate;
            Horizontal = (int)Char.GetNumericValue(Coordinate[1]);
            Vertical = fromChar[Coordinate[0].ToString()];
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
            StringCoordinate = fromInt[vertical].ToString() + horizontal.ToString();
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
