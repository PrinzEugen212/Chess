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
            for (int i = 0; i < Position.Length; i++) // поиск королей по доске
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
        /// Проверка пути переданной фигуры на "пригодность" к передвижению 
        /// </summary>
        /// <param name="figurePath">Путь фигуры, который нужно проверить</param>
        /// <param name="movingPiece">Передвигаемая фигура</param>
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
        /// <summary>
        /// Устанавливает начальную позицию фигур на доске
        /// </summary>
        private void SetStandartPosition()
        {
            string[] Verticals = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            string P = "R N B Q K B N R " + "P P P P P P P P " + "P P P P P P P P " + "R N B Q K B N R ";
            string[] Contents = P.Split(' ');
            int VNum, HNum; // Номера текущей горизонтали и вертикали в цикле
            for (int i = 0; i < Position.Length; i++)
            {
                VNum = i % 8;               // получение номера вертикали и горизонтали
                HNum = Math.Abs(i / 8 - 8); // получение номера вертикали и горизонтали
                string Coordinate = Verticals[VNum].ToString() + HNum.ToString();
                Position[i] = new Cell(Coordinate);
                if (HNum == 1 || HNum == 2) // на первой и второй горизонталях располагаются белые фигуры
                {
                    Position[i].ChangeContent(ChessFactory.Create(Coordinate, Convert.ToChar(Contents[i - 32]), true)); // вычитание нужно потому что 1 и 2 горизонтали находятся в конце массива Position. 32 - размер половины массива
                }
                else if (HNum == 7 || HNum == 8) // на седьмой и восьмой горизонталях располагаются чёрные фигуры
                {
                    Position[i].ChangeContent(ChessFactory.Create(Coordinate, Convert.ToChar(Contents[i]), false)); // 7 и 8 горизонтали находятся в начале, вычитание не нужно
                }
                else // на всех остальных горизонталях фигур нет
                {
                    Position[i].VoidContent();
                }
            }
        }

        /// <summary>
        /// Возвращает ячейку по заданной координате
        /// </summary>
        /// <param name="coordinate">Кооордината, по которой нужно найти ячейку</param>
        /// <returns></returns>
        private Cell FindCell(Coordinate coordinate)
        {
            int index = Math.Abs(coordinate.Horizontal - 8) * 8 + coordinate.Vertical - 1; // парсинг текущего номера вертикали и горизонтали в индекс массива
            return Position[index];
        }

        /// <summary>
        /// Возвращает ячейку по заданной координате в виде строки
        /// </summary>
        /// <param name="coordinate">Координата, формат должен быть аналогичен Е4</param>
        /// <returns></returns>
        private Cell FindCell(string coordinate)
        {
            Coordinate c = new Coordinate(coordinate);
            int index = Math.Abs(c.Horizontal - 8) * 8 + c.Vertical - 1; // парсинг текущего номера вертикали и горизонтали в индекс массива
            return Position[index];
        }

        /// <summary>
        /// Перемещает фигуру из начальной координаты в конечную, если это возможно
        /// </summary>
        /// <param name="startCoordinate"></param>
        /// <param name="endCoordinate"></param>
        public void Move(Coordinate startCoordinate, Coordinate endCoordinate)
        {
            DynamicArray<Coordinate> figurePath;
            Cell startCell = FindCell(startCoordinate), endCell = FindCell(endCoordinate);

            if (startCell.ContentPiece == null)
            {
                throw new Exception("В ячейке с выбранной начальной координатой нет фигуры");
            }

            CheckTurn(startCell.ContentPiece);
            ChessPiece movingPiece = startCell.ContentPiece;


            if (movingPiece.CheckMove(endCoordinate))
            {
                figurePath = movingPiece.Path(endCoordinate);
                CheckWithOtherPieces(figurePath, movingPiece);
                ChessPiece temp1 = startCell.ContentPiece, temp2 = endCell.ContentPiece;
                try
                {
                    endCell.ChangeContent(startCell.ContentPiece);
                    startCell.VoidContent();
                    movingPiece.SetCoordinate(endCoordinate.ToString());
                    CheckCheck();
                }
                catch (Exception)
                {

                    endCell.ChangeContent(temp2);
                    startCell.ChangeContent(temp1);
                    movingPiece.SetCoordinate(startCell.Coordinate.ToString());
                    throw new Exception("Шах");
                }
                movingPiece.SetCoordinate(endCoordinate.ToString());
                Log.Add(endCoordinate.ToString(), endCell.ContentPiece.Color, endCell.ContentPiece.Type);
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
