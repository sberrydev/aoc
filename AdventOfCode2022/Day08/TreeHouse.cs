namespace AdventOfCode2022.Day08;

internal class TreeHouse
{
    private readonly IEnumerable<string> _lines;

    public TreeHouse(IEnumerable<string> lines)
    {
        _lines = lines;
    }

    public int PuzzleOne() => CalculateVisibleTrees();

    public int PuzzleTwo() => CalculateTreeView();

    public int CalculateVisibleTrees()
    {
        var count = _lines.Count() * 4 - 4; //4 sides;
        var totalY = _lines.Count();
        var totalX = _lines.First().Length;

        var trees = _lines.Select(line => line.Select(digit => int.Parse(digit.ToString())).ToArray()).ToArray();

        // minus 2 as these have already been included in count
        count += Enumerable.Range(1, totalY - 2)
            .Sum(y => Enumerable.Range(1, totalX - 2).Count(x => IsVisible(x, y, trees)));

        return count;
    }

    public int CalculateTreeView()
    {
        var totalY = _lines.Count();
        var totalX = _lines.First().Length;
        List<int> view = new();

        var trees = _lines.Select(line => line.Select(digit => int.Parse(digit.ToString())).ToArray()).ToArray();

        view.AddRange(Enumerable.Range(1, totalY - 1)
            .SelectMany(y => Enumerable.Range(1, totalX - 1)
                .Select(x => ScenicView(x, y, trees))));

        return view.Max();
    }

    private bool IsVisible(int x, int y, int[][] trees)
    {
        var current = trees[x][y];
        var totalY = _lines.Count();
        var totalX = _lines.First().Length;
        var visibleLeft = true;
        var visibleRight = true;
        var visibleTop = true;
        var visibleBottom = true;

        for (var iteratorX = 0; iteratorX < totalX; iteratorX++)
        {
            if (iteratorX < x && trees[iteratorX][y] >= current)
            {
                visibleLeft = false;
                iteratorX = x;
            }

            else if (iteratorX > x && trees[iteratorX][y] >= current)
            {
                visibleRight = false;
                iteratorX = totalX;
            }
        }

        for (var iteratorY = 0; iteratorY < totalY; iteratorY++)
        {
            if (iteratorY < y && trees[x][iteratorY] >= current)
            {
                visibleTop = false;
                iteratorY = y;
            }

            else if (iteratorY > y && trees[x][iteratorY] >= current)
            {
                visibleBottom = false;
                iteratorY = totalY;
            }
        }

        return visibleBottom || visibleLeft || visibleRight || visibleTop;
    }

    private int ScenicView(int x, int y, int[][] trees)
    {
        var current = trees[x][y];
        var totalY = _lines.Count();
        var totalX = _lines.First().Length;
        var visibleLeft = 0;
        var visibleRight = 0;
        var visibleTop = 0;
        var visibleBottom = 0;

        for (var iteratorX = x - 1; iteratorX >= 0; iteratorX--)
        {
            if (trees[iteratorX][y] >= current)
            {
                //last visible
                visibleLeft++;
                iteratorX = 0;
            }
            else
            {
                visibleLeft++;
            }
        }

        for (var iteratorX = x + 1; iteratorX < totalX; iteratorX++)
        {
            if (trees[iteratorX][y] >= current)
            {
                //last visible
                visibleRight++;
                iteratorX = totalX;
            }
            else
            {
                visibleRight++;
            }
        }

        for (var iteratorY = y - 1; iteratorY >= 0; iteratorY--)
        {
            if (trees[x][iteratorY] >= current)
            {
                //last visible
                visibleTop++;
                iteratorY = 0;
            }
            else
            {
                visibleTop++;
            }
        }

        for (var iteratorY = y + 1; iteratorY < totalY; iteratorY++)
        {
            if (trees[x][iteratorY] >= current)
            {
                //last visible
                visibleBottom++;
                iteratorY = totalY;
            }
            else
            {
                visibleBottom++;
            }
        }

        return visibleBottom * visibleTop * visibleRight * visibleLeft;
    }
}