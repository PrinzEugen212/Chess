using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    static class ChessFactory
    {
        /// <summary>
        /// Возвращает новый экземпляр фигуры в соответствии с переданным типом и переданными параметрами
        /// </summary>
        /// <param name="coordinate">Координата фигуры</param>
        /// <param name="type">Тип фигуры (B, Q и т.д.)</param>
        /// <param name="color">Цвет фигуры</param>
        /// <returns></returns>
        public static ChessPiece Create(string coordinate, char type, bool color)
        {
            switch (type)
            {
                case 'P': return new Pawn(coordinate, color);
                case 'B': return new Bishop(coordinate, color);
                case 'N': return new Knight(coordinate, color);
                case 'R': return new Rock(coordinate, color);
                case 'Q': return new Queen(coordinate, color);
                case 'K': return new King(coordinate, color);
                default: return new Pawn(coordinate, color);
            }
        }
    }
}
