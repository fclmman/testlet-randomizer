using System.Collections;
using TestletRandomizer.Model;

namespace TestletRandomizerTests;

public class ValidSourceCase: IEnumerable<List<Item>>
{
    public IEnumerator<List<Item>> GetEnumerator()
    {
        yield return TestCaseGenerator.CreateTestCaseItems(new []
        {
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest
        });
        yield return TestCaseGenerator.CreateTestCaseItems(new []
        {
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Pretest,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational,
            ItemType.Operational
        });
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}