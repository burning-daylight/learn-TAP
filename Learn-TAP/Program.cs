// See https://aka.ms/new-console-template for more information
using Learn_TAP;

Console.WriteLine("Hello, World!");

//await TestTaskController.TestWhenAll();
//await TestTaskController.TestWhenAny();
await TestTaskController.TestWhenAny2();

/*
CancellationTokenSource cts = new CancellationTokenSource();

Console.WriteLine("Cancellation requested after 1 sec");
Console.WriteLine($"Metho1 is called in {Task.CurrentId}");

Progress<bool> progress = new Progress<bool>();
cts.CancelAfter(TimeSpan.FromSeconds(1));
await Method1(cts.Token, progress);

Console.WriteLine("Done");

static Task Method1(CancellationToken ct, IProgress<bool> progress)
{
    int i = 0;
    return Task.Run(() =>
    {
        try
        {
            Thread.Sleep(1000);
            for (i = 0; i < 10; i++)
            {
                progress.Report(false);
                ct.ThrowIfCancellationRequested();
                Thread.Sleep(100);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception occured in {Task.CurrentId}");
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            Console.WriteLine("Finally block");
            Console.WriteLine(i.ToString());
            progress.Report(true);
        }
    }, ct);
}*/