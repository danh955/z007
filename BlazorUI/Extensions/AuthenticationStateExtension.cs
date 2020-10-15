// <copyright file="AuthenticationStateExtension.cs" company="MyProject">
// Copyright (c) MyProject. All rights reserved.
// </copyright>

namespace BlazorUI.Extensions
{
    using Microsoft.AspNetCore.Components.Authorization;

    /// <summary>
    /// Authentication state extensions.
    /// </summary>
    public static class AuthenticationStateExtension
    {
        /// <summary>
        /// Get the authenticated user name.  If email, just get the name.
        /// </summary>
        /// <param name="authState">AuthenticationState.</param>
        /// <returns>User name.  null if not found.</returns>
        public static string GetUserName(this AuthenticationState authState)
        {
            string name = authState?.User?.Identity?.Name;
            if (name == null)
            {
                return null;
            }

            var idx = name.IndexOf('@', System.StringComparison.OrdinalIgnoreCase);
            return idx > 0 ? name.Substring(0, idx) : name;
        }
    }
}