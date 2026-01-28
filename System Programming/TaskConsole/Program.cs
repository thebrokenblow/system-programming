var task1 = Task.Run(() =>
{
    int sum = 0;

    for (int i = 1; i <= 1_000_000; i++)
    {
        sum += i;
    }

    return sum;
});

var task2 = Task.Run(() =>
{
    int dif = 0;

    for (int i = 1; i <= 1_000_000; i++)
    {
        dif -= i;
    }

    return dif;
});

Task.WaitAll(task1, task2);

Console.WriteLine(task1.Result);
Console.WriteLine(task2.Result);

Console.ReadLine();