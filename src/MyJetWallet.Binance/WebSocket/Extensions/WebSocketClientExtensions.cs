﻿using System;
using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace MyJetWallet.Binance.WebSocket
{
    public static class WebSocketClientExtensions
    {
        /// <summary>
        /// Wait until web socket is open (connected).
        /// </summary>
        /// <param name="webSocket"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task WaitUntilOpenAsync(this IWebSocketClient webSocket, CancellationToken token = default)
        {
            Throw.IfNull(webSocket, nameof(webSocket));

            var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            // ReSharper disable once ConvertToLocalFunction
            EventHandler<EventArgs> handler = (s, e) =>
            {
                tcs.TrySetResult(true);
            };

            webSocket.Open += handler;

            try
            {
                if (token.IsCancellationRequested || webSocket.IsOpen)
                    return;

                if (token.CanBeCanceled)
                {
                    using (token.Register(() => tcs.TrySetCanceled()))
                    {
                        await tcs.Task.ConfigureAwait(false);
                    }
                }
                else
                {
                    await tcs.Task.ConfigureAwait(false);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + '\n' + e.StackTrace + '\n');
                throw;
            }
            finally { webSocket.Open -= handler; }
        }
    }
}
