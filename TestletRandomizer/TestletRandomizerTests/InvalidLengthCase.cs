using System.Collections;
using TestletRandomizer.Model;

namespace TestletRandomizerTests;

public class InvalidLengthCase: IEnumerable<List<Item>>
{
    public IEnumerator<List<Item>> GetEnumerator()
    {
        yield return null;
        yield return TestCaseGenerator.CreateTestCaseItems(Enumerable.Empty<ItemType>());
        yield return TestCaseGenerator.CreateTestCaseItems(new []
        {
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Pretest
        });
        yield return TestCaseGenerator.CreateTestCaseItems(new []
        {
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Pretest
        });
        yield return TestCaseGenerator.CreateTestCaseItems(new []
        {
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Pretest,
        });
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}