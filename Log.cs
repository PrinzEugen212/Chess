using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    static class Log
    {
        static private string GameLog;
        static public int Turn { get; private set; }
        static public void Add(string move, string colorThatMadeMove, char figureType)
        {
            if (colorThatMadeMove == "White")
            {
                if(figureType != 'P')
                {
                    Turn++;
                    GameLog += Turn.ToString() + ". " + figureType + move;
                }
                else
                {
                    Turn++;
                    GameLog += Turn.ToString() + ". " + move;
                }
            }
            else
            {
                if (figureType != 'P')
                {
                    GameLog += " " + figureType + move + " ";
                }
                else
                {
                    GameLog += " " + move + " ";
                }
            }
        }
        static public string GetLog()
        {
            return GameLog;
        }
        static public void ShowInConsole()
        {
            Console.SetCursorPosition(30, 0);
            Console.Write(GetLog());
            Console.SetCursorPosition(0, 10);
        }
    }
}
