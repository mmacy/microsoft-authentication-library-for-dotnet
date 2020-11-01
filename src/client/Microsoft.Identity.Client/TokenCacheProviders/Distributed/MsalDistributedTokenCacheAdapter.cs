﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if DESKTOP461
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Microsoft.Identity.Client.TokenCacheProviders.Distributed
{
    /// <summary>
    /// An implementation of the token cache for both Confidential and Public clients backed by MemoryCache.
    /// </summary>
    /// <seealso>https://aka.ms/msal-net-token-cache-serialization</seealso>
    public class MsalDistributedTokenCacheAdapter : MsalAbstractTokenCacheProvider
    {
        /// <summary>
        /// .NET Core Memory cache.
        /// </summary>
        private readonly IDistributedCache _distributedCache;

        /// <summary>
        /// MSAL memory token cache options.
        /// </summary>
        private readonly MsalDistributedTokenCacheAdapterOptions _cacheOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsalDistributedTokenCacheAdapter"/> class.
        /// </summary>
        /// <param name="memoryCache">Distributed cache instance to use.</param>
        /// <param name="cacheOptions">Options for the token cache.</param>
        public MsalDistributedTokenCacheAdapter(
                                            IDistributedCache memoryCache,
                                            IOptions<MsalDistributedTokenCacheAdapterOptions> cacheOptions)
        {
            if (cacheOptions == null)
            {
                throw new ArgumentNullException(nameof(cacheOptions));
            }

            _distributedCache = memoryCache;
            _cacheOptions = cacheOptions.Value;
        }

        /// <summary>
        /// Removes a specific token cache, described by its cache key
        /// from the distributed cache.
        /// </summary>
        /// <param name="cacheKey">Key of the cache to remove.</param>
        /// <returns>A <see cref="Task"/> that completes when key removal has completed.</returns>
        protected override async Task RemoveKeyAsync(string cacheKey)
        {
            await _distributedCache.RemoveAsync(cacheKey).ConfigureAwait(false);
        }

        /// <summary>
        /// Read a specific token cache, described by its cache key, from the
        /// distributed cache.
        /// </summary>
        /// <param name="cacheKey">Key of the cache item to retrieve.</param>
        /// <returns>Read blob representing a token cache for the cache key
        /// (account or app).</returns>
        protected override async Task<byte[]> ReadCacheBytesAsync(string cacheKey)
        {
            return await _distributedCache.GetAsync(cacheKey).ConfigureAwait(false);
        }

        /// <summary>
        /// Writes a token cache blob to the serialization cache (by key).
        /// </summary>
        /// <param name="cacheKey">Cache key.</param>
        /// <param name="bytes">blob to write.</param>
        /// <returns>A <see cref="Task"/> that completes when a write operation has completed.</returns>
        protected override async Task WriteCacheBytesAsync(string cacheKey, byte[] bytes)
        {
            await _distributedCache.SetAsync(cacheKey, bytes, _cacheOptions).ConfigureAwait(false);
        }
    }
}
#endif
