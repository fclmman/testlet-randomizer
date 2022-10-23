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
    
    [TestCaseSource(typeof(InvalidCompoundCase))]
    public void AssertExceptionOnInvalidCompound(List<Item> testCase)
    {
        var testLet = new Testlet("id", testCase);
        Assert.Throws<ArgumentException>(() => testLet.Randomize());
    }
    
    [TestCaseSource(typeof(ValidSourceCase))]
    public void AssertNoExceptionOnValidCompound(List<Item> testCase)
    {
        var testLet = new Testlet("id", testCase);
        Assert.DoesNotThrow(() => testLet.Randomize());
    }
    
    [TestCaseSource(typeof(ValidSourceCase))]
    public void AssertResultHasSameSize(List<Item> testCase)
    {
        var testLet = new Testlet("id", testCase);
        var result = testLet.Randomize();
        Assert.True(result.Count == testCase.Count);
    }
    
    [TestCaseSource(typeof(ValidSourceCase))]
    public void AssertResultHasSameItems(List<Item> testCase)
    {
        var testLet = new Testlet("id", testCase);
        var result = testLet.Randomize();
        Assert.True(result.All(testCase.Contains));
    }
    
    [TestCaseSource(typeof(ValidSourceCase))]
    public void AssertListShuffled(List<Item> testCase)
    {
        var testLet = new Testlet("id", testCase);
        var result = testLet.Randomize();
        Assert.True(result.Count == testCase.Count);

        var allEqual = true;
        var i = 0;
        foreach (var res in result)
        {
            if (res != testCase[i])
            {
                allEqual = false;
            }
            i++;
        }
        Assert.False(allEqual);
    }
    
    [TestCaseSource(typeof(ValidSourceCase))]
    public void AssertFirstTwoArePretest(List<Item> testCase)
    {
        var testLet = new Testlet("id", testCase);
        var result = testLet.Randomize();
        Assert.True(result[0] != null && result[0].ItemType == ItemType.Pretest);
        Assert.True(result[1] != null && result[1].ItemType == ItemType.Pretest);
    }
}