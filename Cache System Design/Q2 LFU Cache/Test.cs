namespace Tests.Cache_System_Design.LFU_Cache;

[TestClass]
public class Test
{

    // Q1. LRU Cache
    [TestMethod]
    public void Test_Case_1()
    {
        var lFUCache = new LFUCache(2);
        lFUCache.Put(1, 1);             // cache is {1=1,1}
        lFUCache.Put(2, 2);             // cache is {2=2,1; 1=1,1}
        var result = lFUCache.Get(1);   // cache is {2=2,1; 1=1,2}
        Assert.AreEqual(1, result);

        lFUCache.Put(3, 3);             // evicts key 2, cache is {3=3,1; 1=1,2}
        result = lFUCache.Get(2);       
        Assert.AreEqual(-1, result);

        result = lFUCache.Get(3);    // cache is {1=1, 3=3}
        Assert.AreEqual(3, result);

        lFUCache.Put(4, 4); // LFU key was 1, evicts key 1, cache is {3=3, 4=4}
        result = lFUCache.Get(1);    // return -1 (not found)
        Assert.AreEqual(-1, result);

        result = lFUCache.Get(3);    // cache is {4=4, 3=3}
        Assert.AreEqual(3, result);

        result = lFUCache.Get(4);    // return 4
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Test_Case_10()
    {
        var lFUCache = new LFUCache(2);
        lFUCache.Put(3, 1);             // cache is {3=1,1}
        lFUCache.Put(2, 1);             // cache is {3=1,1; 2=1,1}
        lFUCache.Put(2, 2);             // updates 2, cache is {3=3,1; 2=2,2}
        lFUCache.Put(4, 4);             // evicts 3, cache is {4=4,1; 2=2,2}
        var result = lFUCache.Get(2);
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Test_Submission_Case_11()
    {
        var lFUCache = new LFUCache(3);
        lFUCache.Put(2, 2);             // cache is {2=2,1}
        lFUCache.Put(1, 1);             // cache is {1=1,1; 2=2,1}
        var result = lFUCache.Get(2);   // cache is {1=1,1; 2=2,2}
        Assert.AreEqual(2, result);

        result = lFUCache.Get(1);
        Assert.AreEqual(1, result);     // cache is {2=2,2; 1=1,2}

        lFUCache.Put(3, 3);             // cache is {3=3,1; 2=2,2; 1=1,2}
        lFUCache.Put(4, 4);             // evicts key 3, cache is {4=4,1; 2=2,2; 1=1,2}
        result = lFUCache.Get(3);
        Assert.AreEqual(-1, result);

        result = lFUCache.Get(2);
        Assert.AreEqual(2, result);

        result = lFUCache.Get(1);
        Assert.AreEqual(1, result);

        result = lFUCache.Get(4);
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Test_Submission_Case_18()
    {
        var lFUCache = new LFUCache(3);
        lFUCache.Put(1, 1);             // cache is {1=1,1}
        lFUCache.Put(2, 2);             // cache is {1=1,1; 2=2,1}
        lFUCache.Put(3, 3);             // cache is {1=1,1; 2=2,1; 3=3,1}
        lFUCache.Put(4, 4);             // cache is {2=2,1; 3=3,1; 4=4,1}

        var result = lFUCache.Get(4);   // cache is {2=2,1; 3=3,1; 4=4,2}
        Assert.AreEqual(4, result);

        result = lFUCache.Get(3);
        Assert.AreEqual(3, result);     // cache is {2=2,1; 4=4,2; 3=3,2}

        result = lFUCache.Get(2);
        Assert.AreEqual(2, result);     // cache is {4=4,2; 3=3,2; 2=2,2}

        result = lFUCache.Get(1);
        Assert.AreEqual(-1, result);

        lFUCache.Put(5, 5);             // cache is {5=5,1; 3=3,2; 2=2,2}

        result = lFUCache.Get(1);
        Assert.AreEqual(-1, result);

        result = lFUCache.Get(2);
        Assert.AreEqual(2, result);     // cache is {5=5,1; 3=3,2; 2=2,3}

        result = lFUCache.Get(3);
        Assert.AreEqual(3, result);     // cache is {5=5,1; 2=2,3; 3=3,3}

        result = lFUCache.Get(4);
        Assert.AreEqual(-1, result);

        result = lFUCache.Get(5);
        Assert.AreEqual(5, result);     // cache is {5=5,2; 2=2,3; 3=3,3}
    }
}
