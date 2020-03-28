using System;
using Core;
using Core.Grid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CoreUnitTest
{
    [TestClass]
    public class RoverUnitTest
    {
        [TestMethod]
        public void FaceNorthTurnLeft()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.North });

            rover.TurnLeft();

            Assert.AreEqual(Direction.West, rover.location.Facing);

            return;
        }

        [TestMethod]
        public void FaceSouthTurnLeft()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.South });

            rover.TurnLeft();

            Assert.AreEqual(Direction.East, rover.location.Facing);

            return;
        }

        [TestMethod]
        public void FaceWestTurnLeft()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.West });

            rover.TurnLeft();

            Assert.AreEqual(Direction.South, rover.location.Facing);

            return;
        }

        [TestMethod]
        public void FaceEastTurnLeft()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.East });

            rover.TurnLeft();

            Assert.AreEqual(Direction.North, rover.location.Facing);

            return;
        }

        [TestMethod]
        public void FaceNorthTurnRight()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.North });

            rover.TurnRight();

            Assert.AreEqual(Direction.East, rover.location.Facing);

            return;
        }

        [TestMethod]
        public void FaceSouthTurnRight()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.South });

            rover.TurnRight();

            Assert.AreEqual(Direction.West, rover.location.Facing);

            return;
        }

        [TestMethod]
        public void FaceWestTurnRight()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.West });

            rover.TurnRight();

            Assert.AreEqual(Direction.North, rover.location.Facing);

            return;
        }

        [TestMethod]
        public void FaceEastTurnRight()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.East });

            rover.TurnRight();

            Assert.AreEqual(Direction.South, rover.location.Facing);

            return;
        }

        [TestMethod]
        public void MoveWithNullGrid()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.East });

            Assert.ThrowsException<ArgumentNullException>(() => rover.Move(Direction.North, null));

            return;
        }

        [TestMethod]
        public void MoveWithCanMove()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.North });
            var loc = new Location() { X = 1, Y = 1, Facing = rover.location.Facing };
            var iGrid = new Mock<IGridMovement>();
            
            iGrid.Setup(g => g.CanMove(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(true);
            iGrid.Setup(g => g.GetMoveLocation(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(loc);

            rover.Move(Direction.North, iGrid.Object);

            Assert.AreEqual(rover.location, loc);

            return;
        }

        [TestMethod]
        public void MoveWithCannotMove()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.North });
            var loc = new Location() { X = 0, Y = 0, Facing = rover.location.Facing, Message = "Cannot move North from 0, 0, an obstacle is in the way." };
            var iGrid = new Mock<IGridMovement>();

            iGrid.Setup(g => g.CanMove(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(false);
            iGrid.Setup(g => g.GetMoveLocation(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(loc);

            rover.Move(Direction.North, iGrid.Object);

            Assert.AreEqual(rover.location.X, loc.X);
            Assert.AreEqual(rover.location.Y, loc.Y);
            Assert.AreEqual(rover.location.Facing, loc.Facing);
            Assert.AreEqual(rover.location.Message, loc.Message);

            return;
        }

        [TestMethod]
        public void MoveNullDirections()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.North });
            
            Assert.ThrowsException<ArgumentNullException>(() => rover.Move(null, null));

            return;
        }

        [TestMethod]
        public void MoveNullGrid()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.North });

            Assert.ThrowsException<ArgumentNullException>(() => rover.Move("ffff", null));

            return;
        }

        [TestMethod]
        public void MoveForward()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.East });
            var loc = new Location() { X = 0, Y = 1, Facing = rover.location.Facing };
            var iGrid = new Mock<IGridMovement>();

            iGrid.Setup(g => g.CanMove(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(true);
            iGrid.Setup(g => g.GetMoveLocation(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(loc);

            rover.Move("f", iGrid.Object);

            Assert.AreEqual(rover.location, loc);

            return;
        }

        [TestMethod]
        public void MoveBackward()
        {
            var rover = new Rover(new Location() { X = 0, Y = 1, Facing = Direction.East });
            var loc = new Location() { X = 0, Y = 0, Facing = rover.location.Facing };
            var iGrid = new Mock<IGridMovement>();

            iGrid.Setup(g => g.CanMove(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(true);
            iGrid.Setup(g => g.GetMoveLocation(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(loc);

            rover.Move("b", iGrid.Object);

            Assert.AreEqual(rover.location, loc);

            return;
        }

        [TestMethod]
        public void MoveTurnLeft()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.East });
            var loc = new Location() { X = 0, Y = 0, Facing = Direction.North };
            var iGrid = new Mock<IGridMovement>();

            iGrid.Setup(g => g.CanMove(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(true);
            iGrid.Setup(g => g.GetMoveLocation(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(loc);

            rover.Move("l", iGrid.Object);

            Assert.AreEqual(rover.location.X, loc.X);
            Assert.AreEqual(rover.location.Y, loc.Y);
            Assert.AreEqual(rover.location.Facing, loc.Facing);
            Assert.AreEqual(rover.location.Message, loc.Message);

            return;
        }

        [TestMethod]
        public void MoveTurnRight()
        {
            var rover = new Rover(new Location() { X = 0, Y = 0, Facing = Direction.East });
            var loc = new Location() { X = 0, Y = 0, Facing = Direction.South };
            var iGrid = new Mock<IGridMovement>();

            iGrid.Setup(g => g.CanMove(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(true);
            iGrid.Setup(g => g.GetMoveLocation(It.IsAny<Direction>(), It.IsAny<Location>())).Returns(loc);

            rover.Move("r", iGrid.Object);

            Assert.AreEqual(rover.location.X, loc.X);
            Assert.AreEqual(rover.location.Y, loc.Y);
            Assert.AreEqual(rover.location.Facing, loc.Facing);
            Assert.AreEqual(rover.location.Message, loc.Message);

            return;
        }
    }
}
