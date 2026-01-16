using System.Runtime.InteropServices;

var argumentA = int.Parse(Console.ReadLine());
var argumentB = int.Parse(Console.ReadLine());

var result = Add(argumentA, argumentB);
Console.WriteLine(result);

[DllImport("SimpleMath.dll", CharSet = CharSet.Unicode)]
static extern int Add(int a, int b);