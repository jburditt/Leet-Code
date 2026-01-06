[TestClass]
public class _3_Longest_Substring_Without_Repeating_Characters
{
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
