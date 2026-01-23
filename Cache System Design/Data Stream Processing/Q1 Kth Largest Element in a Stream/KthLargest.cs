namespace DataStreamProcessing.Q1;

// Accepted solution but low score
// TODO try using binary search to find pivot
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
            int pivot = 0;
            bool isLargerFound = false;
            for (var i = 0; i< _list.Count(); i++)
            {
                if (_list[i] >= val)
                {
                    pivot = i;
                    isLargerFound = true;
                    break;
                }
            }
            // add the new value after index p
            if (!isLargerFound)
            {
                _list.Add(val);                
            } else
            {
                _list.Insert(pivot, val);
            }
            // remove the first element if over capacity
            if (_list.Count() > _capacity)
                _list.RemoveAt(0);
            return Lowest;
        }
    }
}
