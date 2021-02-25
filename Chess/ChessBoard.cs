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

        /// <summary>
        /// Создаётся новый экземпляр доски с установленной стандартной начальной позицией
        /// </summary>
        public ChessBoard()
        {
            SetStandartPosition();
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
            if (Position[StartIndex].ContentPiece.CheckMove(endCoordinate))
            {
                figurePath = Position[StartIndex].ContentPiece.Path(endCoordinate);
                for (int i = 0; i < figurePath.Count(); i++)
                {
                    cell = FindCell(figurePath[i]);

                    if (i == figurePath.Count() - 1)
                    {
                        if (cell.ContentPiece != null && cell.ContentPiece.Color == Position[StartIndex].ContentPiece.Color)
                        {
                            throw new Exception("Невозможный ход");
                        }
                    }

                    if (cell.Contains())
                    {
                        throw new Exception("Невозможный ход");
                    }
                }
                Position[StartIndex].ContentPiece.SetCoordinate(endCoordinate.ToString());
                Position[EndIndex].ChangeContent(Position[StartIndex].ContentPiece);
                Position[StartIndex].ChangeContent(" ");
                Log.Add(endCoordinate.ToString(), Position[EndIndex].ContentPiece.Color, Position[EndIndex].ContentPiece.Type);
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
