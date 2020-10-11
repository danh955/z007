// <copyright file="CoreDbContextMemoryFactory.cs" company="Hilres">
// Copyright (c) Hilres. All rights reserved.
// </copyright>

namespace Core.Model
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// Core database context memory factory.
    /// This create the database in memory.
    /// </summary>
    public class CoreDbContextMemoryFactory : IDesignTimeDbContextFactory<CoreDbContext>
    {
        /// <inheritdoc/>
        public CoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoreDbContext>();
            optionsBuilder.UseSqlite("Data Source=:memory:");

            return new CoreDbContext(optionsBuilder.Options);
        }
    }
}