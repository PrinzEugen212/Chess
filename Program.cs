using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard a = new ChessBoard();
            a.SetStandartPosition();
            a.Show();
            int t = 0;
            while (t < 5950 / 2)
            {
                Console.WriteLine("Ход белых:");
                a.Move(Console.ReadLine());
                Console.WriteLine("Ход чёрных:");
                a.Move(Console.ReadLine());
            }
        }
    }
}
