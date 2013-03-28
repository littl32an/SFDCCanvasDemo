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
    public class CanvasEnvironmentContext
    {
        [JsonProperty("locationUrl")]
        public String locationUrl { get; set; }
        /**
         * Returns the value Theme2 if the user is using the newer user interface theme of the online application, labeled
         * \u201cSalesforce.\u201d Returns Theme1 if the user is using the older user interface theme, labeled
         * \u201cSalesforce Classic.\u201d
         */
        [JsonProperty("uiTheme")]
        public String uiTheme { get; set; }
        [JsonProperty("dimensions")]
        public Dimensions dimensions { get; set; }
        [JsonProperty("version")]
        public SystemVersion version { get; set; }

        public override String ToString()
        {
            return locationUrl + ", " +
                   uiTheme + "," +
                   dimensions.ToString() + "," +
                   version.ToString();
        }

        public class Dimensions{
            /**
             * The width of the iframe
             */
            [JsonProperty("width")]            
            public String width  { get; set; }       
            /**
             * The height of the iframe.
             */
            [JsonProperty("height")]
            public String height { get; set; }

            public override String ToString()
            {
                return String.Format("(w:{0},h:{1}",width,height);
            }
        }

        public class SystemVersion{
            [JsonProperty("api")]
            public String api { get; set; }
            [JsonProperty("season")]
            public String season { get; set; }

            public override String ToString()
            {
                return String.Format("{0} - {1}", api, season);
            }
        }
    }
}
