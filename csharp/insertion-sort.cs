public static IEnumerable<int[]> InsertionSort(this IEnumerable<int> values)
{
    var copy = values.ToArray();
    var last = values.Last();
    var nextToLast = copy.Count() - 2;

    for (var i = nextToLast; i >= 0; i--)
    {
        if (copy[i] > last)
        {
            copy[i + 1] = copy[i];
            yield return copy;
        }
        else
        {
            copy[i + 1] = last;
            yield return copy;
            yield break;
        }                   
    }

    // This sets the last element at 0 if it didn't fit anywhere else.
    copy[0] = last;
    yield return copy;
}

public static void Main(){
    var nums = new[] { 2, 4, 6, 8, 9 };
    foreach (var step in nums.InsertionSort())
    {
        step.Print();
    }
}