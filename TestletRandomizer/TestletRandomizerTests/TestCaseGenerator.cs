using TestletRandomizer.Model;

namespace TestletRandomizerTests;

public class TestCaseGenerator
{
    public static List<Item> CreateTestCaseItems(IEnumerable<ItemType> itemTypes)
    {
        return itemTypes.Select((itemType, index) =>
            new Item
            {
                ItemId = index.ToString(),
                ItemType = itemType
            }
        ).ToList();
    }
}