namespace Tests.Cache_System_Design.LRU_Cache_Queue;

public class LRUCache
{
    private Dictionary<int, int> _cache = new();
    private Queue<int> _queue = new();
    private int _capacity;

    public LRUCache(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentException($"{nameof(capacity)} needs to be positive.");
        _capacity = capacity;
        _queue = new Queue<int>(capacity);
    }

    public int Get(int key)
    {
        if (_cache.ContainsKey(key))
        {
            MoveToFront(key);
            return _cache[key];
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key))
        {
            _cache[key] = value;
            MoveToFront(key);
        } 
        else
        {
            _cache[key] = value;
            _queue.Enqueue(key);
            if (_cache.Count > _capacity)
            {
                var oldestKey = _queue.Dequeue();
                _cache.Remove(oldestKey);
            }
        }
    }

    private void MoveToFront(int key)
    {
        var newQueueList = _queue.Where(k => k != key);
        _queue = new Queue<int>(newQueueList);
        _queue.Enqueue(key);
    }
}
