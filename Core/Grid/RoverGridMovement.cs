using System;

namespace Core.Grid
{
    public class RoverGridMovement : IGridMovement
    {
        private bool initialized;

        public bool[,] Grid;

        /// <summary>
        /// Build a grid from a string. Each newline represents a new grid row. A value of O is an open cell, and a value of X is an obstacle.
        /// </summary>
        /// <returns></returns>
        public void BuildGrid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException(input);
            }

            var row = 0;

            using (System.IO.StringReader reader = new System.IO.StringReader(input))
            {
                var line = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    if (!initialized)
                    {
                        Grid = new bool[input.Split('\n').Length - 1 < 1 ? 1 : input.Split('\n').Length - 1, line.Length];
                        initialized = true;
                    }

                    var col = 0;

                    foreach(var cell in line)
                    {
                        if (cell.ToString().ToLower() == "o")
                        {
                            Grid[row, col] = true;
                        }
                        else if (cell.ToString().ToLower() == "x")
                        {
                            Grid[row, col] = false;
                        }
                        else
                        {
                            throw new Exception(string.Format("Unknown grid type '{0}'", cell));
                        }

                        col++;
                    }

                    row++;
                }
            }
        }

        /// <summary>
        /// Checks whether the next cell to move to is open.
        /// </summary>
        /// <param name="direction">The direction in which to move.</param>
        /// <param name="location">The current location to move from.</param>
        /// <returns>Can a move occur to the new cell</returns>
        public bool CanMove(Direction direction, Location location)
        {
            var newLocation = GetMoveLocation(direction, location);

            return Grid[newLocation.X, newLocation.Y];
        }

        /// <summary>
        /// Gets the new moved to location
        /// </summary>
        /// <param name="direction">The direction in which to move.</param>
        /// <param name="location">The current cell location.</param>
        /// <returns>The updated cell location</returns>
        public Location GetMoveLocation(Direction direction, Location location)
        {
            var newLocation = new Location();
            newLocation.X = location.X;
            newLocation.Y = location.Y;
            newLocation.Facing = location.Facing;

            switch (direction)
            {
                case Direction.North:
                    if (location.X > 0)
                    {
                        newLocation.X = location.X - 1;
                    }
                    else
                    {
                        newLocation.X = Grid.GetLength(0) - 1;
                    }

                    break;

                case Direction.South:
                    if (location.X < Grid.GetLength(0) - 1)
                    {
                        newLocation.X = location.X + 1;
                    }
                    else
                    {
                        newLocation.X = 0;
                    }

                    break;

                case Direction.East:
                    if (location.Y < Grid.GetLength(1) - 1)
                    {
                        newLocation.Y = location.Y + 1;
                    }
                    else
                    {
                        newLocation.Y = 0;
                    }

                    break;

                case Direction.West:
                    if (location.Y > 0)
                    {
                        newLocation.Y = location.Y - 1;
                    }
                    else
                    {
                        newLocation.Y = Grid.GetLength(1) - 1;
                    }

                    break;
            }

            return newLocation;
        }
    }
}
