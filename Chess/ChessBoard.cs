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

        public string CheckTurn(ChessPiece chessPiece)
        {
            if (chessPiece == null)
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
            return " ";
        }
        private bool CheckCheck()
        {
            ChessPiece WhiteKing = null, BlackKing = null;
            string movingSide = CheckTurn(null);
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
                if (Position[i].ContentPiece != null && Position[i].ContentPiece.Color != movingSide)
                {
                    if (Position[i].ContentPiece.CheckMove((movingSide == "White")? WhiteKing.Coordinate : BlackKing.Coordinate))
                    {
                        throw new Exception("Шах");
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Устанавливает начальную позицию фигур на доске
        /// </summary>
        private void SetStandartPosition()
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
            Cell cell;
            ChessPiece movingPiece = null;
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
            CheckCheck();
            int StartIndex = 0, EndIndex = 0;
            for (int i = 0; i < Position.Length; i++)
            {
                if(Position[i].Coordinate.ToString() == Parameters[0])
                {
                    StartIndex = i;
                    CheckTurn(Position[StartIndex].ContentPiece);
                    movingPiece = Position[StartIndex].ContentPiece;
                }
                if (Position[i].Coordinate.ToString() == Parameters[1])
                {
                    EndIndex = i;
                }
            }

            if (movingPiece == null)
                throw new Exception("Введена неверная координата");

            if (movingPiece.CheckMove(endCoordinate))
            {
                figurePath = movingPiece.Path(endCoordinate);
                for (int i = 0; i < figurePath.Count(); i++)
                {
                    cell = FindCell(figurePath[i]);

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
                movingPiece.SetCoordinate(endCoordinate.ToString());
                Position[EndIndex].ChangeContent(Position[StartIndex].ContentPiece);
                Position[StartIndex].ChangeContent(" ");
                CheckCheck();
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
