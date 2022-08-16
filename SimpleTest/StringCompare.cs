namespace SimpleTest;

/// <summary>
/// Custom string comparison to sort strings by alphabetical order giving priority to uppercase over lowercase letters
/// </summary>
internal class StringCompare : IComparer<string>
{
    public const string Alphabet = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwYyZz";

    public int Compare(string? x, string? y)
    {
        if (string.IsNullOrEmpty(x))
        {
            return string.IsNullOrEmpty(y) ? 0 : -1;
        }

        if (string.IsNullOrEmpty(y))
        {
            return 1;
        }

        var shortestWordLen = Math.Min(x.Length, y.Length);

        for (var i = 0; i < shortestWordLen; i++)
        {
            var indexOfX = Alphabet.IndexOf(x[i]);
            var indexOfY = Alphabet.IndexOf(y[i]);

            var result = indexOfX.CompareTo(indexOfY);

            if (result != 0)
            {
                return result;
            }
        }

        return x.Length.CompareTo(y.Length);
    }
}