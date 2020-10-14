// <copyright file="ServiceCollectionExtensions.cs" company="Hilres">
// Copyright (c) Hilres. All rights reserved.
// </copyright>

namespace Core.Extensions
{
    using Core.Model;
    using Microsoft.EntityFrameworkCore;
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
        public static IServiceCollection AddCoreServes(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CoreDbContext>(
                        options => options.UseSqlite(connectionString, options => options.MigrationsAssembly("Core")));
            return services;
        }
    }
}