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
using System.Security.Cryptography;
using System.IO;

namespace CanvasClasses
{
 /*
 *
 * The utility method can be used to validate/verify the signed request. In this case,
 * the signed request is verified that it is from Salesforce and that it has not been tampered with.
 * <p>
 * This utility class has two methods. One verifies and decodes the request as a Java object the
 * other as a JSON String.
 *
 */
    public class SignedRequest 
    {
        /* Verifying and Decoding a Signed Request from Salesforce 
         * 1. split the signed request on the FIRST period(.).  
         *  a. string[0] = hashed Base64 context signed with the consumer secret
         *  b. string[1] = Base64 encoded context itself
         *  use HMAC SHA-256 algorith to hash the Base64 encoded context (string[1]) and sign it using your consumer secret
         *  Compare the Base64 encoded string with the hashed Base64 context signed with the consumer secret
         */
        public static CanvasRequest verifyAndDecode(String signedRequest, String secret) 
        {
            CanvasRequest returnCanvasRequest = new CanvasRequest();

            String decodedSignature = "";
            String decodedPayload = "";
            String[] split = getParts(Uri.UnescapeDataString(signedRequest));//decode signedRequest before processing
            if(split.Length==2) 
            {
                decodedSignature = split[0];
                decodedPayload = split[1];

                if (verify(secret, decodedPayload, decodedSignature))
                {
                    byte[] encodedDataAsBytes = System.Convert.FromBase64String(decodedPayload);
                    string jsonData = System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);

                    //populate the CanvasRequest object based on this JSON payload
                    //returnCanvasRequest.client;
                    Newtonsoft.Json.JsonSerializer js = new JsonSerializer();
                    JsonTextReader reader = new JsonTextReader(new StringReader(jsonData));
                    returnCanvasRequest = js.Deserialize<CanvasRequest>(reader);  
                } 
            }             
            return returnCanvasRequest;         
        }
        
        public static String verifyAndDecodeAsJson(String signedRequest, String secret) 
        {
            String decodedSignature = "";
            String decodedPayload = "";
            String[] split = getParts(Uri.UnescapeDataString(signedRequest));//decode signedRequest before processing
            if (split.Length == 2)
            {
                decodedSignature = split[0];
                decodedPayload = split[1];

                if (verify(secret, decodedPayload, decodedSignature))
                {
                    byte[] encodedDataAsBytes = System.Convert.FromBase64String(decodedPayload);
                    return System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
                }
                else
                {
                    throw new System.Exception(String.Format("Verify() method returned false;"));
                }
            }
            else
            {
                throw new System.Exception(String.Format("Signed Request was not valid."));
            }
        }

        public static String[] getParts(String input)
        {
            if (input == null || input.IndexOf(".") <= 0) {
                throw new System.Exception(String.Format("Input {0} doesn't look like a signed request", input));
            }

            String[] split = input.Split('.');
            return split;
        }

        private static bool verify(String consumerSecret, String encodedPayload, String encodedSignature)            
        {
            if (consumerSecret == null || consumerSecret.Trim().Length == 0)
            {
                throw new System.ArgumentException("secret is null, did you set your environment variable CANVAS_CONSUMER_SECRET?");            
            }
                       
            try {
               byte[] key = Encoding.UTF8.GetBytes(consumerSecret);
               HMACSHA256 hmacKey = new HMACSHA256(key);
               hmacKey.Initialize();
               byte[] algorithmBytes = Encoding.UTF8.GetBytes(encodedPayload);
               byte[] rawHmac = hmacKey.ComputeHash(algorithmBytes);
               string result = Convert.ToBase64String(rawHmac);

               return (result == Uri.UnescapeDataString(encodedSignature)) ? true : false;   
              
            } catch (System.Exception e) {
                throw new System.Exception("Verify failed.", e.InnerException);
            }
        }

    }
}
