public static class Ext
{
    public static string Join<T>(this IEnumerable<T> e,string separator =",") => string.Join(separator,e);

    public static void Print(this object @object) => Console.WriteLine(@object);
}