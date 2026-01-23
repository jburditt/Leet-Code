namespace DataStreamProcessing.Q1;

// 28 ms beats 30.18%
// 70.74 MB beats 8.66%
public class KthLargest
{
    private SortedList<int> _scores;

    public KthLargest(int k, int[] nums)
    {
        _scores = new SortedList<int>(k, nums);
    }

    public int Add(int val)
    {
        if (!_scores.Full || val > _scores.Lowest)
            _scores.Add(val);
        return _scores.Lowest;
    }

    public class SortedList<T>
    {
        private int _capacity;
        private List<int> _list;

        public SortedList(int capacity, int[] nums)
        {
            _capacity = capacity;
            var temp = new List<int>(nums);
            temp.Sort();
            _list = temp.TakeLast(capacity).ToList();
        }

        public int Lowest => _list.First();
        public bool Full => _list?.Count() >= _capacity;

        public int Add(int val)
        {
            // find the pivot at index p
            int pivot = BinarySearchHigherValue(val);
            _list.Insert(pivot + 1, val);
            // remove the first element if over capacity
            if (_list.Count() > _capacity)
                _list.RemoveAt(0);
            return Lowest;
        }

        private int BinarySearchHigherValue(int val)
        {
            int low = 0;
            int high = _list.Count - 1;
            //if (high == 0)
            //    if (_list[0] >= val)
            //        return -1;
            //    else
            //        return 0;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (_list[mid] == val)
                {
                    return mid;
                }
                if (_list[mid] > val)
                {
                    high = mid - 1;
                }
                if (_list[mid] < val)
                {
                    low = mid + 1;
                }
            }
            return high;
        }
    }
}
