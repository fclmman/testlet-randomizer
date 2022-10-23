using TestletRandomizer.Model;

namespace TestletRandomizerTests;

public class ItemComparer : IEqualityComparer<Item>
{
    public bool Equals(Item x, Item y)
    {
        if (x.ItemId == y.ItemId && x.ItemId.ToLower() == y.ItemId.ToLower())
            return true;

        return false;
    }

    public int GetHashCode(Item obj)
    {
        return obj.GetHashCode();
    }
}