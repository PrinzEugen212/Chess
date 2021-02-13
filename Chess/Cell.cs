﻿using System;

namespace Chess
{
    class Cell
    {
        public Coordinate Coordinate { get; private set; }
        public ChessPiece ContentPiece { get; private set; }
        public string Content { get; private set; }

        /// <summary>
        /// Создаёт экземпляр класса с заданной координатой
        /// </summary>
        /// <param name="coordinate">Координата, формат должен быть аналогичен Е4</param>
        public Cell(string coordinate)
        {
            Coordinate = new Coordinate(coordinate);
            Content = " ";
        }
        //public Cell(string coordinate, ChessPiece ChessPiece)
        //{
        //    Coordinate = new Coordinate(coordinate);
        //    ContentPiece = ChessPiece;
        //}

        /// <summary>
        /// Изменяет значение ячейки на ""
        /// </summary>
        /// <param name="content">Строка, должна состоять только из пробела</param>
        public void ChangeContent(string content)
        {
            Content = content;
            ContentPiece = null;
        }

        /// <summary>
        /// Устанавливает переданную фигуру в содержимое данной ячейки
        /// </summary>
        /// <param name="ChessPiece">Фигура, которую нужно записать в данную ячейку</param>
        public void ChangeContent(ChessPiece ChessPiece)
        {
            ContentPiece = ChessPiece;
            Content = "";
        }
    }
}
