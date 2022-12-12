namespace AdventOfCode2022.Day12;

internal class HillClimbing
{
    private readonly string[] _lines;

    public HillClimbing(IEnumerable<string> lines)
    {
        _lines = lines.ToArray();
    }

    public int PuzzleOne()
    {
        var startPoint = GetCoordinateForValue('S').First();
        var endPoint = GetCoordinateForValue('E').First();

        return GetShortestPath(startPoint, endPoint).Count - 1;
    }

    public int PuzzleTwo()
    {
        var startPoints = GetCoordinateForValue('a');
        var endPoint = GetCoordinateForValue('E').First();

        var allPathLengths = startPoints.Select(startPoint => GetShortestPath(startPoint, endPoint).Count - 1).ToList();
        return allPathLengths.Where(path => path != 0).Min();
    }

    private List<Node> BuildShortestPath(List<Node> list, Node node)
    {
        if (node.Head != null)
        {
            list.Add(node.Head);
            BuildShortestPath(list, node.Head);
        }

        return list;
    }

    //working from example here:
    //https://www.codeproject.com/Articles/1221034/Pathfinding-Algorithms-in-Csharp
    public List<Node> GetShortestPath(Coordinate startPoint, Coordinate endPoint)
    {
        var pathQueue = new Queue<Node>();
        var map = CreateMap();


        pathQueue.Enqueue(map[startPoint.X, startPoint.Y]);

        while (pathQueue.Any())
        {
            var currentNode = pathQueue.Dequeue();
            currentNode.Visited = true;

            if (currentNode.X > 0)
            {
                var childNode = map[currentNode.X - 1, currentNode.Y];
                EnqueueValidChild(childNode, currentNode, pathQueue);
            }

            if (currentNode.X < _lines[0].Length - 1)
            {
                var childNode = map[currentNode.X + 1, currentNode.Y];
                EnqueueValidChild(childNode, currentNode, pathQueue);
            }

            if (currentNode.Y > 0)
            {
                var childNode = map[currentNode.X, currentNode.Y - 1];
                EnqueueValidChild(childNode, currentNode, pathQueue);
            }

            if (currentNode.Y < _lines.Length - 1)
            {
                var childNode = map[currentNode.X, currentNode.Y + 1];
                EnqueueValidChild(childNode, currentNode, pathQueue);
            }
        }

        var endNode = map[endPoint.X, endPoint.Y];
        var path = new List<Node> { endNode };

        return BuildShortestPath(path, endNode);
    }

    private void EnqueueValidChild(Node childNode, Node parentNode, Queue<Node> pathQueue)
    {
        if (!pathQueue.Contains(childNode) &&
            !childNode.Visited &&
            childNode.Value - parentNode.Value <= 1)
        {
            childNode.Head = parentNode;
            pathQueue.Enqueue(childNode);
        }
    }

    private IEnumerable<Coordinate> GetCoordinateForValue(char value)
    {
        for (var y = 0; y < _lines.Length; y++)
        {
            for (var x = 0; x < _lines.First().Length; x++)
            {
                if (_lines[y][x] == value)
                {
                    yield return new Coordinate(x, y);
                }
            }
        }
    }

    private Node[,] CreateMap()
    {
        int maxX = _lines.ElementAt(0).Length;
        int maxY = _lines.Length;
        var map = new Node[maxX, maxY];

        for (var y = 0; y < maxY; y++)
        {
            for (var x = 0; x < maxX; x++)
            {
                if (_lines[y][x] == 'S')
                {
                    map[x, y] = new Node(x, y, 'a');
                }
                else if (_lines[y][x] == 'E')
                {
                    map[x, y] = new Node(x, y, 'z');
                }
                else
                {
                    map[x, y] = new Node(x, y, _lines[y][x]);
                }
            }
        }

        return map;
    }
}