namespace AdventOfCode2022.Day09;

internal class Tail : Coordinate
{
    public Tail(Coordinate head)
    {
        _head = head;
    }

    private readonly Coordinate _head;

    public void Move()
    {
        //if two away move towards it
        //it two away and in another column/row, change column/row 
        if (ShouldMoveRight())
        {
            X++;
            if (ShouldMoveDownDiagonally())
            {
                Y++;
            }
            else if (ShouldMoveUpDiagonally())
            {
                Y--;
            }
        }
        else if (ShouldMoveLeft())
        {
            X--;
            if (ShouldMoveDownDiagonally())
            {
                Y++;
            }
            else if (ShouldMoveUpDiagonally())
            {
                Y--;
            }
        }

        if (ShouldMoveDown())
        {
            Y++;
            if (ShouldMoveRightDiagonally())
            {
                X++;
            }
            else if (ShouldMoveLeftDiagonally())
            {
                X--;
            }
        }
        else if (ShouldMoveUp())
        {
            Y--;
            if (ShouldMoveRightDiagonally())
            {
                X++;
            }
            else if (ShouldMoveLeftDiagonally())
            {
                X--;
            }
        }
    }

    private bool ShouldMoveLeftDiagonally() => X > _head.X;

    private bool ShouldMoveRightDiagonally() => _head.X > X;

    private bool ShouldMoveUpDiagonally() => Y > _head.Y;

    private bool ShouldMoveDownDiagonally() => _head.Y > Y;

    private bool ShouldMoveUp() => Y - _head.Y > 1;

    private bool ShouldMoveDown() => _head.Y - Y > 1;

    private bool ShouldMoveLeft() => X - _head.X > 1;

    private bool ShouldMoveRight() => _head.X - X > 1;
}