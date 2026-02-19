namespace Leet_Code.Problems._4;

[TestClass]
public class Test
{
    private Solution s = new();

    [TestMethod]
    public void Test_Case_1()
    {
        int[] nums1 = [1, 3];
        int[] nums2 = [2];
        var result = s.FindMedianSortedArrays(nums1, nums2);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Test_Case_2()
    {
        int[] nums1 = [1, 2];
        int[] nums2 = [3, 4];
        var result = s.FindMedianSortedArrays(nums1, nums2);
        Assert.AreEqual(2.5d, result);
    }

    [TestMethod]
    public void Test_Submission_Case_2()
    {
        int[] nums1 = [0, 0];
        int[] nums2 = [0, 0];
        var result = s.FindMedianSortedArrays(nums1, nums2);
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Test_Submission_Case_4()
    {
        int[] nums1 = [2];
        int[] nums2 = [];
        var result = s.FindMedianSortedArrays(nums1, nums2);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Test_Submission_Case_43()
    {
        int[] nums1 = [100001];
        int[] nums2 = [100000];
        var result = s.FindMedianSortedArrays(nums1, nums2);
        Assert.AreEqual(100000.5d, result);
    }
}