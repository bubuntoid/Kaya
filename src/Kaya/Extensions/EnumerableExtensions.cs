namespace Kaya.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> ConcatIfNotNull<T>(this IEnumerable<T> dest, IEnumerable<T> src) => 
        src == null ? dest : dest.Concat(src);
}