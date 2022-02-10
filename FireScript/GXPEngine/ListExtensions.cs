using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ListExtensions
{
    private static Random rnd = new Random();

    public static List<T> GetRandomItems<T>(this IList<T> list, int maxCount)
    {
        List<T> resultList = new List<T>();
        list.Shuffle();

        for (int i = 0; i < maxCount && i < list.Count; i++)
            resultList.Add(list[i]);

        return resultList;
    }

    private static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
