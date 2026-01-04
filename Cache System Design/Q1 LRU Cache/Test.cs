namespace Tests.Cache_System_Design.LRU_Cache;

[TestClass]
public class Test
{

    // Q1. LRU Cache
    [TestMethod]
    public void Test_LRU_Cache()
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(1, 1); // cache is {1=1}
        lRUCache.Put(2, 2); // cache is {1=1, 2=2}
        var result = lRUCache.Get(1);    // return 1
        Assert.AreEqual(1, result);

        lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        result = lRUCache.Get(2);    // returns -1 (not found)
        Assert.AreEqual(-1, result);

        lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        result = lRUCache.Get(1);    // return -1 (not found)
        Assert.AreEqual(-1, result);

        result = lRUCache.Get(3);    // return 3
        Assert.AreEqual(3, result);

        result = lRUCache.Get(4);    // return 4
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Test_LRU_Cache_15()
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(2, 1); // cache is {2=1}
        lRUCache.Put(1, 1); // cache is {2=1, 1=1}
        lRUCache.Put(2, 3); // LRU key was 2, updates key 2, cache is {1=1, 2=3}
        lRUCache.Put(4, 1); // LRU key was 4, evicts key 1, cache is {2=3, 4=1}
        var result = lRUCache.Get(1);    // return -1
        Assert.AreEqual(-1, result);

        result = lRUCache.Get(2);    // return 3
        Assert.AreEqual(3, result);
    }
}
