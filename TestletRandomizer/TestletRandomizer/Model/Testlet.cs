namespace TestletRandomizer.Model;

public class Testlet
{
    private List<Item> _items;
    private readonly Random random;
    private const int _pretest = 2;
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

        var res = Shuffle(_items);
        MovePretestItemsToStart(res);
        return res;
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
            shuffledItems = ChangePlace(index, i, shuffledItems);
        }

        return new List<Item>(shuffledItems);
    }

    private void MovePretestItemsToStart(List<Item> items)
    {
        var moved = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemType == ItemType.Pretest)
            {
                ChangePlace(i, moved, items);
                moved+=1;
            }

            if (moved >= _pretest)
            {
                break;
            }
        }
    }

    private List<Item> ChangePlace(int i, int j, List<Item> items)
    {
        if (i == j)
        {
            return items;
        }

        var tmp = items[i];
        items[i] = items[j];
        items[j] = tmp;
        return items;
    }
}