namespace Tests.Cache_System_Design.LRU_Cache_LinkedList;

public class LRUQueue<T>
{
    public LinkedList<T> List { get; private set; } = new LinkedList<T>();

    public LRUQueue()
    {
        List = new LinkedList<T>();
    }

    public void Enqueue(T item)
    {
        List.AddLast(item);
    }

    public T Dequeue()
    {
        if (List.Count == 0)
            throw new InvalidOperationException("Queue is empty.");
        var firstItem = List.First.Value;
        List.RemoveFirst();
        return firstItem;
    }

    public void MoveToFront(T item)
    {
        var node = List.Find(item);
        if (node != null)
        {
            List.Remove(node);
            List.AddLast(item);
        }
    }
}

public class LRUCache
{
    private Dictionary<int, int> _cache = new();
    private LRUQueue<int> _queue = new();
    private int _capacity;

    public LRUCache(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentException($"{nameof(capacity)} needs to be positive.");
        _capacity = capacity;
        _queue = new LRUQueue<int>();
    }

    public int Get(int key)
    {
        if (_cache.ContainsKey(key))
        {
            _queue.MoveToFront(key);
            return _cache[key];
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key))
        {
            _cache[key] = value;
            _queue.MoveToFront(key);
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
}
