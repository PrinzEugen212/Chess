using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    static class Log
    {
        static private StringBuilder GameLog = new StringBuilder();
        static public int Turn { get; private set; }
        /// <summary>
        /// Добавляет в лог партии запись сделанного хода
        /// </summary>
        /// <param name="move">Ход, формат должен быть аналогичный E2-E4</param>
        /// <param name="colorThatMadeMove">Цвет стороны, сделавшей ход. Black или White</param>
        /// <param name="figureType">Тип фигуры, сделавшей ход. P - пешка, N - конь, B - слон, R - ладья, Q - ферзь, K - король </param>
        static public void Add(string move, string colorThatMadeMove, char figureType)
        {
            if (colorThatMadeMove == "White")
            {
                if(figureType != 'P')
                {
                    Turn++;
                    GameLog.Append (Turn.ToString() + ". " + figureType + move);
                }
                else
                {
                    Turn++;
                    GameLog.Append (Turn.ToString() + ". " + move);
                }
            }
            else
            {
                if (figureType != 'P')
                {
                    GameLog.Append(" " + figureType + move + " ");
                }
                else
                {
                    GameLog.Append(" " + move + " ");
                }
            }
        }
        /// <summary>
        /// Возвращает лог (запись партии) в виде строки
        /// </summary>
        /// <returns></returns>
        static public string GetLog()
        {
            if (GameLog == null)
            {
                return " ";
            }
            else
            {
                return GameLog.ToString();
            }
            
        }
    }
}
