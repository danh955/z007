// <copyright file="ServiceCollectionExtensions.cs" company="Hilres">
// Copyright (c) Hilres. All rights reserved.
// </copyright>

namespace Core.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Service collection extensions class.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add core serves.
        /// </summary>
        /// <param name="services">IServiceCollection.</param>
        /// <returns>Updated IServiceCollection.</returns>
        public static IServiceCollection AddCoreServes(this IServiceCollection services)
        {
            return services;
        }
    }
}