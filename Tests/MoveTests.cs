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
            [TestCase("F1", "A6", true)]
            [TestCase("C4", "F1", true)]
            [TestCase("C1", "G5", true)]
            [TestCase("B2", "C1", true)]
            [TestCase("F1", "A4", false)]
            [TestCase("C4", "G5", false)]
            [TestCase("G3", "E2", false)]
            [TestCase("E7", "B3", false)]
            public void TestBishop(string coordinate, string endCoordinate, bool result)
            {
                // moves don't depend to color so it doesn't matter
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                Bishop bishop = new Bishop(coordinate, true);
                Assert.AreEqual(bishop.CheckMove(endCoordinateC), result);
            }


            [TestCase("D1", "D4", true)]
            [TestCase("H4", "A4", true)]
            [TestCase("D1", "C8", false)]
            [TestCase("H4", "A6", false)]
            [TestCase("F1", "C4", true)]
            [TestCase("G1", "A7", true)]
            [TestCase("G3", "E2", false)]
            [TestCase("E7", "B3", false)]
            public void TestQueen(string coordinate, string endCoordinate, bool result)
            {
                // moves don't depend to color so it doesn't matter
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                Queen queen = new Queen(coordinate, true);
                Assert.AreEqual(queen.CheckMove(endCoordinateC), result);
            }

            [TestCase("H1", "H8", true)]
            [TestCase("H8", "H1", true)]
            [TestCase("A4", "H4", true)]
            [TestCase("A8", "H8", true)]
            [TestCase("A8", "H1", false)]
            [TestCase("A1", "B2", false)]
            [TestCase("E4", "H5", false)]
            [TestCase("D4", "E1", false)]
            public void TestRock(string coordinate, string endCoordinate, bool result)
            {
                // moves don't depend to color so it doesn't matter
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                Rock rock = new Rock(coordinate, true);
                Assert.AreEqual(rock.CheckMove(endCoordinateC), result);
            }

            [TestCase("G1", "F3", true)]
            [TestCase("F3", "E5", true)]
            [TestCase("E5", "F3", true)]
            [TestCase("B1", "A3", true)]
            [TestCase("G1", "G3", false)]
            [TestCase("G1", "H4", false)]
            [TestCase("E5", "C2", false)]
            [TestCase("D4", "F1", false)]
            public void TestKnight(string coordinate, string endCoordinate, bool result)
            {
                // moves don't depend to color so it doesn't matter
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                Knight knight = new Knight(coordinate, true);
                Assert.AreEqual(knight.CheckMove(endCoordinateC), result);
            }

            [TestCase("G1", "F1", true)]
            [TestCase("F3", "E4", true)]
            [TestCase("E5", "E6", true)]
            [TestCase("B1", "A1", true)]
            [TestCase("G1", "G3", false)]
            [TestCase("G1", "H4", false)]
            [TestCase("E5", "C2", false)]
            [TestCase("D4", "F1", false)]
            public void TestKing(string coordinate, string endCoordinate, bool result)
            {
                // moves don't depend to color so it doesn't matter
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                King king = new King(coordinate, true);
                Assert.AreEqual(king.CheckMove(endCoordinateC), result);
            }

            [TestCase("E2", "E4", true)]
            [TestCase("A2", "A4", true)]
            [TestCase("H2", "H4", true)]
            [TestCase("H2", "H3", true)]
            [TestCase("G2", "H4", false)]
            [TestCase("F2", "F1", false)]
            [TestCase("E5", "E7", false)]
            [TestCase("D4", "E4", false)]
            public void TestWhitePawn(string coordinate, string endCoordinate, bool result)
            {
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                Pawn pawn = new Pawn(coordinate, true);
                Assert.AreEqual(pawn.CheckMove(endCoordinateC), result);
            }

            [TestCase("E7", "E5", true)]
            [TestCase("A7", "A5", true)]
            [TestCase("H7", "H5", true)]
            [TestCase("H7", "H6", true)]
            [TestCase("G7", "H5", false)]
            [TestCase("F7", "F8", false)]
            [TestCase("E7", "D5", false)]
            [TestCase("D4", "E4", false)]
            public void TestBlackPawn(string coordinate, string endCoordinate, bool result)
            {
                Coordinate endCoordinateC = new Coordinate(endCoordinate);
                Pawn pawn = new Pawn(coordinate, false);
                Assert.AreEqual(pawn.CheckMove(endCoordinateC), result);
            }
        }
    }
}
