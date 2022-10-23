using TestletRandomizer.Model;

namespace TestletRandomizer.Interface;

public interface ITestletValidator
{
    bool ValidateInput(IReadOnlyList<Item> items);
}