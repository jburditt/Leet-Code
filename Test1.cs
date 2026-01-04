namespace Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void Test_Add_Multiple_Values()
    {
        //var dict = new MultiValueDictionary<string, string>();
        //dict.Add("animal", "tiger");
        //dict.Add("animal", "lion");

        //Assert.AreEqual(2, dict.Flatten().Count());
        //Assert.AreEqual(2, dict.Get("animal").Count());
        //Assert.IsTrue(dict.Get("animal").Contains("tiger"));
        //Assert.IsTrue(dict.Get("animal").Contains("lion"));
        //Assert.IsTrue(dict.Flatten().Any(kv => kv.Key == "animal" && kv.Value == "tiger"));
        //Assert.IsTrue(dict.Flatten().Any(kv => kv.Key == "animal" && kv.Value == "lion"));
    }

    [TestMethod]
    public void Test_Leetcode() 
    {
        var result = TwoSum([2, 5, 5, 11], 10);
        Console.WriteLine(result);
        Assert.AreEqual(new int[2] { 1, 2 }, result);
    }

    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        dict.Add(nums[0], 0);
        for (var i = 1; i < nums.Length; i++)
        {
            if (!dict.ContainsKey(nums[i]))
                dict.Add(nums[i], i);
            if (dict.ContainsKey(target - nums[i]))
                return new int[2] { dict[target - nums[i]], i };
        }
        return null;
    }

    // 14 minutes, beats 24.03%
    public int LengthOfLongestSubstring(string s)
    {
        var dict = new Dictionary<char, int>();
        var maxSubstringLength = 0;
        var currentSubstringLength = 0;

        if (s.Length == 1)
            return 1;

        for (var i = 0; i < s.Length; i++)
        {
            if (dict.ContainsKey(s[i]))
            {
                if (currentSubstringLength > maxSubstringLength)
                    maxSubstringLength = currentSubstringLength;
                i = dict[s[i]] + 1;
                dict.Clear();
                currentSubstringLength = 0;
            }

            currentSubstringLength++;
            dict.Add(s[i], i);
        }
        return Math.Max(maxSubstringLength, currentSubstringLength);
    }
}
