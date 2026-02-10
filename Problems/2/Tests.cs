namespace Leet_Code.Problems._2;

[TestClass]
public class Tests
{
    [TestMethod]
    public void Test_Case_1()
    {
        var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
        var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
        var solution = new Solution();
        var result = solution.AddTwoNumbers(l1, l2);
        var expected = new ListNode(7, new ListNode(0, new ListNode(8)));
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_Case_2()
    {
        var l1 = new ListNode(0);
        var l2 = new ListNode(0);
        var solution = new Solution();
        var result = solution.AddTwoNumbers(l1, l2);
        var expected = new ListNode(0);
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Test_Case_3()
    {
        var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
        var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
        var solution = new Solution();
        var result = solution.AddTwoNumbers(l1, l2);
        // TODO this is wrong
        var expected = new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9))));
        Assert.AreEqual(expected, result);
    }
}

