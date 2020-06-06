using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingChannel100
{
    class MyChannel<T>
    {
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);

        public void Write(T item)
        {
            _queue.Enqueue(item);
            _semaphore.Release();
        }

        public async Task<T> ReadAsync()
        {
            await _semaphore.WaitAsync();
            _queue.TryDequeue(out T item);
            return item;
        }
    }
}
