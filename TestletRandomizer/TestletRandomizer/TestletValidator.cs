using TestletRandomizer.Interface;
using TestletRandomizer.Model;

namespace TestletRandomizer;

public class TestletValidator : ITestletValidator
{
    private readonly int _size = 10;
    private readonly int _pretest = 4;
    private readonly int _operational = 6;
    
    public bool ValidateInput(IReadOnlyList<Item> items)
    {
        return ValidateSize(items) && ValidateCompound(items);
    }

    private bool ValidateSize(IReadOnlyList<Item> items)
    {
        return items != null && items.Count == _size;
    }

    private bool ValidateCompound(IReadOnlyList<Item> items)
    {
        var pretest = items.Count(item => item.ItemType == ItemType.Pretest);
        var operational = items.Count(item => item.ItemType == ItemType.Operational);
        return pretest == _pretest && operational == _operational;
    }
}