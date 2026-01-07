public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var length = nums1.Length + nums2.Length;
        int index = 0, leftIndex = 0, rightIndex = 0;
        int middleIndex = length / 2;
        int pivot = middleIndex;
        bool remainder = length % 2 == 1;
        if (!remainder)
            middleIndex--;
        while (index <= pivot)
        {
            if (nums2.Length == 0 || rightIndex >= nums2.Length || (leftIndex < nums1.Length && nums1[leftIndex] <= nums2[rightIndex]))
            {
                if (index >= middleIndex && SaveValue(nums1[leftIndex], remainder))
                    break;
                leftIndex++;
            } 
            else if (rightIndex < nums2.Length)
            {
                if (index >= middleIndex && SaveValue(nums2[rightIndex], remainder))
                    break;
                rightIndex++;
            }
            index++;
        }

        if (!remainder)
            return (_savedValues[0] + _savedValues[1]) / 2d;
        else
            return _savedValues[0];
    }

    private int _savedValueCount = 0;
    // TODO Use Span
    private int[] _savedValues = new int[2];
    private bool SaveValue(int value, bool remainder)
    {
        _savedValues[_savedValueCount] = value;
        _savedValueCount++;
        return remainder || _savedValueCount > 1;
    }
}

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