namespace Tests.Cache_System_Design.LFU_Cache;

// 844 ms beats 5.21%
// 181.16 MB beats 51.79%

// NOTE first is least frequent and last is the most frequent
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
    private LinkedListNode<LFUNode>? _lastInserted;

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
                var firstNode = _list.First;
                if (firstNode == _lastInserted)
                    _lastInserted = _lastInserted?.Previous;
                _cache.Remove(firstNode.Value.Key);
                _list.RemoveFirst();
            }
            Insert(key, value);
        }
    }

    private void Update(int key)
    {
        var node = _cache[key];
        if (_lastInserted == node)
            _lastInserted = _lastInserted?.Previous;
        node.Value.Update();

        // check if this node should be promoted
        if (node.Next != null 
            && (node.Next.Value.Count < node.Value.Count 
                || (node.Next.Value.Count == node.Value.Count && node.Next.Value.Timestamp < node.Value.Timestamp)))
        {
            var swapNode = node.Next;
            while (swapNode.Next != null
            && (swapNode.Next.Value.Count < node.Value.Count
                || (swapNode.Next.Value.Count == node.Value.Count && swapNode.Next.Value.Timestamp < node.Value.Timestamp)))
                swapNode = swapNode.Next;
            // swap values
            //_cache[node.Value.Key] = swapNode;
            //_cache[swapNode.Value.Key] = node;
            _cache[key] = node;
            _list.Remove(node);
            _list.AddAfter(swapNode, node);
            //Swap(node, swapNode);
        } else
            _cache[key] = node;
    }

    private void Insert(int key, int value)
    {
        var node = new LFUNode(key, value, 1, DateTime.Now.Ticks);
        if (_lastInserted != null)
        {
            _cache[key] = _list.AddAfter(_lastInserted, node);
            _lastInserted = _cache[key];
        }
        else
        {
            _cache[key] = _list.AddFirst(node);
            _lastInserted = _list.First;
        }
    }

    public void Swap(LinkedListNode<LFUNode> first, LinkedListNode<LFUNode> second)
    {
        if (_lastInserted == second)
            _lastInserted = first;

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
