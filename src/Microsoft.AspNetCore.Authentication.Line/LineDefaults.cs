// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Authentication.Line
{
    public static class LineDefaults
    {
        public const string AuthenticationScheme = "Line";

        public static readonly string DisplayName = "Line";

        public static readonly string AuthorizationEndpoint = "https://www.facebook.com/v2.12/dialog/oauth";

        public static readonly string TokenEndpoint = "https://graph.facebook.com/v2.12/oauth/access_token";

        public static readonly string UserInformationEndpoint = "https://graph.facebook.com/v2.12/me";
    }
}
