using System;

namespace Core.Grid
{
    public class Rover : IRover
    {
        public Location location;

        private bool _stopped;

        public Rover(Location location)
        {
            this.location = location;
        }

        /// <summary>
        /// Move the rover in a given direction based on a supplied grid.
        /// </summary>
        /// <param name="directions">A string of directions the rover will move.</param>
        /// <param name="grid">A grid pattern to move the rover on.</param>
        /// <returns>The updated location.</returns>
        public Location Move(string directions, IGridMovement grid)
        {
            if (string.IsNullOrWhiteSpace(directions))
            {
                throw new ArgumentNullException("directions");
            }

            if (grid == null)
            {
                throw new ArgumentNullException("grid");
            }

            _stopped = false;

            foreach (var direction in directions)
            {
                switch(direction.ToString().ToLower())
                {
                    case "f":
                        Move(location.Facing, grid);
                        break;
                    case "b":
                        Move((Direction)(-(int)location.Facing), grid);
                        break;
                    case "l":
                        TurnLeft();
                        break;
                    case "r":
                        TurnRight();
                        break;
                    default:
                        throw new Exception(string.Format("Unknown direction '{0}'", direction));
                }

                if (_stopped)
                {
                    break;
                }
            }

            return location;
        }

        /// <summary>
        /// Move the rover in a given direction based on a supplied grid.
        /// </summary>
        /// <param name="direction">The direction the rover will move.</param>
        /// <param name="grid">A grid pattern to move the rover on.</param>
        /// <returns>The updated location.</returns>
        public Location Move(Direction direction, IGridMovement grid)
        {
            if (grid == null)
            {
                throw new ArgumentNullException("grid");
            }

            if (grid.CanMove(direction, location))
            {
                location = grid.GetMoveLocation(direction, location);
            }
            else
            {
                _stopped = true;
                location.Message = string.Format("Cannot move {0} from {1}, {2}, an obstacle is in the way.", direction, location.X, location.Y);
            }

            return location;
        }

        /// <summary>
        /// Turn the rover to face to the left.
        /// </summary>
        public void TurnLeft()
        {
            switch(location.Facing)
            {
                case Direction.North:
                    location.Facing = Direction.West;
                    break;
                case Direction.South:
                    location.Facing = Direction.East;
                    break;
                case Direction.East:
                    location.Facing = Direction.North;
                    break;
                case Direction.West:
                    location.Facing = Direction.South;
                    break;
            }
        }

        /// <summary>
        /// Turn to rover to face to the right.
        /// </summary>
        public void TurnRight()
        {
            switch (location.Facing)
            {
                case Direction.North:
                    location.Facing = Direction.East;
                    break;
                case Direction.South:
                    location.Facing = Direction.West;
                    break;
                case Direction.East:
                    location.Facing = Direction.South;
                    break;
                case Direction.West:
                    location.Facing = Direction.North;
                    break;
            }
        }
    }
}
