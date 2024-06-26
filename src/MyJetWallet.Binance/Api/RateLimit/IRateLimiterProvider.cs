﻿// ReSharper disable once CheckNamespace
namespace MyJetWallet.Binance.Api
{
    public interface IRateLimiterProvider
    {
        /// <summary>
        /// Create a new <see cref="IRateLimiter"/>.
        /// </summary>
        /// <returns></returns>
        IRateLimiter CreateRateLimiter();
    }
}
