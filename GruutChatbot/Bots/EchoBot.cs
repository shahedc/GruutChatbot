// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.9.2

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;

namespace GruutChatbot.Bots
{
    public class EchoBot : ActivityHandler
    {
        private readonly string _endpoint;
        private readonly string _keyCredential;
        
        public EchoBot(IConfiguration configuration) =>
            (_endpoint, _keyCredential) = (_configuration["CognitiveServicesEndpoint"], _configuration["AzureKeyCredential"]);
        
        protected override async Task OnMessageActivityAsync(
            ITurnContext<IMessageActivity> turnContext, 
            CancellationToken cancellationToken)
        {
            var client = new TextAnalyticsClient(
                new Uri(_endpoint),
                new AzureKeyCredential(_keyCredential));

            var result = await client.AnaylzeSentimentAsync(
                turnContext.Activity.Text,
                cancellationToken: cancellationToken);

            var replyText = GetReplyText(result.Value.Sentiment);
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
            
            static string GetReplyText(TextSentiment sentiment) => sentiment switch
            {
                TextSentiment.Positive => "I am Gruut.",
                TextSentiment.Negative => "I AM GRUUUUUTTT!!",
                TextSentiment.Neutral => "I am Gruut?",
                _ => "I. AM. GRUUUUUT"
            };
        }

        protected override async Task OnMembersAddedAsync(
            IList<ChannelAccount> membersAdded,
            ITurnContext<IConversationUpdateActivity> turnContext,
            CancellationToken cancellationToken)
        {
            // welcome new users
        }
    }  
}
