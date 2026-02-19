namespace Leet_Code.Problems._3;

public class Solution
{
    // NOTE I'll be honest here, this one required looking up the "Sliding Window" solution as a concept and then that was enough to develop the solution on my own
    // in other words, I cheated, but only a little bit
    // 5 ms beats 77.63%, 43.71 MB beats 77.89%
    public int LengthOfLongestSubstring(string s)
    {
        var charset = new HashSet<char>();
        var maxSubstringLength = 0;
        var left = 0;

        // move the right side of the window
        for (var right = 0; right < s.Length; right++)
        {
            // move the left side of the window until we reach the duplicate character
            while (charset.Contains(s[right]))
            {
                charset.Remove(s[left]);
                left++;
            }

            // save largest window length
            maxSubstringLength = Math.Max(maxSubstringLength, right - left + 1);

            charset.Add(s[right]);
        }

        return maxSubstringLength;
    }
}
