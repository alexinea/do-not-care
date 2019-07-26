﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.Lolita.Update;

namespace Microsoft.EntityFrameworkCore
{
    public class SqliteLolitaDbOptionExtension : IDbContextOptionsExtension
    {
        public string LogFragment => "Pomelo.EFCore.Lolita";

        public bool ApplyServices(IServiceCollection services)
        {
            services
                .AddScoped<ISetFieldSqlGenerator, SqliteSetFieldSqlGenerator>();

            return true;
        }

        public long GetServiceProviderHashCode()
        {
            return 86216188623904;
        }

        public void Validate(IDbContextOptions options)
        {
        }
    }

    public static class LolitaDbOptionExtensions
    {
        public static DbContextOptionsBuilder UseSqliteLolita(this DbContextOptionsBuilder self)
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new SqliteLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptionsBuilder<TContext> UseSqliteLolita<TContext>(this DbContextOptionsBuilder<TContext> self) where TContext : DbContext
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new SqliteLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptions UseSqliteLolita(this DbContextOptions self)
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new SqliteLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptions<TContext> UseSqliteLolita<TContext>(this DbContextOptions<TContext> self) where TContext : DbContext
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new SqliteLolitaDbOptionExtension());
            return self;
        }
    }
}
