// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Authentication.Line
{
    public static class LineDefaults
    {
        public const string AuthenticationScheme = "Line";

        public static readonly string DisplayName = "Line";

        public static readonly string AuthorizationEndpoint = "https://access.line.me/oauth2/v2.1/authorize";

        public static readonly string TokenEndpoint = "https://api.line.me/oauth2/v2.1/token";

        public static readonly string UserInformationEndpoint = "https://api.line.me/v2/profile";
    }
}
