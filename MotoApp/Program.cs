using MotoApp;

var stack = new Stack<double>();
var stackString = new Stack<String>();
stack.Push(4.5);
stack.Push(43);
stack.Push(333.6);

stackString.Push("Company");
stackString.Push("Company");
stackString.Push("Company");

double sum = 0.0;

while(stack.Count > 0)
{
    double item = stack.Pop();
    Console.WriteLine($"item: {item}");
    sum += item;
}

Console.WriteLine(sum);