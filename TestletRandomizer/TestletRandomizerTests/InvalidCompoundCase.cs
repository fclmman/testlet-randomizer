using System.Collections;
using TestletRandomizer.Model;

namespace TestletRandomizerTests;

public class InvalidCompoundCase: IEnumerable<List<Item>>
{
    public IEnumerator<List<Item>> GetEnumerator()
    {
        yield return TestCaseGenerator.CreateTestCaseItems(new []
        {
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest
        });
        yield return TestCaseGenerator.CreateTestCaseItems(new []
        {
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest
        });
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}