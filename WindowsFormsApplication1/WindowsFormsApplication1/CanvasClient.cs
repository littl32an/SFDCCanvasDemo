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
    public class CanvasClient
    {
        //The scoped OAuth token to be used to subsequent REST calls    
        [JsonProperty("oauthToken")]
        public String OAuthToken { get; set; } 
        
        [JsonProperty("clientId")]
        public String clientId {get;set;} 

         /**
         * Unique identifier for this canvas app. This value will be different for each instance of a canvas app, even if
         * the same canvas app is placed on a page more than once.
         * @return Unique identifier for this canvas app
         */
        [JsonProperty("instanceId")]
        public String instanceId {get;set;} //

        //@returns the origin (http://somesalesforcedomain:port) of the parent to the canvas app. 
        //This is used so the in browser proxy knows where to post the request to.
        [JsonProperty("targetOrigin")]
        public String targetOrigin { get; set; }

        //The base url for all subsequent REST call, this has the correct Salesforce instance this organization is pinned to.                                         
        [JsonProperty("instanceUrl")]
        public String instanceUrl { get; set; } 

    }
}
