﻿using System;
using MyJetWallet.Binance.Client;
using Xunit;

namespace MyJetWallet.Binance.Tests.Client.Events
{
    public class CandlestickEventArgsTest
    {
        [Fact]
        public void Throws()
        {
            var time = DateTimeOffset.FromUnixTimeMilliseconds(DateTime.UtcNow.ToTimestamp()).UtcDateTime;
            const long firstTradeId = 1234567890;
            const long lastTradeId = 1234567899;
            const bool isFinal = true;

            var symbol = Symbol.BTC_USDT;
            const CandlestickInterval interval = CandlestickInterval.Hour;
            var openTime = DateTimeOffset.FromUnixTimeMilliseconds(DateTime.UtcNow.ToTimestamp()).UtcDateTime;
            const decimal open = 4950;
            const decimal high = 5100;
            const decimal low = 4900;
            const decimal close = 5050;
            const decimal volume = 1000;
            var closeTime = openTime.AddHours(1);
            const long quoteAssetVolume = 5000000;
            const int numberOfTrades = 555555;
            const decimal takerBuyBaseAssetVolume = 4444;
            const decimal takerBuyQuoteAssetVolume = 333;

            var candlestick = new Candlestick(symbol, interval, openTime, open, high, low, close, volume, closeTime, quoteAssetVolume, numberOfTrades, takerBuyBaseAssetVolume, takerBuyQuoteAssetVolume);

            Assert.Throws<ArgumentNullException>("candlestick", () => new CandlestickEventArgs(time, null, firstTradeId, lastTradeId, isFinal));
            Assert.Throws<ArgumentException>("firstTradeId", () => new CandlestickEventArgs(time, candlestick, -2, lastTradeId, isFinal));
            Assert.Throws<ArgumentException>("lastTradeId", () => new CandlestickEventArgs(time, candlestick, firstTradeId, -2, isFinal));
            Assert.Throws<ArgumentException>("lastTradeId", () => new CandlestickEventArgs(time, candlestick, firstTradeId, firstTradeId - 1, isFinal));
        }

        [Fact]
        public void Properties()
        {
            var time = DateTimeOffset.FromUnixTimeMilliseconds(DateTime.UtcNow.ToTimestamp()).UtcDateTime;
            const long firstTradeId = 1234567890;
            const long lastTradeId = 1234567899;
            const bool isFinal = true;

            var symbol = Symbol.BTC_USDT;
            const CandlestickInterval interval = CandlestickInterval.Hour;
            var openTime = DateTimeOffset.FromUnixTimeMilliseconds(DateTime.UtcNow.ToTimestamp()).UtcDateTime;
            const decimal open = 4950;
            const decimal high = 5100;
            const decimal low = 4900;
            const decimal close = 5050;
            const decimal volume = 1000;
            var closeTime = openTime.AddHours(1);
            const long quoteAssetVolume = 5000000;
            const int numberOfTrades = 555555;
            const decimal takerBuyBaseAssetVolume = 4444;
            const decimal takerBuyQuoteAssetVolume = 333;

            var candlestick = new Candlestick(symbol, interval, openTime, open, high, low, close, volume, closeTime, quoteAssetVolume, numberOfTrades, takerBuyBaseAssetVolume, takerBuyQuoteAssetVolume);

            var args = new CandlestickEventArgs(time, candlestick, firstTradeId, lastTradeId, isFinal);

            Assert.Equal(time, args.Time);
            Assert.Equal(candlestick, args.Candlestick);
            Assert.Equal(firstTradeId, args.FirstTradeId);
            Assert.Equal(lastTradeId, args.LastTradeId);
            Assert.Equal(isFinal, args.IsFinal);
        }
    }
}
