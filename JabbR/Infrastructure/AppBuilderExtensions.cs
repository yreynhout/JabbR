using System;
using System.Collections.Generic;
using Owin;

namespace JabbR.Infrastructure
{
    public static class AppBuilderExtensions
    {
        private const string SystemWebHostName = "System.Web 4.5, Microsoft.Owin.Host.SystemWeb 1.0.0.0";

        public static bool IsRunningUnderSystemWeb(this IAppBuilder app)
        {
            var capabilities = (IDictionary<string, object>)app.Properties["server.Capabilities"];

            // Not hosing on system web host? Bail out.
            object serverName;
            return capabilities.TryGetValue("server.Name", out serverName) &&
                   SystemWebHostName.Equals((string)serverName, StringComparison.Ordinal);
        }
    }
}