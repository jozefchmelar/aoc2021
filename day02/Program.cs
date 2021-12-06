
var initialState = (horizontal: 0, depth: 0);

var newState = File
    .ReadAllLines("input.txt")
    .Select(line => line.Split(' '))
    .Select(split => (command: split[0], parameter: Int32.Parse(split[1])))
    .Aggregate(initialState, (oldState, line) =>
        (line.command, line.parameter) switch
            {
                ("forward", var x) => (horizontal: oldState.horizontal + x, depth: oldState.depth),
                ("down", var x) => (horizontal: oldState.horizontal, depth: oldState.depth += x),
                ("up", var x) => (horizontal: oldState.horizontal, depth: oldState.depth -= x),
                _ => oldState
            });

Console.WriteLine(newState.horizontal * newState.depth);

//pt 2

var initialStateWithAim = (horizontal: 0, depth: 0, aim:0);
var newStateWithAim = File
    .ReadAllLines("input.txt")
    .Select(line => line.Split(' '))
    .Select(split => (command: split[0], parameter: Int32.Parse(split[1])))
    .Aggregate(initialStateWithAim, (oldState, line) =>
        (line.command, line.parameter) switch
            {
                ("forward", var x) =>   (horizontal: oldState.horizontal + x,   depth: oldState.depth + (oldState.aim * x) , aim : oldState.aim),
                ("down", var x) =>      (horizontal: oldState.horizontal,       depth: oldState.depth                      , aim : oldState.aim + x),
                ("up", var x) =>        (horizontal: oldState.horizontal,       depth: oldState.depth                      , aim : oldState.aim - x),
                _ => oldState
            });


Console.WriteLine(newStateWithAim.horizontal * newStateWithAim.depth);