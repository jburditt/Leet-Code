[TestClass]
public class _1_Two_Sum
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        dict.Add(nums[0], 0);
        for (var i = 1; i < nums.Length; i++)
        {
            if (!dict.ContainsKey(nums[i]))
                dict.Add(nums[i], i);
            if (dict.ContainsKey(target - nums[i]) && dict[target - nums[i]] != i)
                return new int[2] { dict[target - nums[i]], i };
        }
        return null;
    }

    [TestMethod]
    public void Test()
    {
        var result = TwoSum([2, 5, 5, 11], 10);
        Console.WriteLine(result);
        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(2, result[1]);
    }
}
