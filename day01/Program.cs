using static System.Console;

var values = File.ReadAllLines("input.txt").Select(x =>Int32.Parse(x));

var calc = values
    .Zip(values.Skip(1), (first,second) => first < second ? 1:0)
    .Sum();

WriteLine(calc);

var sumOfWindowsOf3 = values
    .Zip(values.Skip(1).Zip(values.Skip(2)))
    .Select( (a,b) => a.First + a.Second.First + a.Second.Second );
var calc2 = sumOfWindowsOf3
    .Zip(sumOfWindowsOf3.Skip(1), (first,second) => first < second ? 1:0)
    .Sum();

WriteLine(calc2);