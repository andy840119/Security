// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Authentication.Line
{
    /// <summary>
    /// Configuration options for <see cref="LineHandler"/>.
    /// </summary>
    public class LineOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="LineOptions"/>.
        /// </summary>
        public LineOptions()
        {
            CallbackPath = new PathString("");
            SendAppSecretProof = true;
            AuthorizationEndpoint = LineDefaults.AuthorizationEndpoint;
            TokenEndpoint = LineDefaults.TokenEndpoint;
            UserInformationEndpoint = LineDefaults.UserInformationEndpoint;

            //get scope
            Scope.Add("openid");
            Scope.Add("profile");
            Scope.Add("email");

            //field
            QueryParameter.Add("response_type","code");
            QueryParameter.Add("client_id",ClientId);

            //get scope
            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "openid");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
        }

        /// <summary>
        /// Check that the options are valid.  Should throw an exception if things are not ok.
        /// </summary>
        public override void Validate()
        {
            if (string.IsNullOrEmpty(ClientId))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Exception_OptionMustBeProvided, nameof(ClientId)), nameof(ClientId));
            }

            if (string.IsNullOrEmpty(AppSecret))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.Exception_OptionMustBeProvided, nameof(AppSecret)), nameof(AppSecret));
            }

            base.Validate();
        }

        // Line uses a non-standard term for this field.
        /// <summary>
        /// Gets or sets the Line-assigned app secret.
        /// </summary>
        public string AppSecret
        {
            get { return ClientSecret; }
            set { ClientSecret = value; }
        }

        /// <summary>
        /// Gets or sets if the appsecret_proof should be generated and sent with Line API calls.
        /// This is enabled by default.
        /// </summary>
        public bool SendAppSecretProof { get; set; }

        /// <summary>
        /// The list of fields to retrieve from the UserInformationEndpoint.
        /// https://developers.line.me/en/docs/line-login/web/try-line-login/
        /// </summary>
        public IDictionary<string,string> QueryParameter { get; } = new Dictionary<string,string>();
    }
}
