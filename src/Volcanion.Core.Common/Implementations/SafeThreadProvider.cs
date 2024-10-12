﻿using System.Collections.Concurrent;
using Volcanion.Core.Common.Abstractions;

namespace Volcanion.Core.Common.Implementations
{
    /// <summary>
    /// SafeThreadProvider
    /// </summary>
    public class SafeThreadProvider : ISafeThreadProvider
    {
        /// <summary>
        /// ListPool
        /// </summary>
        private IDictionary<int, Semaphore> ListPool { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public SafeThreadProvider()
        {
            ListPool = new ConcurrentDictionary<int, Semaphore>();
        }

        /// <summary>
        /// WaitOne
        /// </summary>
        /// <param name="id"></param>
        public void WaitOne(int id)
        {
            ListPool.TryGetValue(id, out var pool);

            if (pool == null)
            {
                pool = new Semaphore(1, 1);
                ListPool.Add(new KeyValuePair<int, Semaphore>(id, pool));
            }

            ListPool[id].WaitOne();
        }

        /// <summary>
        /// Release
        /// </summary>
        /// <param name="id"></param>
        public void Release(int id)
        {
            ListPool[id].Release();
        }
    }
}
