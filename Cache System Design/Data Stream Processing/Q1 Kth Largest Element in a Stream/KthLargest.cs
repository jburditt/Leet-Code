namespace DataStreamProcessing.Q1;

// This is an awful solution that I decided to finish out of hilarity and boredom
// Unsurprisingly, it performs terribly and failed the timeout limit on LeetCode
public class KthLargest
{
    private SortedSet<double> _scores;
    private int _k;
    private Random _random = new Random();
    private const int halfMax = int.MaxValue / 2;

    public KthLargest(int k, int[] nums)
    {
        List<int> temp = nums.ToList();
        List<double> nums2 = new List<double>();
        foreach (var x in nums)
        {
            if (temp.Contains(x))
            {
                double rnd = _random.Next(0, halfMax);
                double offset;
                if (x >= 0)
                    offset = x + (rnd / (double)int.MaxValue);
                else
                    offset = x - (rnd / (double)int.MaxValue);
                temp.Add(x);
                nums2.Add(offset);
            }
            else
                { temp.Add(x); nums2.Add(x); }
        }
        _scores = new SortedSet<double>(nums2);
        _k = k;
    }

    public int Add(int val)
    {
        if (_scores.Contains(val))
        {
            double rnd = _random.Next(0, halfMax);
            double offset;
            if (val >= 0)
                offset = val + (rnd / (double)int.MaxValue);
            else
                offset = val - (rnd / (double)int.MaxValue);
            _scores.Add(offset);
        } else
            _scores.Add(val);
        return (int)_scores.TakeLast(_k).First();
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */