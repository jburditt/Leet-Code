namespace Tests.Cache_System_Design.LFU_Cache;

// NOTE first/head is least frequent and last/tail is the most frequent
public class LFUCache
{
    private HashedLinkedList _list;
    private int _capacity;

    public LFUCache(int capacity)
    {
        _capacity = capacity;
        _list = new(capacity);
    }

    public int Get(int key)
    {
        return _list.Get(key);
    }

    public void Put(int key, int value)
    {
        _list.Put(key, value);
    }
}

// TODO abstract HashedLinkedList from LFUCacheList
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
            _cache[key].Value.SetValue(value);
        }
        else
        {
            // check capacity
            if (_list.Count >= _capacity)
            {
                _cache.Remove(_list.First.Value.Key);
                _list.RemoveFirst();
            }
            Insert(key, value);
        }
    }

    private void Update(int key)
    {
        var node = _cache[key];
        node.Value.Update();

        // check if this node should be promoted
        if (node.Next != null 
            && (node.Next.Value.Count < node.Value.Count 
                || (node.Next.Value.Count == node.Value.Count && node.Next.Value.Timestamp < node.Value.Timestamp)))
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
        if (_list.First?.Value.Count == 1)
        {
            _cache[key] = _list.AddAfter(_list.First, node);
        }
        else
        {
            _cache[key] = _list.AddFirst(node);
        }
    }

    public static void Swap(LinkedListNode<LFUNode> first, LinkedListNode<LFUNode> second)
    {
        var tmp = first.Value;
        first.Value = second.Value;
        second.Value = tmp;
    }
}

public class LFUNode
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

    public void Update()
    {
        Count++;
        Timestamp = DateTime.Now.Ticks;
    }

    public void SetValue(int value)
    {
        Value = value;
    }
}
