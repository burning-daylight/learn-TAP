using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_TAP
{
    public static class TestTaskController
    {
        public static async Task TestWhenAll()
        {
            // Prepare
            IDownloader<Data> downloader = new DownloaderString();
            CancellationTokenSource cts = new CancellationTokenSource();
            IEnumerable<Data> data = null;

            //cts.CancelAfter(1);
            List<int> ids = new List<int> { 1, 2, 3, 4, 5 };
            Task<Data>[] asyncOps = (from id in ids select downloader.Download(id, cts.Token)).ToArray();

            // Run
            Console.WriteLine("Run Test WhenAll");
            try
            {
                data = await Task.WhenAll(asyncOps);
            }
            catch (Exception ex)
            {
                foreach (Task<Data> faulted in asyncOps)
                {
                    Console.WriteLine(faulted.Exception?.Message);
                }
                Console.WriteLine("Exception occured");
            }

            // Complete
            Console.WriteLine($"Received: {data?.Count()}");
            Console.WriteLine("Completed");
        }

        public static async Task TestWhenAny()
        {
            // Prepare
            IDownloader<Data> downloader = new DownloaderString();
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<Data> data = null;

            //cts.CancelAfter(1);
            List<int> ids = new List<int> { 1, 2, 3, 4, 5 };
            List<Task<Data>> asyncOps = (from id in ids select downloader.Download(id, cts.Token)).ToList();

            // Run
            Console.WriteLine("Run Test WhenAny");
            try
            {
                data = await Task.WhenAny(asyncOps);
            }
            catch (Exception ex)
            {
                foreach (Task<Data> faulted in asyncOps)
                {
                    Console.WriteLine(faulted.Exception?.Message);
                }
                Console.WriteLine("Exception occured");
            }

            // Complete
            Console.WriteLine($"Received: {data?.Result.ID} , {data?.Result.Descr}");
            Console.WriteLine("Completed");
        }

        public static async Task TestWhenAny2()
        {
            // Prepare
            IDownloader<Data> downloader = new DownloaderString();
            CancellationTokenSource cts = new CancellationTokenSource();
            
            Task<Data> asyncOp = downloader.Download(1, cts.Token);

            // Run
            Console.WriteLine("Run Test WhenAny1");
            try
            {
                if (asyncOp == await Task.WhenAny(asyncOp, Task.Delay(500)))
                {
                    var data = await asyncOp;
                    Console.WriteLine(data.ID);
                }
                else
                    Console.WriteLine("Timed out");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured");
            }

            // Complete
            //Console.WriteLine($"Received: {data?.Result.ID} , {data?.Result.Descr}");
            Console.WriteLine("Completed");
        }
    }
}
