using System;
using Cosmos.Data.Context;
using Cosmos.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Data
{
    public static class DbContextConfigExtensions
    {
        public static IDbContextConfig UseEfCoreWithMySql<TContext>(this DbContextConfig context, Action<EfCoreOptions> optAct = null)
            where TContext : DbContext, Cosmos.EntityFrameworkCore.IDbContext
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var opt = new EfCoreOptions();
            optAct?.Invoke(opt);

            context.RegisterDbContext(services =>
            {
                if (!string.IsNullOrWhiteSpace(opt.ConnectionString))
                {
                    services.AddDbContext<TContext>(o => o.UseMySQL(opt.ConnectionString).UseLolita());
                }
                else if (!string.IsNullOrWhiteSpace(opt.ConnectionName))
                {
                    services.AddDbContext<TContext>((p, o) =>
                        o.UseMySQL(p.GetService<IConfigurationRoot>().GetConnectionString(opt.ConnectionName)).UseLolita());
                }
                else
                {
                    throw new InvalidOperationException("Connection name or string cannot be empty.");
                }
            });

            return context;
        }

        public static IDbContextConfig UseEfCoreWithMySql<TContextService, TContextImplementation>(
            this DbContextConfig context, Action<EfCoreOptions> optAct = null)
            where TContextService : Cosmos.EntityFrameworkCore.IDbContext
            where TContextImplementation : DbContext, TContextService
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var opt = new EfCoreOptions();
            optAct?.Invoke(opt);

            context.RegisterDbContext(services =>
            {
                if (!string.IsNullOrWhiteSpace(opt.ConnectionString))
                {
                    services.AddDbContext<TContextService, TContextImplementation>(o => o.UseMySQL(opt.ConnectionString).UseLolita());
                }
                else if (!string.IsNullOrWhiteSpace(opt.ConnectionName))
                {
                    services.AddDbContext<TContextService, TContextImplementation>((p, o) =>
                        o.UseMySQL(p.GetService<IConfigurationRoot>().GetConnectionString(opt.ConnectionName)).UseLolita());
                }
                else
                {
                    throw new InvalidOperationException("Connection name or string cannot be empty.");
                }
            });

            return context;
        }
    }
}