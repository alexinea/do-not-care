﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.Lolita.Update;

namespace Microsoft.EntityFrameworkCore
{
    public class PostgreSQLLolitaDbOptionExtension : IDbContextOptionsExtension
    {
        public string LogFragment => "Pomelo.EFCore.Lolita";

        public bool ApplyServices(IServiceCollection services)
        {
            services
                .AddScoped<ISetFieldSqlGenerator, PostgreSQLSetFieldSqlGenerator>();

            return true;
        }

        public long GetServiceProviderHashCode()
        {
            return 86216188623903;
        }

        public void Validate(IDbContextOptions options)
        {
        }
    }

    public static class LolitaDbOptionExtensions
    {
        public static DbContextOptionsBuilder UsePostgreSQLLolita(this DbContextOptionsBuilder self)
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new PostgreSQLLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptionsBuilder<TContext> UsePostgreSQLLolita<TContext>(this DbContextOptionsBuilder<TContext> self) where TContext : DbContext
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new PostgreSQLLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptions UsePostgreSQLLolita(this DbContextOptions self)
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new PostgreSQLLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptions<TContext> UsePostgreSQLLolita<TContext>(this DbContextOptions<TContext> self) where TContext : DbContext
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new PostgreSQLLolitaDbOptionExtension());
            return self;
        }
    }
}
