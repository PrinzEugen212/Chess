namespace Chess
{
    class ChessPiece
    {
        public string Color { get; private set; }
        public string Type { get; private set; }
        public string Coordinate { get; private set; }
        public ChessPiece(string Coord, string T, bool C)
        {
            Type = T;
            Coordinate = Coord;
            if (C)
            {
                Color = "White";
            }
            else
            {
                Color = "Black";
            }
        }
        public void SetCoordinate(string C)
        {
            Coordinate = C;
        }
    }
}
