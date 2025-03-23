// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CancellationTokenSource cts = new CancellationTokenSource();

cts.CancelAfter(TimeSpan.FromSeconds(1));
Console.WriteLine("Cancellation requested after 1 sec");
Console.WriteLine("Metho1 is called");
await Method1(cts.Token);

static Task Method1(CancellationToken ct)
{
    int i = 0;
    return Task.Run(() =>
    {
        try
        {
            Thread.Sleep(1000);
            for (i = 0; i < 10; i++)
            {
                ct.ThrowIfCancellationRequested();
                Thread.Sleep(100);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            Console.WriteLine(i.ToString());
        }
    }, ct);
}