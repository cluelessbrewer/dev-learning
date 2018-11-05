using System;
using System.Collections.Generic;

/* Outputs */
// 3 7
// 1 9
// 5 5
// 5 5
// 7 3
// 5 5
// 5 5
// 9 1	
	
public class Program
{
	public static void Main()
	{
		foreach (Tuple<int, int> indices in FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10))
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2);
        }
	}
	
	 public static IEnumerable<Tuple<int, int>> FindTwoSum(IList<int> list, int sum)
    {
        foreach (var val in list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((val + list[i]) == 10)
                {            
                    yield return (new Tuple<int, int>(val, list[i]));
                }
            }
        }
       
        yield break;
    }
}