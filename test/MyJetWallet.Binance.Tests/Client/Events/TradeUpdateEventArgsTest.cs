﻿using System;
using MyJetWallet.Binance.Client;
using Xunit;

namespace MyJetWallet.Binance.Tests.Client.Events
{
    public class TradeUpdateEventArgsTest
    {
        [Fact]
        public void Throws()
        {
            var time = DateTimeOffset.FromUnixTimeMilliseconds(DateTime.UtcNow.ToTimestamp()).UtcDateTime;

            var symbol = Symbol.BTC_USDT;
            const decimal price = 4999;

            const string orderRejectedReason = OrderRejectedReason.None;
            const string newClientOrderId = "new-test-order";

            const long tradeId = 12345;
            const long orderId = 54321;
            const decimal quantity = 1;
            const decimal quoteQuantity = price * quantity;
            const decimal commission = 10;
            const string commissionAsset = "BNB";
            const bool isBuyer = true;
            const bool isMaker = true;
            const bool isBestPriceMatch = true;

            var trade = new AccountTrade(symbol, tradeId, orderId, price, quantity, quoteQuantity, commission, commissionAsset, time, isBuyer, isMaker, isBestPriceMatch);

            decimal quantityOfLastFilledTrade = 1;

            Assert.Throws<ArgumentNullException>("order", () => new AccountTradeUpdateEventArgs(time, null, orderRejectedReason, newClientOrderId, trade, quantityOfLastFilledTrade));
        }

        [Fact]
        public void Properties()
        {
            var time = DateTimeOffset.FromUnixTimeMilliseconds(DateTime.UtcNow.ToTimestamp()).UtcDateTime;

            var user = new BinanceApiUser("api-key");
            var symbol = Symbol.BTC_USDT;
            const int id = 123456;
            const string clientOrderId = "test-order";
            const decimal price = 4999;
            const decimal originalQuantity = 1;
            const decimal executedQuantity = 0.5m;
            const decimal cummulativeQuoteAssetQuantity = executedQuantity * price;
            const OrderStatus status = OrderStatus.PartiallyFilled;
            const TimeInForce timeInForce = TimeInForce.IOC;
            const OrderType orderType = OrderType.Market;
            const OrderSide orderSide = OrderSide.Sell;
            const decimal stopPrice = 5000;
            const decimal icebergQuantity = 0.1m;
            const bool isWorking = true;

            var order = new Order(user, symbol, id, clientOrderId, price, originalQuantity, executedQuantity, cummulativeQuoteAssetQuantity, status, timeInForce, orderType, orderSide, stopPrice, icebergQuantity, time, time, isWorking);

            const string orderRejectedReason = OrderRejectedReason.None;
            const string newClientOrderId = "new-test-order";

            const long tradeId = 12345;
            const long orderId = 54321;
            const decimal quantity = 1;
            const decimal quoteQuantity = price * quantity;
            const decimal commission = 10;
            const string commissionAsset = "BNB";
            const bool isBuyer = true;
            const bool isMaker = true;
            const bool isBestPriceMatch = true;

            var trade = new AccountTrade(symbol, tradeId, orderId, price, quantity, quoteQuantity, commission, commissionAsset, time, isBuyer, isMaker, isBestPriceMatch);

            const decimal quantityOfLastFilledTrade = 1;

            var args = new AccountTradeUpdateEventArgs(time, order, orderRejectedReason, newClientOrderId, trade, quantityOfLastFilledTrade);

            Assert.Equal(time, args.Time);
            Assert.Equal(order, args.Order);
            Assert.Equal(OrderExecutionType.Trade, args.OrderExecutionType);
            Assert.Equal(orderRejectedReason, args.OrderRejectedReason);
            Assert.Equal(newClientOrderId, args.NewClientOrderId);
            Assert.Equal(trade, args.Trade);
            Assert.Equal(quantityOfLastFilledTrade, args.QuantityOfLastFilledTrade);
        }
    }
}
