
namespace Core.Grid
{
    public interface IGridMovement
    {
        void BuildGrid(string input);

        bool CanMove(Direction direction, Location location);

        Location GetMoveLocation(Direction direction, Location location);
    }
}
