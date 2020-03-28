using Core.Grid;
using System;
using System.Text;

namespace DetroitLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            var roverGrid = new RoverGridMovement();
            var rover = new Rover(new Core.Location() { X = 0, Y = 0, Facing = Direction.East });

            StringBuilder grid = new StringBuilder();

            grid.AppendLine("oooox");
            grid.AppendLine("ooxoo");
            grid.AppendLine("ooooo");
            grid.AppendLine("oxooo");
            grid.AppendLine("ooooo");

            Console.WriteLine("You are currently on a 5x5 grid.");
            Console.WriteLine("Please enter your X starting position: ");
            var x = Console.ReadLine();

            Console.WriteLine(System.Environment.NewLine + "Please enter your Y starting position: ");
            var y = Console.ReadLine();

            Console.WriteLine(System.Environment.NewLine + "Please enter your facing direction (North, South, East, or West): ");
            var facing = Console.ReadLine();

            rover.location.X = Convert.ToInt32(x);
            rover.location.Y = Convert.ToInt32(y);
            rover.location.Facing = Enum.Parse<Direction>(facing);

            roverGrid.BuildGrid(grid.ToString());

            Console.WriteLine(System.Environment.NewLine + "Please enter your movement commands (f, b, l, r) or type 'exit' to end:");

            var command = Console.ReadLine();

            while(command != "exit")
            {
                rover.Move(command, roverGrid);

                Console.WriteLine(string.Format("{0} {1}", rover.location.X, rover.location.Y));
                Console.WriteLine(rover.location.Message);

                Console.WriteLine(System.Environment.NewLine + "Please enter your movement commands (f, b, l, r) or type 'exit' to end:");
                command = Console.ReadLine();
            }
        }
    }
}
