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

    [TestMethod]
    public void Test_Case_4()
    {
        string[] words = ["ab", "ba", "aaab", "abab", "baa"];
        var obj = new StreamChecker(words);
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertFalse();
    }

    [TestMethod]
    public void Test_Case_5()
    {
        string[] words = ["baa", "aa", "aaaa", "abbbb", "aba"];
        var obj = new StreamChecker(words);
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
    }

    [TestMethod]
    public void Test_Case_6()
    {
        string[] words = ["aa", "baa", "baaa", "aaa", "bbbb"];
        var obj = new StreamChecker(words);
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();

        obj.Query('b').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('b').AssertTrue();

        // remaining data, could write more asserts
        //["a"],["b"],["a"],["b"],["a"],["a"],["a"],["a"],["b"],["a"],["a"],["b"],["b"],["b"],["b"],["a"],["b"],["b"],["b"],["a"]
        //false,false,false,false,false,true,true,true,false,false,true,false,false,false,true,false,false,false,false,false
    }

    [TestMethod]
    public void Test_Case_7()
    {
        string[] words = ["aaa", "abb", "aaaab", "abaa", "baab"];
        var obj = new StreamChecker(words);
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();

        //["a"],["b"],["a"],["a"],["b"],["b"],["a"],["a"],["b"],["b"],["a"],["a"],["a"],["a"],["a"],["a"],["b"],["a"],["b"],["a"]
        //false,false,false,true ,true, true ,false,false,true ,true ,false,false,true ,true ,true ,true ,true ,false,false,false

        obj.Query('b').AssertFalse();
        obj.Query('b').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();

        //["b"],["a"],["b"],["b"],["b"],["b"],["b"],["a"],["a"],["a"],["b"],["a"],["a"],["a"],["b"],["b"],["a"],["a"],["a"],["b"]
        //false,false,false,true ,false,false,false,false,false,true ,false,false,true ,true ,false,true ,false,false,true ,false

        obj.Query('b').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertTrue();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('a').AssertTrue();  //["aaa", "abb", "aaaab", "abaa", "baab"]
        obj.Query('a').AssertTrue();
        obj.Query('b').AssertFalse();
        obj.Query('a').AssertFalse();
        obj.Query('b').AssertFalse();

        //["b"],["b"],["a"],["a"],["a"],["a"],["a"],["a"],["a"],["a"],["a"],["b"],["a"],["b"],["a"],["a"],["a"],["b"],["a"],["b"]
        //true ,false,false,false,true ,true ,true ,true ,true ,true ,true ,true ,false,false,false,true ,true ,false,false,false


        //["a"],["b"],["b"],["b"],["b"],["b"],["b"],["b"],["a"],["a"],["b"],["b"],["a"],["b"],["b"],["b"],["b"],["a"],["b"],["b"]
        //false,false,true ,false,false,false,false,false,false,false,true ,true ,false,false,true ,false,false,false,false,true

        //["b"],["b"],["a"],["a"],["a"],["a"],["a"],["a"],["a"],["a"],["a"],["b"],["a"],["b"],["a"],["a"],["a"],["b"],["a"],["b"],["a"],["b"],["b"],["b"],["b"],["b"],["b"],["b"],["a"],["a"],["b"],["b"],["a"],["b"],["b"],["b"],["b"],["a"],["b"],["b"]]
        //true,false,false,false,true,true,true,true,true,true,true,true,false,false,false,true,true,false,false,false,false,false,true,false,false,false,false,false,false,false,true,true,false,false,true,false,false,false,false,true
    }
}


