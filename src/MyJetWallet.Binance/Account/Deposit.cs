﻿using System;

// ReSharper disable once CheckNamespace
namespace MyJetWallet.Binance
{
    public sealed class Deposit : IChronological
    {
        #region Public Properties

        /// <summary>
        /// Get the asset.
        /// </summary>
        public string Asset { get; }

        /// <summary>
        /// Get the amount.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Get the insert time.
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// Get the address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Get the address tag.
        /// </summary>
        public string AddressTag { get; }

        /// <summary>
        /// Get the transaction ID.
        /// </summary>
        public string TxId { get; }

        /// <summary>
        /// Get the status.
        /// </summary>
        public DepositStatus Status { get; }
        
        /// <summary>
        /// Get the deposit ID.
        /// </summary>
        public ulong? Id { get; }
        
        /// <summary>
        /// Get the network.
        /// </summary>
        public string Network { get; }

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="asset">The asset/coin.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="time">The time.</param>
        /// <param name="status">The status.</param>
        /// <param name="address">The address.</param>
        /// <param name="addressTag">The address tag.</param>
        /// <param name="id">The deposit id.</param>
        /// <param name="network">The coin network.</param>
        /// <param name="txId">The transaction ID.</param>
        public Deposit(
            string asset,
            decimal amount,
            DateTime time,
            DepositStatus status,
            string address,
            string addressTag = null,
            string txId = null,
            ulong? id = null,
            string network = null)
        {
            Throw.IfNullOrWhiteSpace(asset, nameof(asset));
            Throw.IfNullOrWhiteSpace(address, nameof(address));

            if (amount <= 0)
                throw new ArgumentException($"{nameof(Deposit)}: amount must be greater than 0.", nameof(amount));

            Asset = asset.FormatSymbol();
            Amount = amount;
            Time = time;
            Status = status;
            Address = address;
            AddressTag = addressTag;
            TxId = txId;
            Id = id;
            Network = network;
        }

        #endregion Constructors
    }
}
