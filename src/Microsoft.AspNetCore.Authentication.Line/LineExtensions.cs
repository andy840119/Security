// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Line;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LineAuthenticationOptionsExtensions
    {
        public static AuthenticationBuilder AddLine(this AuthenticationBuilder builder)
            => builder.AddLine(LineDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddLine(this AuthenticationBuilder builder, Action<LineOptions> configureOptions)
            => builder.AddLine(LineDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddLine(this AuthenticationBuilder builder, string authenticationScheme, Action<LineOptions> configureOptions)
            => builder.AddLine(authenticationScheme, LineDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddLine(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<LineOptions> configureOptions)
            => builder.AddOAuth<LineOptions, LineHandler>(authenticationScheme, displayName, configureOptions);
    }
}
