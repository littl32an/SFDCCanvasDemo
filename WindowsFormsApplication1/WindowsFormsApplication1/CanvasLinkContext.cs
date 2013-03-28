/**
 * Copyright (c) 2011, salesforce.com, inc.
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided
 * that the following conditions are met:
 *
 *    Redistributions of source code must retain the above copyright notice, this list of conditions and the
 *    following disclaimer.
 *
 *    Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
 *    the following disclaimer in the documentation and/or other materials provided with the distribution.
 *
 *    Neither the name of salesforce.com, inc. nor the names of its contributors may be used to endorse or
 *    promote products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
 * TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace CanvasClasses
{
    /**
 * Describes all contextual information around external references, or links to external resources.
 */
//@JsonIgnoreProperties(ignoreUnknown=true)
    public class CanvasLinkContext
    {
        //Provide the url for enterprise-wide external clients.
        [JsonProperty("enterpriseUrl")]
        public String enterpriseUrl { get; set; }
        //Provide the base url for the metadata api to access information about custom objects, apex classes, etc.
        [JsonProperty("metadataUrl")]
        public String metadataUrl { get; set; }
        //Access to the partner api for developing client applications for multiple organizations.
        [JsonProperty("partnerUrl")]
        public String partnerUrl { get; set; }
        //Access to the base url for RESTful services.
        [JsonProperty("restUrl")]
        public String restUrl { get; set; }
        //Access to custom sobject definitions.
        [JsonProperty("sobjectUrl")]
        public String sobjectUrl { get; set; }
        //Access to search api.
        [JsonProperty("searchUrl")]
        public String searchUrl { get; set; }
        //Access to the SOQL query api.
        [JsonProperty("queryUrl")]
        public String queryUrl { get; set; }
        // Access to the recent items feed.
        [JsonProperty("recentItemsUrl")]
        public String recentItemsUrl { get; set; }
        // Retrieve more information about the current user.
        [JsonProperty("userProfileUrl")]
        public String userProfileUrl { get; set; }
        //Access to Chatter Feeds. Note: Requires user profile permissions, otherwise this will be null.
        [JsonProperty("chatterFeedsUrl")]
        public String chatterFeedsUrl { get; set; }
        //Access to Chatter Groups. Note: Requires user profile permissions, otherwise this will be null.
        [JsonProperty("chatterGroupsUrl")]
        public String chatterGroupsUrl { get; set; }
        //Access to Chatter Users. Note: Requires user profile permissions, otherwise this will be null.
        [JsonProperty("chatterUsersUrl")]
        public String chatterUsersUrl { get; set; }
        //Access to individual Chatter Feed items. Note: Requires user profile permissions, otherwise this will be null.
        [JsonProperty("chatterFeedItemsUrl")]
        public String chatterFeedItemsUrl { get; set; }

        public override String ToString()
        {
            return enterpriseUrl + ", " +
                     metadataUrl + ", " +
                     partnerUrl + ", " +
                     restUrl + ", " +
                     sobjectUrl + ", " +
                     searchUrl + ", " +
                     queryUrl + ", " +
                     recentItemsUrl + ", " +
                     userProfileUrl + ", " +
                     chatterFeedsUrl + ", " +
                     chatterGroupsUrl + ", " +
                     chatterUsersUrl + ", " +
                     chatterFeedItemsUrl;
        }
    }
}
