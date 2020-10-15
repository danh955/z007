// <copyright file="RevalidatingIdentityAuthenticationStateProvider.cs" company="MyProject">
// Copyright (c) MyProject. All rights reserved.
// </copyright>

namespace BlazorUI.Areas.Identity
{
    using System;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Server;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Re-validating identity authentication state provider class.
    /// </summary>
    /// <typeparam name="TUser">User.</typeparam>
    public class RevalidatingIdentityAuthenticationStateProvider<TUser>
        : RevalidatingServerAuthenticationStateProvider
        where TUser : class
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IdentityOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="RevalidatingIdentityAuthenticationStateProvider{TUser}"/> class.
        /// </summary>
        /// <param name="loggerFactory">ILoggerFactory.</param>
        /// <param name="scopeFactory">IServiceScopeFactory.</param>
        /// <param name="optionsAccessor">IOptions.</param>
        public RevalidatingIdentityAuthenticationStateProvider(
            ILoggerFactory loggerFactory,
            IServiceScopeFactory scopeFactory,
            IOptions<IdentityOptions> optionsAccessor)
            : base(loggerFactory)
        {
            this.scopeFactory = scopeFactory;
            this.options = optionsAccessor?.Value;
        }

        /// <inheritdoc/>
        protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(30);

        /// <inheritdoc/>
        protected override async Task<bool> ValidateAuthenticationStateAsync(
            AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            if (authenticationState == null)
            {
                throw new ArgumentNullException(nameof(authenticationState));
            }

            var scope = this.scopeFactory.CreateScope();
            if (scope == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<TUser>>();
                return await this.ValidateSecurityStampAsync(userManager, authenticationState.User).ConfigureAwait(false);
            }
            finally
            {
                if (scope is IAsyncDisposable asyncDisposable)
                {
                    await asyncDisposable.DisposeAsync().ConfigureAwait(false);
                }
                else
                {
                    scope.Dispose();
                }
            }
        }

        private async Task<bool> ValidateSecurityStampAsync(UserManager<TUser> userManager, ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal).ConfigureAwait(false);
            if (user == null)
            {
                return false;
            }
            else if (!userManager.SupportsUserSecurityStamp)
            {
                return true;
            }
            else
            {
                var principalStamp = principal.FindFirstValue(this.options.ClaimsIdentity.SecurityStampClaimType);
                var userStamp = await userManager.GetSecurityStampAsync(user).ConfigureAwait(false);
                return principalStamp == userStamp;
            }
        }
    }
}