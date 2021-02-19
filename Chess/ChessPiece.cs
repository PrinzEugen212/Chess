using MyLibrary;

namespace Chess
{
    class ChessPiece
    {
        public string Color { get; private set; }
        public char Type { get; private set; }
        public Coordinate Coordinate { get; private set; }

        /// <summary>
        /// Создаёт фигуру с заданной координатой, типом и цветом
        /// </summary>
        /// <param name="coordinate">Положение фигуры на доске, формат должен быть аналогичен E4</param>
        /// <param name="type">Тип фигуры, P - пешка, N - конь, B - слон, R - ладья, Q - ферзь, K - король</param>
        /// <param name="color">Цвет фигуры. true - белый, false - чёрный</param>
        public ChessPiece(string coordinate, char type, bool color)
        {
            Type = type;
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

        /// <summary>
        /// Проверяет, может ли переданная фигура переместиться в переданную координату. Положение остальных фигур не учитывается
        /// </summary>
        /// <param name="chessPiece">Передвигаемая фигура</param>
        /// <param name="endCoordinate">Координата, в которую фигура должна попасть</param>
        /// <returns></returns>
        public bool CheckMove(ChessPiece chessPiece, Coordinate endCoordinate)
        {
            switch (chessPiece.Type)
            {
                case 'P': return CheckPawnMoves.CheckMove(chessPiece,endCoordinate);
                case 'R': return CheckRockMoves.CheckMove(chessPiece, endCoordinate);
                case 'N': return CheckKnightMoves.CheckMove(chessPiece, endCoordinate);
                case 'B': return CheckBishopMoves.CheckMove(chessPiece, endCoordinate);
                case 'Q': return CheckQueenMoves.CheckMove(chessPiece, endCoordinate);
                case 'K': return CheckKingMoves.CheckMove(chessPiece, endCoordinate);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Возврашает путь переданной фигуры от текущего положения до переданной координаты
        /// </summary>
        /// <param name="chessPiece">Фигура, путь которой нужно узнать</param>
        /// <param name="endCoordinate">Координата, до которой нужно узнать путь</param>
        /// <returns></returns>
        public DynamicArray<Coordinate> Path(ChessPiece chessPiece, Coordinate endCoordinate)
        {
            switch (chessPiece.Type)
            {
                case 'R': return CheckRockMoves.Path(chessPiece, endCoordinate);
                case 'N': return CheckKnightMoves.Path(chessPiece, endCoordinate);
                case 'P': return CheckPawnMoves.Path(chessPiece, endCoordinate);
                case 'K': return CheckKingMoves.Path(chessPiece, endCoordinate);
                case 'B': return CheckBishopMoves.Path(chessPiece, endCoordinate);
                case 'Q': return CheckQueenMoves.Path(chessPiece, endCoordinate);
                default:
                    return new DynamicArray<Coordinate>();
            }
        }
    }
}
