namespace TestletRandomizer.Model;

public class Testlet
{
    private List<Item> _items;
    private readonly Random random;
    public string TestletId { get; init; }

    public Testlet(string testletId, List<Item> items)
    {
        TestletId = testletId;
        _items = items;
        random = new Random(Int32.MaxValue);
    }

    public List<Item> Randomize()
    {
        if (!ValidateInput())
        {
            throw new ArgumentException();
        }

        return Shuffle(_items);
    }

    private bool ValidateInput()
    {
        var validator = new TestletValidator();
        return validator.ValidateInput(_items);
    }

    private List<Item> Shuffle(List<Item> items)
    {
        var shuffledItems = items.ToList();

        for (var i = shuffledItems.Count - 1; i >= 0; i--)
        {
            int index = random.Next(i + 1);
            if (index != i)
            {
                var tmp = items[index];
                items[index] = items[i];
                items[i] = tmp;
            }
        }
        return new List<Item>(shuffledItems);
    }
}