using Leet_Code.Core;

namespace Leet_Code.Cache_System_Design.Data_Stream_Processing.Q2;

[TestClass]
public class Tests
{
    [TestMethod]
    public void Test_Case_1()
    {
        string[] words = ["abc", "xyz"];
        var obj = new StreamChecker(words);
        obj.Query('a').AssertFalse();
        obj.Query('x').AssertFalse();
        obj.Query('y').AssertFalse();
        obj.Query('z').AssertTrue();
    }

    [TestMethod]
    public void Test_Case_3()
    {
        string[] words = ["cd", "f", "kl"];
        var obj = new StreamChecker(words);
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('c').AssertFalse();
        obj.Query('d').AssertTrue();
        obj.Query('e').AssertFalse();
        obj.Query('f').AssertTrue();
        obj.Query('g').AssertFalse();
        obj.Query('h').AssertFalse();
        obj.Query('i').AssertFalse();
        obj.Query('j').AssertFalse();
        obj.Query('k').AssertFalse();
        obj.Query('l').AssertTrue();
    }
}


