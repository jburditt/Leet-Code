namespace Leet_Code.Cache_System_Design.Data_Stream_Processing.Q2;

public class StreamChecker
{
    private string[] _words;
    private int[] _wordCharTracker;

    public StreamChecker(string[] words)
    {
        _words = words;
        _wordCharTracker = new int[words.Length];
    }

    public bool Query(char letter)
    {
        // brute force
        for (var i=0; i < _words.Length; i++)
        {
            if (_words[i][_wordCharTracker[i]] == letter)
            {
                if (_wordCharTracker[i] == _words[i].Length - 1)
                {
                    _wordCharTracker[i] = 0;
                    return true;
                }
                else
                    _wordCharTracker[i]++;
            }
            else
                _wordCharTracker[i] = 0;
        }
        return false;
    }
}
