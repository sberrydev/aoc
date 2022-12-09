namespace AdventOfCode2022.Day09;

internal class Head : Coordinate
{
    public void Move(string instruction)
    {
        if (instruction == "R")
            X++;
        else if (instruction == "L")
            X--;
        else if (instruction == "U")
            Y--;
        else if (instruction == "D")
            Y++;
    }
}