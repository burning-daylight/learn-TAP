using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn_TAP
{
    public class DownloaderString : IDownloader<Data>
    {
        public async Task<Data> Download(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                ct.ThrowIfCancellationRequested();
                Thread.Sleep(100 * id * 5);
                var data = new Data { ID = id, Descr = $"Description: {id}" };
                Console.WriteLine($"{data.ID} , {data.Descr}");
                //throw new Exception();
                return data;
            });
        }
    }
}
