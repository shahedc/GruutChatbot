// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.9.2

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace GruutChatbot.Bots
{
    public class EchoBot : ActivityHandler
    {
        static readonly Random Rand = new Random((int)DateTime.UtcNow.Ticks);

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var random = Rand.Next(0, 10);
            static string GetReplyText(int random) => random switch
            {
                0 => "I am Gruut?",
                _ when (1..8).IsInRange(random) => "I am Gruut.",
                _ => "I AM GRUUUUUTTT!!"
            };

            var replyText = GetReplyText(random);
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            // welcome new users
        }
    }
    
    public static class RangeExtensions
    {
        public static bool IsInRange(this Range range, int value) =>
            value >= range.Start.Value && value <= range.End.Value;
    }
}
