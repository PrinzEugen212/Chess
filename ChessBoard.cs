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
            Console.WriteLine();
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
            SetColorsForCells();
        }
        void SetColorsForCells()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Position[i + j].SetColor(1);
                    }
                    else
                    {
                        Position[i + j].SetColor(2);
                    }
                }
            }
        }
        public bool Move(Coordinate coordinateS, Coordinate coordinateE)
        {
            string[] Parameters = new string[2];
            Parameters[0] = coordinateS.ToString();
            Parameters[1] = coordinateE.ToString();
            int StartIndex = 0, EndIndex = 0;
            for (int i = 0; i < Position.Length; i++)
            {
                if(Position[i].Coordinate.ToString() == Parameters[0])
                {
                    StartIndex = i;
                }
                if (Position[i].Coordinate.ToString() == Parameters[1])
                {
                    EndIndex = i;
                }
            }

            if (Position[StartIndex].ContentPiece.CheckMove(Position[StartIndex].ContentPiece, coordinateE))
            {
                Position[StartIndex].ContentPiece.SetCoordinate(Position[EndIndex].Coordinate.ToString());
                Position[EndIndex].ChangeContent(Position[StartIndex].ContentPiece);
                Position[StartIndex].ChangeContent(" ");
                Show();
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
