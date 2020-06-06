using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ThreadingChannel100
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await Example_MyChannel();

            //await Example_ChannelUnbounded();

            await Example_ChannelBounded();

            //await Example_ChannelBoundedComplete();
        }

        static async Task Example_MyChannel()
        {
            var c = new MyChannel<int>();
            _ = Task.Run(async delegate
            {
                for (int i = 0; ; i++)
                {
                    await Task.Delay(1000);
                    c.Write(i);
                }
            });

            while (true)
            {
                Console.WriteLine(await c.ReadAsync());
            }
        }

        static async Task Example_ChannelUnbounded()
        {
            var c = Channel.CreateUnbounded<int>();
            _ = Task.Run(async delegate
            {
                for (int i = 0; ; i++)
                {
                    await Task.Delay(1000);
                    c.Writer.TryWrite(i);
                }
            });

            while (true)
            {
                Console.WriteLine(await c.Reader.ReadAsync());
                //c.Reader.TryRead(out int i);
            }
        }

        static async Task Example_ChannelBounded()
        {
            var c = Channel.CreateBounded<int>(1);
            _ = Task.Run(async delegate
            {
                for (int i = 0; ; i++)
                {
                    await Task.Delay(1000);
                    await c.Writer.WriteAsync(i);
                }
            });

            while (true)
            {
                await Task.Delay(2000);
                Console.WriteLine(await c.Reader.ReadAsync());
                //c.Reader.TryRead(out int i);
            }
        }

        static async Task Example_ChannelBoundedComplete()
        {
            var c = Channel.CreateBounded<int>(10);
            _ = Task.Run(async delegate
            {
                for (int i = 0; i < 10 ; i++)
                {
                    await Task.Delay(1000);
                    await c.Writer.WriteAsync(i);
                }

                c.Writer.Complete();
            });

            await foreach (int item in c.Reader.ReadAllAsync())
            {
                Console.WriteLine(item);
            }

            //while (await c.Reader.WaitToReadAsync())
            //{
            //    Console.WriteLine(await c.Reader.ReadAsync());
            //}

            Console.WriteLine("Done");
        }
    }
}
