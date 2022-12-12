namespace AdventOfCode2022.Day11;

internal class Monkey
{
#pragma warning disable CS8618
    public Monkey(IEnumerable<Item> items, string operationType, int operationValue, int divisibleBy, string name,
        bool originalWorryReducer)
#pragma warning restore CS8618
    {
        Name = name;
        _items = items.ToList();
        _operationType = operationType;
        _operationValue = operationValue;
        _originalWorryReducer = originalWorryReducer;
        DivisibleBy = divisibleBy;
    }

    public string Name { get; set; }

    private List<Item> _items;

    private readonly string _operationType;

    private readonly int _operationValue;

    private readonly bool _originalWorryReducer;

    public long DivisibleBy { get; }

    public Monkey SuccessfulThrowTo { get; set; }

    public Monkey UnsuccessfulThrowTo { get; set; }

    public long ItemsInspected { get; set; }
    public long DivideBy { get; set; }

    public void ThrowItems()
    {
        foreach (var item in _items.ToArray())
        {
            InspectItem(item);
            BoredWithItem(item);
            ThrowToNext(item);

            ItemsInspected++;
        }

        _items = new List<Item>();
    }

    private void ThrowToNext(Item item)
    {
        if (item.WorryLevel % DivisibleBy == 0)
        {
            SuccessfulThrowTo._items.Add(item);
        }
        else
        {
            UnsuccessfulThrowTo._items.Add(item);
        }
    }

    private void BoredWithItem(Item item)
    {
        if (_originalWorryReducer)
        {
            item.WorryLevel /= 3;
        }
        else
        {
            item.WorryLevel %= DivideBy;
        }
    }

    private void InspectItem(Item item)
    {
        if (_operationType == "+")
        {
            item.WorryLevel += _operationValue;
        }
        else if (_operationType == "*")
        {
            if (_operationValue != 0)
            {
                item.WorryLevel *= _operationValue;
            }
            else
            {
                item.WorryLevel *= item.WorryLevel;
            }
        }
    }
}