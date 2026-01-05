namespace Tests.Cache_System_Design.LRU_Cache;

public class LRUCache
{
    private int _capacity;
    private Dictionary<int, LinkedListNode<LRUCacheItem>> _cache = new();
    private LinkedList<LRUCacheItem> _list = new();

    public LRUCache(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException($"{nameof(capacity)} needs to be positive.");

        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            _list.Remove(node);
            _list.AddLast(node);
            return node.Value.value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var existingNode))
        {
            _list.Remove(existingNode);
        }
        else if (_cache.Count >= _capacity)
        {
            var first = _list.First;
            _list.RemoveFirst();
            _cache.Remove(first.Value.key);
        }

        var cacheItem = new LRUCacheItem(key, value);
        var node = new LinkedListNode<LRUCacheItem>(cacheItem);
        _list.AddLast(node);
        _cache[key] = node;
    }
}

public struct LRUCacheItem
{
    public int key;
    public int value;
    public LRUCacheItem(int key, int value)
    {
        this.key = key;
        this.value = value;
    }
}