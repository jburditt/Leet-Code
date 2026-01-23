namespace DataStreamProcessing.Q1;

// Better solution but still too slow
// Next step: Remove Sort method call
public class KthLargest_ortedList
{
    private SortedList<int> _scores;

    public KthLargest_ortedList(int k, int[] nums)
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
        private IEnumerable<int> _list;

        public SortedList(int capacity, int[] nums)
        {
            _capacity = capacity;
            var temp = new List<int>(nums);
            temp.Sort();
            _list = temp.TakeLast(capacity);
        }

        public int Lowest => _list.First();
        public bool Full => _list?.Count() >= _capacity;

        public int Add(int val)
        {
            var temp = new List<int>(_list);
            temp.Add(val);
            temp.Sort();
            if (_list.Count() >= _capacity)
                temp.RemoveAt(0);
            _list = temp.ToArray();
            return Lowest;
        }
    }
}
