namespace SecondExample.Model;

public class MyMath
{
    public static void GetSum(int argument, Action<decimal> callbackResult, CancellationToken cancellationToken)
    {
        decimal sum = 0;

        for (int i = 1; i <= argument; i++)
        {
            sum += i;
            cancellationToken.ThrowIfCancellationRequested();
        }

        callbackResult.Invoke(sum);
    }
}