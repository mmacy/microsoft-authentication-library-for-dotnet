﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if DESKTOP461
using System.Threading.Tasks;

namespace Microsoft.Identity.Client.TokenCacheProviders
{
    /// <summary>
    /// MSAL token cache provider interface.
    /// </summary>
    public interface IMsalTokenCacheProvider
    {
        /// <summary>
        /// Initializes a token cache (which can be a user token cache or an app token cache).
        /// </summary>
        /// <param name="tokenCache">Token cache for which to initialize the serialization.</param>
        /// <returns>A <see cref="Task"/> that represents a completed initialization operation.</returns>
        Task InitializeAsync(ITokenCache tokenCache);

        /// <summary>
        /// Clear the user token cache.
        /// </summary>
        /// <param name="homeAccountId">HomeAccountId for a user account in the cache.</param>
        /// <returns>A <see cref="Task"/> that represents a completed clear operation.</returns>
        Task ClearAsync(string homeAccountId);
    }
}
#endif
