namespace Leet_Code.Problems._3;

public class Solution
{
    // NOTE I'll be honest here, this one required looking up the "Sliding Window" solution as a concept and then that was enough to develop the solution on my own
    // in other words, I cheated, but only a little bit
    //  minutes, beats .0%
    public int LengthOfLongestSubstring(string s)
    {
        // TODO change to HashSet
        var dict = new Dictionary<char, int>();
        int currentSubstringLength = 0;
        var maxSubstringLength = 0;
        var left = 0;
        if (s.Length == 1)
            return 1;

        for (var right = 0; right < s.Length; right++)
        {
            while (dict.ContainsKey(s[right]))
            {
                dict.Remove(s[left]);
                left++;
            }

            currentSubstringLength = right - left + 1;
            if (currentSubstringLength > maxSubstringLength)
                maxSubstringLength = currentSubstringLength;

            dict.Add(s[right], right);
        }
        return Math.Max(maxSubstringLength, s.Length - left);
    }
}
