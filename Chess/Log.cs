using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    static class Log
    {
        static private StringBuilder GameLog = new StringBuilder();
        static public int Turn { get; private set; }
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
