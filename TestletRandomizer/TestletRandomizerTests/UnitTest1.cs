using NUnit.Framework;
using TestletRandomizer.Model;

namespace TestletRandomizerTests;

public class Tests
{
    private List<Item> _items;

    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(typeof(InvalidLengthCase))]
    public void AssertExceptionOnInvalidInputLength(List<Item> testCase)
    {
        var testLet = new Testlet("id", testCase);
        Assert.Throws<ArgumentException>(() => testLet.Randomize());
    }
}