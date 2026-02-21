namespace Leet_Code.Core;

public static class AssertionExtensions
{
    public static void AssertTrue(this bool condition, string message = "Expecting value to be 'True'.")
    {
        Assert.IsTrue(condition, message);
    }

    public static void AssertFalse(this bool condition, string message = "Expecting value to be 'False'.")
    {
        Assert.IsFalse(condition, message);
    }
}