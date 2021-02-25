using MyLibrary;

namespace Chess
{
    public abstract class ChessPiece
    {
        public string Color { get; protected set; }
        public Coordinate Coordinate { get; protected set; }
        public abstract char Type {get;}

        /// <summary>
        /// Создаёт фигуру с заданной координатой, типом и цветом
        /// </summary>
        /// <param name="coordinate">Положение фигуры на доске, формат должен быть аналогичен E4</param>
        /// <param name="type">Тип фигуры, P - пешка, N - конь, B - слон, R - ладья, Q - ферзь, K - король</param>
        /// <param name="color">Цвет фигуры. true - белый, false - чёрный</param>
        public ChessPiece(string coordinate, bool color)
        {
            Coordinate = new Coordinate(coordinate);
            if (color)
            {
                Color = "White";
            }
            else
            {
                Color = "Black";
            }
        }

        public ChessPiece(Coordinate coordinate, string color)
        {
            Coordinate = coordinate;
            Color = color;
        }

        /// <summary>
        /// Создаёт фигуру со значениями по умолчанию
        /// </summary>
        public ChessPiece() { }

        /// <summary>
        /// Устанавливает фигуре переданную координату
        /// </summary>
        /// <param name="coordinate">Координата, формат должен быть аналогичен Е4</param>
        public void SetCoordinate(string coordinate)
        {
            Coordinate = new Coordinate(coordinate);
        }
        public abstract bool CheckMove(Coordinate coordinate);
        public abstract DynamicArray<Coordinate> Path(Coordinate coordinate);

        public abstract DynamicArray<Coordinate> Moves();
    }
}
