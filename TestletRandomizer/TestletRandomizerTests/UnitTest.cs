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
        Assert.True(testLet.Randomize().Count == testCase.Count);
    }
    
    [TestCaseSource(typeof(ValidSourceCase))]
    public void AssertListShuffled(List<Item> testCase)
    {
        var testLet = new Testlet("id", testCase);
        Assert.False(testLet.Randomize() == testCase);
    }
}