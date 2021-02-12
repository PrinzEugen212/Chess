using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    static class Render
    {

        public static void ShowBoard(Cell[] position)
        {
            Console.Clear();
            int c1 = 8;
            int c2 = 0;
            for (int i = 0; i < 8; i++)
            {
                Console.Write(c1 + " ");
                c1--;
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(" ");
                    ShowCell(position[c2]);
                    //position[c2].Write();
                    c2++;
                    Console.Write(" ");
                    if (j == 7)
                    {
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("   A  B  C  D  E  F  G  H");
            ShowLog();
        }

        public static void ShowLog()
        {
            Console.SetCursorPosition(30, 0);
            Console.Write(Log.GetLog());
            Console.SetCursorPosition(0, 10);
        }

        public static void ShowCell(Cell cell)
        {
            if (cell.ContentPiece == null)
            {
                Console.Write(cell.Content);
            }
            else
            {
                Console.Write(cell.ContentPiece.Type);
            }
        }
    }
}
