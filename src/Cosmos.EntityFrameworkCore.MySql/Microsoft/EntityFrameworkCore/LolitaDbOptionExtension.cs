﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.Lolita.Update;

namespace Microsoft.EntityFrameworkCore
{
    public class MySqlLolitaDbOptionExtension : IDbContextOptionsExtension
    {
        public string LogFragment => "Pomelo.EFCore.Lolita";

        public bool ApplyServices(IServiceCollection services)
        {
            services
                .AddScoped<ISetFieldSqlGenerator, MySqlSetFieldSqlGenerator>();

            return true;
        }

        public long GetServiceProviderHashCode()
        {
            return 86216188623902;
        }

        public void Validate(IDbContextOptions options)
        {
        }
    }

    public static class LolitaDbOptionExtensions
    {
        public static DbContextOptionsBuilder UseMySqlLolita(this DbContextOptionsBuilder self)
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new MySqlLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptionsBuilder<TContext> UseMySqlLolita<TContext>(this DbContextOptionsBuilder<TContext> self) where TContext : DbContext
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new MySqlLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptions UseMySqlLolita(this DbContextOptions self)
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new MySqlLolitaDbOptionExtension());
            return self;
        }

        public static DbContextOptions<TContext> UseMySqlLolita<TContext>(this DbContextOptions<TContext> self) where TContext : DbContext
        {
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new LolitaDbOptionExtension());
            ((IDbContextOptionsBuilderInfrastructure)self).AddOrUpdateExtension(new MySqlLolitaDbOptionExtension());
            return self;
        }
    }
}
