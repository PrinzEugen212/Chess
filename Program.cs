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
                string[] Parameters = Console.ReadLine().Split('-', ' ');
                a.Move(new Coordinate(Parameters[0]), new Coordinate(Parameters[1]));
                Console.WriteLine("Ход чёрных:");
                Parameters = Console.ReadLine().Split('-', ' ');
                a.Move(new Coordinate(Parameters[0]), new Coordinate(Parameters[1]));
                t++;
            }
            //string[] Parameters = Console.ReadLine().Split('-', ' ');
            //Coordinate A = new Coordinate(Parameters[0]);
            //Console.WriteLine(A.Horizontal);
        }
    }
}
