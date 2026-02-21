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
        var isWordFound = false;
        // brute force
        for (var i=0; i < _words.Length; i++)
        {
            if (_words[i][_wordCharTracker[i]] == letter)
            {
                if (_wordCharTracker[i] == _words[i].Length - 1)
                {
                    ResetWordTracker(i);
                    isWordFound = true;
                }
                else
                    _wordCharTracker[i]++;
            }
            else
            {
                ResetWordTracker(i);
            }
        }
        return isWordFound;

        void ResetWordTracker(int i)
        {
            if (_words[i][0] == letter)
                if (_words[i].Length == 1)
                {
                    isWordFound = true;
                    _wordCharTracker[i] = 0;
                } else
                    _wordCharTracker[i] = 1;
            else
                _wordCharTracker[i] = 0;
        }
    }
}
