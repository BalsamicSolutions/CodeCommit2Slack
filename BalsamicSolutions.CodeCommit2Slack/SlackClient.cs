//  -----------------------------------------------------------------------------
//   Copyright  (c) Balsamic Solutions, LLC. All rights reserved.
//   THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF  ANY KIND, EITHER
//   EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR
//  -----------------------------------------------------------------------------
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace BalsamicSolutions.CodeCommit2Slack
{
    /// <summary>
    /// A simple C# class to post messages to a Slack channe
    /// https://api.slack.com/methods/chat.postMessage
    /// </summary>
    public class SlackClient
    {
        private readonly Uri _ChannelAndTokenUrl;

        /// <summary>
        /// create a client to a channel with embeded token and channel information
        /// </summary>
        /// <param name="channelAndTokenUrl"></param>
        public SlackClient(string channelAndTokenUrl)
        {
            _ChannelAndTokenUrl = new Uri(channelAndTokenUrl);
        }

        /// <summary>
        /// create a client to a channel with embeded token and channel information
        /// </summary>
        /// <param name="channelAndTokenUri"></param>
        public SlackClient(Uri channelAndTokenUri)
        {
            _ChannelAndTokenUrl = channelAndTokenUri;
        }

        /// <summary>
        ///Post a message to the predefined Url
        /// </summary>
        /// <param name="messageText"></param>
        public void PostMessage(string messageText)
        {
            SlackMessage slackMessage = new SlackMessage()
            {
                //Max message length is 4000 characters
                Text = messageText.TrimTo(4000, false),
                MarkDown = true
            };
            PostMessage(slackMessage);
        }

        /// <summary>
        /// post a message to a channel with embeded token and channel information
        /// </summary>
        /// <param name="slackMessage"></param>
        public void PostMessage(SlackMessage slackMessage)
        {
            string jsonPayload = JsonConvert.SerializeObject(slackMessage);
            using (WebClient webClient = new WebClient())
            {
                NameValueCollection postData = new NameValueCollection();
                postData["payload"] = jsonPayload;
                try
                {
                    byte[] messageResponse = webClient.UploadValues(_ChannelAndTokenUrl, "POST", postData);
                    string responseText = Encoding.UTF8.GetString(messageResponse);
                    //expecting OK
                    System.Diagnostics.Trace.WriteLine(responseText);
                }
                catch(Exception slackError)
                {
                    Console.WriteLine("Error posting to Slack " + slackError.Message);
                }
            }
        }
    }
}