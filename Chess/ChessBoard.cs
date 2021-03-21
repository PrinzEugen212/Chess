using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace Chess
{
    class ChessBoard
    {
        Cell[] Position = new Cell[64];
        string[] Verticals = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
        int turnCount = 1;
        /// <summary>
        /// Создаётся новый экземпляр доски с установленной стандартной начальной позицией
        /// </summary>
        public ChessBoard()
        {
            SetStandartPosition();
        }
        /// <summary>
        /// Проверяет, может ли данная фигура совершить ход согласно правилам очерёдности хода
        /// </summary>
        /// <param name="chessPiece"></param>
        /// <returns></returns>
        private void CheckTurn(ChessPiece chessPiece)
        {
            if (turnCount % 2 == 1)
            {
                if (chessPiece.Color == "Black")
                {
                    throw new Exception("Сейчас ход белых");
                }
            }
            else
            {
                if (chessPiece.Color == "White")
                {
                    throw new Exception("Сейчас ход чёрных");
                }
            }
        }
        /// <summary>
        /// Возвращает цвет, который сейчас может совершить ход
        /// </summary>
        /// <returns></returns>
        private string CheckTurn()
        {
            if (turnCount % 2 == 1)
            {
                return "White";
            }
            else
            {
                return "Black";
            }
        }
        /// <summary>
        /// Проверка на шах
        /// </summary>
        private void CheckCheck()
        {
            ChessPiece WhiteKing = null, BlackKing = null;
            string movingSide = CheckTurn();
            for (int i = 0; i < Position.Length; i++)
            {
                if (Position[i].ContentPiece != null && Position[i].ContentPiece.Type == 'K')
                {
                    if (Position[i].ContentPiece.Color == "Black")
                    {
                        BlackKing = Position[i].ContentPiece;
                    }
                    if (Position[i].ContentPiece.Color == "White")
                    {
                        WhiteKing = Position[i].ContentPiece;
                    }
                }
            }

            if (WhiteKing == null || BlackKing == null)
                throw new Exception("На доске нет короля");


            for (int i = 0; i < Position.Length; i++)
            {
                ChessPiece currentKing = (movingSide == "White") ? WhiteKing : BlackKing;

                if (Position[i].ContentPiece != null && Position[i].ContentPiece.Color != movingSide)
                {
                    if (Position[i].ContentPiece.CheckMove(currentKing.Coordinate))
                    {
                        DynamicArray<Coordinate> path = Position[i].ContentPiece.Path(currentKing.Coordinate);
                        try { CheckWithOtherPieces(path, Position[i].ContentPiece); }
                        catch (Exception)
                        {
                            continue;
                        }
                        throw new Exception();
                    }
                }
            }
        }
        /// <summary>
        /// Устанавливает начальную позицию фигур на доске
        /// </summary>

        private void CheckWithOtherPieces(DynamicArray<Coordinate> figurePath, ChessPiece movingPiece)
        {
            for (int i = 0; i < figurePath.Count(); i++)
            {
                Cell cell = FindCell(figurePath[i]);

                if (i == figurePath.Count() - 1)
                {
                    if (cell.ContentPiece != null && cell.ContentPiece.Color == movingPiece.Color)
                    {
                        throw new Exception("Фигуры одного и того же цвета");
                    }
                }
                if (i < figurePath.Count() - 1)
                {
                    if (cell.Contains())
                    {
                        throw new Exception("На пути фигуры находится другая фигура");
                    }
                }
            }
        }
        private void SetStandartPosition()
        {
            string P = "R N B Q K B N R " + "P P P P P P P P " + "P P P P P P P P " + "R N B Q K B N R ";
            string[] Contents = P.Split(' ');
            int VInd, HNum; // Vertical index and horizontal number, needed to calculate vertical and horizonal for cell or piece
            for (int i = 0; i < Position.Length; i++)
            {
                VInd = i % 8;
                HNum = Math.Abs(i / 8 - 8);
                string Coordinate = Verticals[VInd].ToString() + HNum.ToString();
                Position[i] = new Cell(Coordinate);
                if (HNum == 1 || HNum == 2) // 1 & 2 horizontals - white
                {
                    Position[i].ChangeContent(ChessFactory.Create(Coordinate, Convert.ToChar(Contents[i - 32]), true));
                }
                if (HNum == 7 || HNum == 8) // 7 & 8 horizontals - black
                {
                    Position[i].ChangeContent(ChessFactory.Create(Coordinate, Convert.ToChar(Contents[i]), false));
                }
                if (HNum > 2 && HNum < 7)
                {
                    Position[i].ChangeContent(" ");
                }
            }
        }

        private Cell FindCell(Coordinate coordinate)
        {
            foreach (var cell in Position)
            {
                if (cell.Coordinate.Vertical == coordinate.Vertical && cell.Coordinate.Horizontal == coordinate.Horizontal)
                {
                    return cell;
                }
            }
            return Position[0];
        }

        /// <summary>
        /// Перемещает фигуру из начальной координаты в конечную, если это возможно
        /// </summary>
        /// <param name="startCoordinate"></param>
        /// <param name="endCoordinate"></param>
        public void Move(Coordinate startCoordinate, Coordinate endCoordinate)
        {
            string[] Parameters = new string[2];
            Parameters[0] = startCoordinate.ToString();
            Parameters[1] = endCoordinate.ToString();
            DynamicArray<Coordinate> figurePath;
            ChessPiece movingPiece = null;
            int StartIndex = 0, EndIndex = 0;
            for (int i = 0; i < Position.Length; i++)
            {
                if (Position[i].Coordinate.ToString() == Parameters[0])
                {
                    if (Position[i].ContentPiece == null)
                    {
                        throw new Exception("В ячейке с выбранной начальной координатой нет фигуры");
                    }
                    StartIndex = i;
                    CheckTurn(Position[StartIndex].ContentPiece);
                    movingPiece = Position[StartIndex].ContentPiece;
                }
                if (Position[i].Coordinate.ToString() == Parameters[1])
                {
                    EndIndex = i;
                }
            }

            if (movingPiece.CheckMove(endCoordinate))
            {
                figurePath = movingPiece.Path(endCoordinate);
                CheckWithOtherPieces(figurePath, movingPiece);
                ChessPiece temp1 = Position[StartIndex].ContentPiece, temp2 = Position[EndIndex].ContentPiece;
                try
                {
                    Position[EndIndex].ChangeContent(Position[StartIndex].ContentPiece);
                    Position[StartIndex].ChangeContent(" ");
                    CheckCheck();
                }
                catch(Exception)
                {
                    
                    Position[EndIndex].ChangeContent(temp2);
                    Position[StartIndex].ChangeContent(temp1);
                    throw new Exception("Шах");
                }
                movingPiece.SetCoordinate(endCoordinate.ToString());
                Log.Add(endCoordinate.ToString(), Position[EndIndex].ContentPiece.Color, Position[EndIndex].ContentPiece.Type);
                turnCount++;
                Render.ShowBoard(this);
            }
            else
            {
                throw new Exception("Невозможный ход");
            }

        }

        /// <summary>
        /// Возвращает текущую позицию на доске
        /// </summary>
        /// <returns></returns>
        public Cell[] GetPosition()
        {
            return Position;
        }
    }
}
