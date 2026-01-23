using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStreamProcessing.Q1;

[TestClass]
public class Test
{
    [TestMethod]
    public void Test_Case_1()
    {
        var kthLargest = new KthLargest(3, new int[] { 4, 5, 8, 2 });
        var result = kthLargest.Add(3);  // return 4
        Assert.AreEqual(4, result);
        result = kthLargest.Add(5);      // return 5
        Assert.AreEqual(5, result);
        result = kthLargest.Add(10);     // return 5
        Assert.AreEqual(5, result);
        result = kthLargest.Add(9);      // return 8
        Assert.AreEqual(8, result);
        result = kthLargest.Add(4);      // return 8
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void Test_Case_2()
    {
        var kthLargest = new KthLargest(1, new int[] { });
        var result = kthLargest.Add(-3);  // return -3
        Assert.AreEqual(-3, result);
        result = kthLargest.Add(-2);      // return -2
        Assert.AreEqual(-2, result);
        result = kthLargest.Add(-4);     // return -2
        Assert.AreEqual(-2, result);
        result = kthLargest.Add(0);      // return 0
        Assert.AreEqual(0, result);
        result = kthLargest.Add(4);      // return 4
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Test_Case_3()
    {
        var kthLargest = new KthLargest(2, new int[] { 0 });
        var result = kthLargest.Add(-1);  // return -1
        Assert.AreEqual(-1, result);
        result = kthLargest.Add(1);      // return 0
        Assert.AreEqual(0, result);
        result = kthLargest.Add(-2);     // return 0
        Assert.AreEqual(0, result);
        result = kthLargest.Add(-4);      // return 0
        Assert.AreEqual(0, result);
        result = kthLargest.Add(3);      // return 1
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Test_Case_4()
    {
        var kthLargest = new KthLargest(3, new int[] { 5, -1 });
        var result = kthLargest.Add(2);  // return -1
        Assert.AreEqual(-1, result);
        result = kthLargest.Add(1);      // return 1
        Assert.AreEqual(1, result);
        result = kthLargest.Add(-1);     // return 1
        Assert.AreEqual(1, result);
        result = kthLargest.Add(3);      // return 2
        Assert.AreEqual(2, result);
        result = kthLargest.Add(4);      // return 3
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Test_Case_5()
    {
        var kthLargest = new KthLargest(9, new int[] { 2, 4, 5, 8, 10, 12, 15, 18, 20, 25 });
        var result = kthLargest.Add(3);  // return 4
        Assert.AreEqual(4, result);
        result = kthLargest.Add(7);      // return 5
        Assert.AreEqual(5, result);
        result = kthLargest.Add(9);     // return 7
        Assert.AreEqual(7, result);
        result = kthLargest.Add(11);      // return 8
        Assert.AreEqual(8, result);
        result = kthLargest.Add(6);      // return 8
        Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void Test_Case_8()
    {
        var kthLargest = new KthLargest(3, new int[] { 5, 6, 2, 4, 1, 3 });
        var result = kthLargest.Add(7);  // return 5
        Assert.AreEqual(5, result);
        result = kthLargest.Add(0);      // return 5
        Assert.AreEqual(5, result);
        result = kthLargest.Add(8);     // return 6
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Test_Case_9()
    {
        var kthLargest = new KthLargest(4, new int[] { 1, 2, 3 });
        var result = kthLargest.Add(4);  // return 1
        Assert.AreEqual(1, result);
        result = kthLargest.Add(5);      // return 2
        Assert.AreEqual(2, result);
        result = kthLargest.Add(6);     // return 3
        Assert.AreEqual(3, result);
        result = kthLargest.Add(0);      // return 3
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void Test_Case_10()
    {
        var kthLargest = new KthLargest(1, new int[] { -1 });
        var result = kthLargest.Add(1);  // return 1
        Assert.AreEqual(1, result);
        result = kthLargest.Add(-2);      // return 1
        Assert.AreEqual(1, result);
        result = kthLargest.Add(-3);     // return 1
        Assert.AreEqual(1, result);
        result = kthLargest.Add(-4);      // return 1
        Assert.AreEqual(1, result);
        result = kthLargest.Add(0);      // return 1
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Test_Case_11()
    {
        var kthLargest = new KthLargest(2, new int[] { -1 });
        var result = kthLargest.Add(-2);  // return -2
        Assert.AreEqual(-2, result);
        result = kthLargest.Add(0);      // return -1
        Assert.AreEqual(-1, result);
        result = kthLargest.Add(1);     // return 0
        Assert.AreEqual(0, result);
    }
}