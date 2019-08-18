//  -----------------------------------------------------------------------------
//   Copyright  (c) Balsamic Solutions, LLC. All rights reserved.
//   THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF  ANY KIND, EITHER
//   EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR
//  -----------------------------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BalsamicSolutions.CodeCommit2Slack
{
    /// <summary>
    /// We only set the minimal properties, you can set others if you want
    /// to embelish the message https://api.slack.com/methods/chat.postMessage
    /// </summary>
    public class SlackMessage
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("mrkdwn")]
        public bool MarkDown { get; set; }
    }
}