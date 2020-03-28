
namespace Core.Grid
{
    public interface IRover
    {
        Location Move(string directions, IGridMovement grid);

        Location Move(Direction direction, IGridMovement grid);

        void TurnLeft();

        void TurnRight();
    }
}
