namespace Tests.Cache_System_Design.LFU_Cache;

public class LFUCache
{
    private HashedLinkedList _cache;
    private int _capacity;

    public LFUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new(capacity);
    }

    public int Get(int key)
    {
        return _cache.Get(key);
    }

    public void Put(int key, int value)
    {
        _cache.Put(key, value);
    }
}

public class HashedLinkedList
{
    private Dictionary<int, LinkedListNode<LFUNode>> _cache = new();
    private LinkedList<LFUNode> _list = new();
    private int _capacity;

    public HashedLinkedList(int capacity)
    {
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (_cache.ContainsKey(key))
        {
            Update(key);
            return _cache[key].Value.Value;
        }
        else
            return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.ContainsKey(key))
        {
            Update(key);
        }
        else
        {
            Insert(key, value);
            // check capacity
            if (_list.Count > _capacity)
            {
                _cache.Remove(_list.Last.Value.Key);
                _list.RemoveLast();
            }
        }
    }

    private void Update(int key)
    {
        var node = _cache[key];
        var value = node.Value;
        value.Count++;
        value.Timestamp = DateTime.Now.Ticks;

        // check if this node should be promoted
        if (node.Next != null 
            && (node.Next.Value.Count > node.Value.Count 
                || (node.Next.Value.Count == node.Value.Count && node.Next.Value.Timestamp > node.Value.Timestamp)))
        {
            // swap values
            _cache[node.Value.Key] = node.Next;
            _cache[node.Next.Value.Key] = node;
            Swap(node, node.Next);
        } else
            _cache[key] = node;
    }

    private void Insert(int key, int value)
    {
        var node = new LFUNode(key, value, 1, DateTime.Now.Ticks);
        _list.AddFirst(node);
        _cache[key] = _list.First;
    }

    public static void Swap(LinkedListNode<LFUNode> first, LinkedListNode<LFUNode> second)
    {
        var tmp = first.Value;
        first.Value = second.Value;
        second.Value = tmp;
    }
}

public struct LFUNode
{
    public int Key, Value, Count;
    public long Timestamp;

    public LFUNode(int key, int value, int count, long timestamp)
    {
        Key = key;
        Value = value;
        Count = count;
        Timestamp = timestamp;
    }
}
