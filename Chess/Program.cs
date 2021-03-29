using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard a = new ChessBoard();
            Render.ShowBoard(a);
            int t = 0;
            string[] turn = new string[2] { "Ход белых:", "Ход чёрных:" };
            while (true)
            {
                try
                {
                    Console.WriteLine(turn[t % 2]);
                    string[] Parameters = Console.ReadLine().Split('-', ' ');
                    a.Move(new Coordinate(Parameters[0]), new Coordinate(Parameters[1]));
                    t++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }
    }
}
