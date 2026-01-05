namespace Tests.Cache_System_Design.LRU_Cache;

public class LRUCache
{
    private int capacity;
    private Dictionary<int, LinkedListNode<LRUCacheItem>> cache = new Dictionary<int, LinkedListNode<LRUCacheItem>>();
    private LinkedList<LRUCacheItem> list = new LinkedList<LRUCacheItem>();

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
    }

    public int Get(int key)
    {
        if (cache.TryGetValue(key, out var node))
        {
            list.Remove(node);
            list.AddLast(node);
            return node.Value.value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (cache.TryGetValue(key, out var existingNode))
        {
            list.Remove(existingNode);
        }
        else if (cache.Count >= capacity)
        {
            RemoveFirst();
        }

        var cacheItem = new LRUCacheItem(key, value);
        var node = new LinkedListNode<LRUCacheItem>(cacheItem);
        list.AddLast(node);
        cache[key] = node;
    }

    private void RemoveFirst()
    {
        var node = list.First;
        list.RemoveFirst();
        cache.Remove(node.Value.key);
    }
}

public class LRUCacheItem
{
    public int key;
    public int value;

    public LRUCacheItem(int key, int value)
    {
        this.key = key;
        this.value = value;
    }
}