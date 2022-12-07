using System.Collections;

namespace AdventOfCode2022.Day07;

internal class Tree<T> : IEnumerable<Tree<T>>
{
    public T FileInformation { get; set; }

    public Tree<T> Parent { get; set; }

    public ICollection<Tree<T>> Children { get; set; }

#pragma warning disable CS8618 //parent can be null but I'm not handling this rn
    public Tree(T fileInfo)
#pragma warning restore CS8618
    {
        FileInformation = fileInfo;
        Children = new LinkedList<Tree<T>>();
    }

    public Tree<T> AddChild(T child)
    {
        var childInTree = new Tree<T>(child) { Parent = this };
        Children.Add(childInTree);
        return childInTree;
    }

    public IEnumerator<Tree<T>> GetEnumerator()
    {
        yield return this;
        foreach (var firstChild in Children)
        {
            foreach (var additionalChild in firstChild)
                yield return additionalChild;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}