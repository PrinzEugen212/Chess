using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    class Cell
    {
        public string Coordinate { get; private set; }
        public ChessPiece ContentPiece { get; private set; }
        public string Content { get; private set; }
        public string Color { get; private set; }
        public Cell (string C)
        {
            Coordinate = C;
            Content = " ";
        }
        public Cell(string Co, ChessPiece C)
        {
            Coordinate = Co;
            ContentPiece = C;
        }
        public void ChangeContent(string a)
        {
            Content = a;
            ContentPiece = null;
        }
        public void ChangeContent(ChessPiece a)
        {
            ContentPiece = a;
            Content = "";
        }
        public void Write()
        {
            if(ContentPiece == null)
            {
                Console.Write(Content);
            }
            else
            {
                Console.Write(ContentPiece.Type);
            }
        }
        public void SetColor(int c)
        {
            if (c == 1)
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
