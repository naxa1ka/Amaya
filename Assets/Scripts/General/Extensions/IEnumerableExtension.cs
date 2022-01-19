using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtension
{
    public static bool IsHomogeneously<T>(this IEnumerable<T> source)
    {
        var enumerable = source.ToList();
        
        var count = enumerable.Count();
        if (count == 0 || count == 1)
            return true;

        var firstItem = enumerable.First();
        return enumerable.All(item => item.Equals(firstItem));
    }
}