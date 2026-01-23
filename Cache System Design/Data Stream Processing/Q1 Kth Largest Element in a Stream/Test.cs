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
}