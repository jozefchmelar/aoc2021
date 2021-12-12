var coord = File
    .ReadAllLines("input_test.txt")
    .Select(x=> x.Split(" -> "))
    .Select(x=>  (x1: x[0].Split(",")[0], y1: x[0].Split(",")[1], x2: x[1].Split(",")[0], y2: x[1].Split(",")[1] ))
    .Where(x=> x.x1 == x.x2 || x.y1==x.y2)
    .Select(o=> (x1 : Int32.Parse(o.x1), y1:  Int32.Parse(o.y1), x2: Int32.Parse(o.x2), y2: Int32.Parse(o.y2) ));

var horizontal = coord
    .Where(x => x.y1 == x.y2)
    .Select(o => (o.x2 < o.x1) ? (y: o.y1, x1 :o.x2, x2: o.x1) : (y: o.y1, x1: o.x1, x2: o.x2));

var vertical = coord
   .Where(x => x.x1 == x.x2)
   .Select(o => (o.y2 < o.y1) ? (x: o.x1, y1: o.y2, y2: o.y1) : (x: o.x1, y1: o.y1, y2: o.y2));

var size = 10;
int[,] map = new int[size,size];
foreach(var line in horizontal)
{
    for(var i=line.x1; i<=line.x2;i++)
    {
        map[line.y,i]++;
    }
}

foreach(var line in vertical)
{
    for(var i=line.y1; i<=line.y2;i++)
    {
        map[i,line.x]++;
    }
}
//print matrix
for(var i =0;i<size;i++)
{
    for(var j =0;j<size;j++)
    {
        Console.Write(map[i,j]);
    }
    Console.WriteLine();
}
//
var overlap=0;

for(var i =0;i<size;i++)
{
    for(var j =0;j<size;j++)
    {
        if(map[i,j]>=2) overlap++;
    }
}
overlap.Print();


// pt2

//aaa no.