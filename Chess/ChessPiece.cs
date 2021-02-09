namespace Chess
{
    class ChessPiece
    {
        public string Color { get; private set; }
        public char Type { get; private set; }
        public Coordinate Coordinate { get; private set; }
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
        public ChessPiece() { }
        public void SetCoordinate(string coordinate)
        {
            Coordinate = new Coordinate(coordinate);
        }
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
        public Coordinate[] Path(ChessPiece chessPiece, Coordinate endCoordinate)
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
                    return new Coordinate[0];
            }
        }
    }
}
