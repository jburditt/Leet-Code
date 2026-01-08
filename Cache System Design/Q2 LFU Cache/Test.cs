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

    /* [[10],[10,13],[3,17],[6,11],[10,5],[9,10],[13],[2,19],[2],[3],[5,25],[8],[9,22],[5,5],[1,30],[11],[9,12],[7],[5],[8],[9],[4,30],[9,3],[9],[10],[10],[6,14],[3,1],[3],[10,11],[8],[2,14],[1],[5],[4],[11,4],[12,24],[5,18],[13],[7,23],[8],[12],[3,27],[2,12],[5],[2,9],[13,4],[8,18],[1,7],[6],[9,29],[8,21],[5],[6,30],[1,12],[10],[4,15],[7,22],[11,26],[8,17],[9,29],[5],[3,4],[11,30],[12],[4,29],[3],[9],[6],[3,4],[1],[10],[3,29],[10,28],[1,20],[11,13],[3],[3,12],[3,8],[10,9],[3,26],[8],[7],[5],[13,17],[2,27],[11,15],[12],[9,19],[2,15],[3,16],[1],[12,17],[9,1],[6,19],[4],[5],[5],[8,1],[11,7],[5,2],[9,28],[1],[2,2],[7,4],[4,22],[7,24],[9,26],[13,28],[11,26]]
     */
    [TestMethod]
    public void Test_Submission_Case_capacity_10()
    {
        var lFUCache = new LFUCache(10);
        lFUCache.Put(10, 13);               // cache is {10=13,1}
        lFUCache.Put(3, 17);                // cache is {10=13,1; 3=17,1}
        lFUCache.Put(6, 11);                // cache is {10=13,1; 3=17,1; 6=11,1}
        lFUCache.Put(10, 5);                // cache is {3=17,1; 6=11,1; 10=5,2}
        lFUCache.Put(9, 10);                // cache is {3=17,1; 6=11,1; 9=10,1; 10=5,2;}

        var result = lFUCache.Get(13);      
        Assert.AreEqual(-1, result);

        lFUCache.Put(2, 19);

        result = lFUCache.Get(2);
        Assert.AreEqual(19, result);

        result = lFUCache.Get(3);
        Assert.AreEqual(17, result);

        lFUCache.Put(5, 25);

        result = lFUCache.Get(8);
        Assert.AreEqual(-1, result);

        lFUCache.Put(9, 22);

        // second line

        lFUCache.Put(5, 5);
        lFUCache.Put(1, 30);

        result = lFUCache.Get(11);
        Assert.AreEqual(-1, result);

        lFUCache.Put(9, 12);

        result = lFUCache.Get(7);
        Assert.AreEqual(-1, result);

        result = lFUCache.Get(5);
        Assert.AreEqual(5, result);

        result = lFUCache.Get(8);
        Assert.AreEqual(-1, result);

        result = lFUCache.Get(9);
        Assert.AreEqual(12, result);

        lFUCache.Put(4, 30);
        lFUCache.Put(9, 3);

        result = lFUCache.Get(9);
        Assert.AreEqual(3, result);

        result = lFUCache.Get(10);
        Assert.AreEqual(5, result);

        result = lFUCache.Get(10);
        Assert.AreEqual(5, result);

        lFUCache.Put(6, 24);

        // line 3

        lFUCache.Put(3, 1);

        result = lFUCache.Get(3);
        Assert.AreEqual(1, result);

        lFUCache.Put(10, 11);

        result = lFUCache.Get(8);
        Assert.AreEqual(-1, result);

        lFUCache.Put(2, 14);

        result = lFUCache.Get(1);
        Assert.AreEqual(30, result);

        result = lFUCache.Get(5);
        Assert.AreEqual(5, result);

        result = lFUCache.Get(4);
        Assert.AreEqual(30, result);

        lFUCache.Put(11, 4);
        lFUCache.Put(12, 24);
        lFUCache.Put(5, 18);

        result = lFUCache.Get(13);
        Assert.AreEqual(-1, result);

        lFUCache.Put(7, 23);

        // line 4

        result = lFUCache.Get(8);
        Assert.AreEqual(-1, result);

        result = lFUCache.Get(12);
        Assert.AreEqual(24, result);

        lFUCache.Put(3, 27);
        lFUCache.Put(2, 12);

        result = lFUCache.Get(5);
        Assert.AreEqual(18, result);

        lFUCache.Put(2, 9);
        lFUCache.Put(13, 4);
        lFUCache.Put(8, 18);
        lFUCache.Put(1, 7);

        result = lFUCache.Get(6);
        Assert.AreEqual(14, result);

        lFUCache.Put(9, 29);
        lFUCache.Put(8, 21);

        result = lFUCache.Get(5);
        Assert.AreEqual(18, result);

        lFUCache.Put(6, 30);
        lFUCache.Put(1, 12);

        result = lFUCache.Get(10);
        Assert.AreEqual(11, result);

        lFUCache.Put(4, 15);
        lFUCache.Put(7, 22);
        lFUCache.Put(11, 26);
        lFUCache.Put(8, 17);
        lFUCache.Put(9, 29);

        result = lFUCache.Get(5);
        Assert.AreEqual(18, result);

        lFUCache.Put(3, 4);
        lFUCache.Put(11, 30);

        result = lFUCache.Get(12);
        Assert.AreEqual(-1, result);

        // line 6

    }
}
