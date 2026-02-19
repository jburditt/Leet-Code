using System;
using System.Collections.Generic;
using System.Text;

namespace Leet_Code.Problems._3;

[TestClass]
public class Tests
{
    [TestMethod]
    public void Test1()
    {
        var solution = new Solution();
        var result = solution.LengthOfLongestSubstring("abcabcbb");
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Test2()
    {
        var solution = new Solution();
        var result = solution.LengthOfLongestSubstring("bbbbb");
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Test3()
    {
        var solution = new Solution();
        var result = solution.LengthOfLongestSubstring("pwwkew");
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Test4()
    {
        var solution = new Solution();
        var result = solution.LengthOfLongestSubstring("aab");
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Test5()
    {
        var solution = new Solution();
        var result = solution.LengthOfLongestSubstring("dvdf");
        Assert.AreEqual(3, result);
    }
}
