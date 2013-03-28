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
    * Describes contextual information about the current user.
    */
    public class CanvasUserContext{
        //The Salesforce user identifier.
        [JsonProperty("userId")]
        public String userId { get; set; }
        //The Salesforce username.
        [JsonProperty("userName")]
        public String userName { get; set; }
        // User's first name.
        [JsonProperty("firstName")]
        public String firstName { get; set; }
        //User's last name.
        [JsonProperty("lastName")]
        public String lastName { get; set; }
        //Indicates whether user interface modifications for the visually impaired are on (true) or off (false).
        [JsonProperty("accessibilityModeEnabled")]
        public bool accessibilityMode { get; set; }
        //The user's email address.
        [JsonProperty("email")]
        public String email { get; set; }
        //User's full name.
        [JsonProperty("fullName")]
        public String fullName { get; set; }
        //User\u2019s locale, which controls the formatting of dates and choice of symbols for currency.
        [JsonProperty("locale")]
        public String locale { get; set; }
        //User's language, which controls the language for labels displayed in an application.
        [JsonProperty("language")]
        public String language { get; set; }
        //The user's configured timezone.
        [JsonProperty("timeZone")]
        public String timeZone { get; set; }
        //Information about the user's profile identifier.
        [JsonProperty("profileId")]
        public String profileId { get; set; }
        //Role ID of the role currently assigned to the user.
        [JsonProperty("roleId")]
        public String roleId { get; set; }
        //Current user's license type in label form.
        [JsonProperty("userType")]
        public String userType { get; set; }
        //Current user's default currency ISO code (applies only if multi-currency is enabled for the org).
        [JsonProperty("currencyISOCode")]
        public String currencyISOCode { get; set; }
        //Returns the full profile photo of the current user.
        [JsonProperty("profilePhotoUrl")]
        public String profilePhotoUrl { get; set; }
        //Returns the thumbnail photo of the current user.
        [JsonProperty("profileThumbnailUrl")]
        public String profileThumbnailUrl { get; set; }

        public override String ToString()
        {
            return userId+ ","+
                   userName+ ","+
                   firstName+","+
                   lastName+ ","+
                   email+ ","+
                   fullName+ ","+
                   locale+ ","+
                   language+ ","+
                   timeZone+ ","+
                   profileId+ ","+
                   roleId+ ","+
                   userType+ ","+
                   currencyISOCode+ ","+
                   accessibilityMode+ ","+
                   profilePhotoUrl+","+
                   profileThumbnailUrl;

        }
    }
}
