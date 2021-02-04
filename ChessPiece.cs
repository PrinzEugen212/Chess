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
        public void SetCoordinate(string coordinate)
        {
            Coordinate = new Coordinate(coordinate);
        }
        public bool CheckMove(ChessPiece chessPiece, Coordinate endCoordinate)
        {
            switch (chessPiece.Type)
            {
                case 'P': return CheckPawnMoves.CheckMove(chessPiece,endCoordinate);
                default:
                    return false;
            }
        }
    }
}
