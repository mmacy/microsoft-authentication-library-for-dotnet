// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if DESKTOP461
using Microsoft.Extensions.Caching.Distributed;

namespace Microsoft.Identity.Client.TokenCacheProviders.Distributed
{
    /// <summary>
    /// Options for the MSAL token cache serialization adapter,
    /// which delegates the serialization to the IDistributedCache implementations
    /// available with .NET Core.
    /// </summary>
    public class MsalDistributedTokenCacheAdapterOptions : DistributedCacheEntryOptions
    {
    }
}
#endif
