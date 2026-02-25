namespace Leet_Code.Cache_System_Design.Data_Stream_Processing.Q2;

public class StreamChecker
{
    private string[] _words;
    private int[] _wordCharTrackers;
    //private Queue<char>[] _streams;
    private string[] _streams;

    public StreamChecker(string[] words)
    {
        _words = words;
        _wordCharTrackers = new int[words.Length];
        //_streams = new Queue<char>[words.Length];
        //for (var i=0; i<_words.Length; i++)
        //{
        //    _streams[i] = new Queue<char>(_words[i].Length);
        //}
        _streams = new string[words.Length];
    }

    public bool Query(char letter)
    {
        var isWordFound = false;
        // brute force
        for (var i=0; i < _words.Length; i++)
        {
            // save the stream of characters for the last X amount of characters where X word length
            //_streams[i].Enqueue(letter);
            _streams[i] += letter;
            if (_streams[i].Length > _words[i].Length)
                _streams[i] = _streams[i].Substring(1);

            // keep track of the current letter for this word
            if (_words[i][_wordCharTrackers[i]] == letter)
            {
                if (_wordCharTrackers[i] == _words[i].Length - 1)
                {
                    ResetWordTracker(i);
                    isWordFound = true;
                }
                else
                    _wordCharTrackers[i]++;
            }
            else
            {
                ResetWordTracker(i);
            }
        }
        return isWordFound;

        void ResetWordTracker(int i)
        {
            // if the first letter matches, then we can set the tracker to 1, otherwise reset to 0
            if (_words[i][0] == letter)
            {
                // check for edge case where the word is only 1 character long
                if (_words[i].Length == 1)
                {
                    isWordFound = true;
                    _wordCharTrackers[i] = 0;
                }
                else
                {
                    _wordCharTrackers[i] = 1;
                    // check previous characters to see if we should increase the tracker count

                    // word   = ababac
                    // stream = ababad
                    // track  = 0

                    // word   = ababbb
                    // stream = ababa
                    // track  = 3

                    // start at the beginning
                    // start with the second character, 'b'
                    // check all characters 'baba' prefix 'ababbb'
                    // next check letter 'a'
                    // check all characters 'aba' prefix 'ababbb'
                    // return 3, length of 'aba'

                    for (var j = 1; j < _streams[i].Length; j++)
                    {
                        var prefix = _streams[i].Substring(j);
                        if (_words[i].StartsWith(prefix))
                        {
                            _wordCharTrackers[i] = prefix.Length;
                            //_streams[i] = prefix;
                            break;
                        }
                    }

                    // start at the end
                    // start with last 'a'
                    // find the last
                }
            }
            else
            {
                _wordCharTrackers[i] = 0;
            }
            //_streams[i] = string.Empty;
        }
    }
}
