using System;
using Core;
using Core.Grid;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreUnitTest
{
    [TestClass]
    public class RoverGridMovementUnitTest
    {
        [TestMethod]
        public void GetMoveLocationNorth()
        {
            var grid = new RoverGridMovement();
            var loc = new Location() { X = 1, Y = 1, Facing = Direction.North };
            var expected = new Location() { X = 0, Y = 1, Facing = Direction.North };

            var result = grid.GetMoveLocation(Direction.North, loc);

            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
            Assert.AreEqual(expected.Facing, result.Facing);
            Assert.AreEqual(expected.Message, result.Message);

            return;
        }

        [TestMethod]
        public void GetMoveLocationSouth()
        {
            var grid = new RoverGridMovement();
            grid.Grid = new bool[3, 3];
            var loc = new Location() { X = 1, Y = 1, Facing = Direction.North };
            var expected = new Location() { X = 2, Y = 1, Facing = Direction.North };

            var result = grid.GetMoveLocation(Direction.South, loc);

            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
            Assert.AreEqual(expected.Facing, result.Facing);
            Assert.AreEqual(expected.Message, result.Message);

            return;
        }

        [TestMethod]
        public void GetMoveLocationEast()
        {
            var grid = new RoverGridMovement();
            grid.Grid = new bool[3, 3];
            var loc = new Location() { X = 1, Y = 1, Facing = Direction.North };
            var expected = new Location() { X = 1, Y = 2, Facing = Direction.North };

            var result = grid.GetMoveLocation(Direction.East, loc);

            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
            Assert.AreEqual(expected.Facing, result.Facing);
            Assert.AreEqual(expected.Message, result.Message);

            return;
        }

        [TestMethod]
        public void GetMoveLocationWest()
        {
            var grid = new RoverGridMovement();
            var loc = new Location() { X = 1, Y = 1, Facing = Direction.North };
            var expected = new Location() { X = 1, Y = 0, Facing = Direction.North };

            var result = grid.GetMoveLocation(Direction.West, loc);

            Assert.AreEqual(expected.X, result.X);
            Assert.AreEqual(expected.Y, result.Y);
            Assert.AreEqual(expected.Facing, result.Facing);
            Assert.AreEqual(expected.Message, result.Message);

            return;
        }

        [TestMethod]
        public void BuildGridNullInput()
        {
            var grid = new RoverGridMovement();

            Assert.ThrowsException<ArgumentNullException>(() => grid.BuildGrid(null));

            return;
        }

        [TestMethod]
        public void BuildGridOpenTest()
        {
            var grid = new RoverGridMovement();
            var expected = new bool[1, 1];
            expected[0, 0] = true;

            grid.BuildGrid("o");

            Assert.AreEqual(expected[0, 0], grid.Grid[0 ,0]);

            return;
        }

        [TestMethod]
        public void BuildGridObstacleTest()
        {
            var grid = new RoverGridMovement();
            var expected = new bool[1, 1];
            expected[0, 0] = false;

            grid.BuildGrid("x");

            Assert.AreEqual(expected[0, 0], grid.Grid[0, 0]);

            return;
        }

        [TestMethod]
        public void BuildGridErrorTest()
        {
            var grid = new RoverGridMovement();
            var expected = new bool[1, 1];
            expected[0, 0] = false;

            Assert.ThrowsException<Exception>(() => grid.BuildGrid("z"));

            return;
        }
    }
}
