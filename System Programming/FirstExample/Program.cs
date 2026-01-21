public class Program
{
    static void Main()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        ThreadPool.QueueUserWorkItem(DoWork, token);

        Thread.Sleep(1500);

        Console.WriteLine("\nЗапрашиваю отмену...");
        cts.Cancel();
        Thread.Sleep(1000); // Даем время на обработку отмены
    }

    static void DoWork(object? state)
    {
        ArgumentNullException.ThrowIfNull(state);

        if (state is not CancellationToken cancelToken)
        {
            throw new ArgumentException($"{state} is not CancellationToken");
        }

        Console.WriteLine($"ThreadPool задача 1 началась");
        
        try
        {
            for (int i = 0; i < 20; i++)
            {
                cancelToken.ThrowIfCancellationRequested();
                Console.WriteLine($"Задача 1: шаг {i}");
                Thread.Sleep(300);
            }

            Console.WriteLine($"Задача 1 завершена успешно");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"Задача 1 отменена!");
        }
    }
}