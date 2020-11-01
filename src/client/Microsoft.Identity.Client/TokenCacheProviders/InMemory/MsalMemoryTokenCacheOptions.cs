﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if DESKTOP461
using System;

namespace Microsoft.Identity.Client.TokenCacheProviders.InMemory
{
    /// <summary>
    /// MSAL's in-memory token cache options.
    /// </summary>
    public class MsalMemoryTokenCacheOptions
    {
        /// <summary>Initializes a new instance of the <see cref="MsalMemoryTokenCacheOptions"/> class.
        /// By default, the sliding expiration is set for 14 days.</summary>
        public MsalMemoryTokenCacheOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(14);
        }

        /// <summary>
        /// Gets or sets the value of the duration after which the cache entry will expire unless it's used
        /// This is the duration the tokens are kept in memory cache.
        /// In production, a higher value, up-to 90 days is recommended.
        /// </summary>
        /// <value>
        /// The AbsoluteExpirationRelativeToNow value.
        /// </value>
        public TimeSpan AbsoluteExpirationRelativeToNow
        {
            get;
            set;
        }
    }
}
#endif
