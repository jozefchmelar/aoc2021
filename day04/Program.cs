using System.Text.RegularExpressions;

var drawnedNumbers = File.ReadAllLines("input.txt").Take(1);
var matrixes = File
    .ReadAllLines("input.txt")
    .Skip(2)
    .Where(x=> !string.IsNullOrEmpty(x))
    .Chunk(5)
    .Take(2)
    .Select(x=> x.Select( x=> Regex.Split( x, @"\s+").Select(x=>Int32.Parse(x)).ToArray()).ToArray()  )
    .Select(x=> new Matrix(x));

Console.WriteLine(matrixes.Join("\n\n\n"));
// Regex.Split( x, @"\s+").

class Matrix
{
    int[][] matrix;
    bool[][] marks;
    public Matrix(int[][] matrix)
    {
        this.matrix=matrix;
        marks = new bool[5][5];
    }
}

public static class LinqExt
{
    public static string Join<T>(this IEnumerable<T> x, string separator =",") => string.Join(separator,x);

}