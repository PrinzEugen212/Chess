using NUnit.Framework;
using System;
using Chess;

namespace Tests
{
    public class MoveTests
    {
        [TestFixture]
        public class TestClass
        {
            [TestCase("F1", "C4", true, true)]
            public void TestBishop(string coordinate, string endCoordinate, bool color, bool result)
            {
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                Bishop bishop = new Bishop(coordinate, color);
                Assert.AreEqual(bishop.CheckMove(endCoordinateC), result);
            }
            [TestCase("D1", "D4", true, true)]
            public void TestQueen(string coordinate, string endCoordinate, bool color, bool result)
            {
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                Queen queen = new Queen(coordinate, color);
                Assert.AreEqual(queen.CheckMove(endCoordinateC), result);
                
            }
        }
    }
}
