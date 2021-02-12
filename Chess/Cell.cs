﻿using System;

namespace Chess
{
    class Cell
    {
        public Coordinate Coordinate { get; private set; }
        public ChessPiece ContentPiece { get; private set; }
        public string Content { get; private set; }
        public Cell (string coordinate)
        {
            Coordinate = new Coordinate(coordinate);
            Content = " ";
        }
        public Cell(string coordinate, ChessPiece ChessPiece)
        {
            Coordinate = new Coordinate(coordinate);
            ContentPiece = ChessPiece;
        }
        public void ChangeContent(string content)
        {
            Content = content;
            ContentPiece = null;
        }
        public void ChangeContent(ChessPiece ChessPiece)
        {
            ContentPiece = ChessPiece;
            Content = "";
        }
    }
}