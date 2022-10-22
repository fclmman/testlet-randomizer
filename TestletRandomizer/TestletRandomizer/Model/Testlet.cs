namespace TestletRandomizer.Model;

public class Testlet
{
    private List<Item> _items;
    public string TestletId { get; init; }
    
    public Testlet(string testletId, List<Item> items)
    {
        TestletId = testletId;
        _items = items;
    }
    
    public List<Item> Randomize()
    {
        if(_items == null || _items.Count != 10)
        {
            throw new ArgumentException();
        }

        throw new NotImplementedException();
    }
}