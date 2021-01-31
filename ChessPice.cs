namespace Chess
{
    class ChessPiece
    {
        public string Color { get; private set; }
        public string Type { get; private set; }
        public ChessPiece(string T, bool C)
        {
            Type = T;
            if (C)
            {
                Color = "White";
            }
            else
            {
                Color = "Black";
            }
        }
    }
}
