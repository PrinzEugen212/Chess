using System;

namespace Chess
{
    class Cell
    {
        public Coordinate Coordinate { get; private set; }
        public ChessPiece ContentPiece { get; private set; }
        public string Content { get; private set; }

        /// <summary>
        /// Создаёт экземпляр класса с заданной координатой
        /// </summary>
        /// <param name="coordinate">Координата, формат должен быть аналогичен Е4</param>
        public Cell(string coordinate)
        {
            Coordinate = new Coordinate(coordinate);
            Content = " ";
        }
        //public Cell(string coordinate, ChessPiece ChessPiece)
        //{
        //    Coordinate = new Coordinate(coordinate);
        //    ContentPiece = ChessPiece;
        //}

        /// <summary>
        /// Устанавливает пустое содержимое для ячейки
        /// </summary>
        /// <param name="content">Строка, должна состоять только из пробела</param>
        public void VoidContent()
        {
            Content = " ";
            ContentPiece = null;
        }

        /// <summary>
        /// Устанавливает переданную фигуру в содержимое данной ячейки
        /// </summary>
        /// <param name="ChessPiece">Фигура, которую нужно записать в данную ячейку</param>
        public void ChangeContent(ChessPiece ChessPiece)
        {
            if (ChessPiece == null)
            {
                Content = " ";
                ContentPiece = null;
                return;
            }
            ContentPiece = ChessPiece;
            Content = "";
        }
        /// <summary>
        /// Возвращает истину если клетка содержит какую-либо фигуру, ложь если клетка пуста
        /// </summary>
        /// <returns></returns>
        public bool Contains()
        {
            if (ContentPiece != null)
            {
                return true;
            }
            return false;
        }
    }
}
