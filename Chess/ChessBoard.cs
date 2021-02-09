using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessBoard
    {
        public void Show()
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
                    if ((i+j) % 2 == 0)
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
                    Position[c2].Write();
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
            Log.ShowInConsole();
        }
        Cell[] Position = new Cell[64];
        string[] Verticals = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
        public void SetStandartPosition()
        {
            string P = "R N B Q K B N R " + "P P P P P P P P " + "P P P P P P P P " + "R N B Q K B N R ";
            string[] Contents = P.Split(' ');
            int VInd, HNum; // Vertical index and horizontal number, needed to calculate vertical and horizonal for cell or piece
            for(int i = 0; i < Position.Length; i++)
            {
                VInd = i % 8;
                HNum = Math.Abs(i / 8 - 8);
                string Coordinate = Verticals[VInd].ToString() + HNum.ToString();
                Position[i] = new Cell(Coordinate);
                if (HNum == 1 || HNum == 2) // 1 & 2 horizontals - white
                {
                    Position[i].ChangeContent(new ChessPiece(Coordinate, Convert.ToChar(Contents[i-32]),true));

                }
                if (HNum == 7 || HNum == 8) // 7 & 8 horizontals - black
                {
                    Position[i].ChangeContent(new ChessPiece(Coordinate, Convert.ToChar(Contents[i]), false));
                }
                if (HNum > 2 && HNum < 7)
                {
                    Position[i].ChangeContent(" ");
                }
            }
        }
        public void Move(Coordinate startCoordinate, Coordinate endCoordinate)
        {

            string[] Parameters = new string[2];
            Parameters[0] = startCoordinate.ToString();
            Parameters[1] = endCoordinate.ToString();
            Coordinate[] figurePath;
            for (int i = 0; i < Position.Length; i++)
            {
                if (Position[i].Coordinate.ToString() == Parameters[0])
                {
                    if(Position[i].ContentPiece == null)
                    {
                        throw new Exception("В ячейке с выбранной начальной координатой нет фигуры");
                    }
                }
            }
            int StartIndex = 0, EndIndex = 0;
            ChessPiece figure = new ChessPiece();
            for (int i = 0; i < Position.Length; i++)
            {
                if(Position[i].Coordinate.ToString() == Parameters[0])
                {
                    StartIndex = i;
                    figure = Position[StartIndex].ContentPiece;
                }
                if (Position[i].Coordinate.ToString() == Parameters[1])
                {
                    EndIndex = i;
                }
            }
            if (figure.CheckMove(figure, endCoordinate))
            {
                figurePath = figure.Path(figure, endCoordinate);
                figure.SetCoordinate(endCoordinate.ToString());
                Position[EndIndex].ChangeContent(figure);
                Position[StartIndex].ChangeContent(" ");
                Log.Add(endCoordinate.ToString(), figure.Color, figure.Type);
                Show();
            }
            else
            {
                throw new Exception("Невозможный ход");
            }
            
        }
    }
}
