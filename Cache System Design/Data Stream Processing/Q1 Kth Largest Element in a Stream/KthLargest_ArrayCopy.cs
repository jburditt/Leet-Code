namespace DataStreamProcessing.Q1;

// 33 ms beats 18.11%
// 70.67 MB beats 7.61%
public class KthLargest_ArrayCopy
{
    private SortedList<int> _scores;

    public KthLargest_ArrayCopy(int k, int[] nums)
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
        private int[] _list;

        public SortedList(int capacity, int[] nums)
        {
            _capacity = capacity;
            var temp = new List<int>(nums);
            var length = Math.Min(temp.Count, capacity);
            _list = new int[length];
            temp.Sort();
            Array.Copy(temp.TakeLast(capacity).ToArray(), _list, length);
        }

        public int Lowest => _list.First();
        public bool Full => _list?.Count() >= _capacity;

        public int Add(int val)
        {
            // find the pivot at index p
            int pivot = BinarySearchHigherValue(val);
            // remove the first element if over capacity
            if (_list.Count() == _capacity && pivot > 0)
            {
                Array.Copy(_list, 1, _list, 0, pivot);
                _list[pivot] = val;
            }
            else if (_list.Length < _capacity)
            {
                var temp = _list;
                _list = new int[_list.Length + 1];
                if (_list.Length == 1)
                {
                    _list[0] = val;
                }
                else
                {
                    Array.Copy(temp, _list, _list.Length - 1);
                    // shift pivot item over
                    _list[pivot + 2] = _list[pivot + 1];
                    // add new item
                    _list[pivot + 1] = val;
                }
                return Lowest;
            }
            else
            {
                if (pivot < 0)
                    pivot = 0;
                _list[pivot] = val;
            }
            return Lowest;
        }

        private int BinarySearchHigherValue(int val)
        {
            int low = 0;
            int high = _list.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (_list[mid] == val)
                    return mid;

                if (_list[mid] > val)
                    high = mid - 1;

                if (_list[mid] < val)
                    low = mid + 1;

            }
            return high;
        }
    }
}
