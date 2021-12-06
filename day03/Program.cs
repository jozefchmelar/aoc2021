 var bitCount = new int["101011010101".Length];
 var inputCount = 1000;
var newState = File
    .ReadAllLines("input.txt")
    .Select(x => x.Select(binary => Int32.Parse($"{binary}")).ToArray())
    .Aggregate(bitCount, (previousBitCount, line) =>
        previousBitCount.Select( (prevVal, index) => prevVal + line[index]).ToArray()
    )
    .Select(x=> ((inputCount-x) >= inputCount / 2) ? "1" :"0"); // if the sum is bigger than 500, it means that the 1 is dominant :)

var gammaBinaryString = string.Join("",newState);
var epislonBinaryString = string.Join("",
                    gammaBinaryString.Replace("1","x").Replace("0","1").Replace("x","0")
                          );
var gamma = Convert.ToInt32(gammaBinaryString, 2);
var epsilon = Convert.ToInt32(epislonBinaryString, 2);
Console.WriteLine(gamma*epsilon);

// too lazy to read pt2
