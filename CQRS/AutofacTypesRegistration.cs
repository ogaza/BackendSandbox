using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Autofac;
using Module = Autofac.Module;
using CQRS.Commands;
using CQRS.Infrastructure;

namespace CQRS.Autofac
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(new[] { Assembly.GetAssembly(typeof(QueriesModule)) })
                .AsClosedTypesOf(typeof(IQueryHandler<,>));

            builder.RegisterType<QueryDispatcher>().AsImplementedInterfaces();
        }
    }

    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(new[] { Assembly.GetAssembly(typeof(CommandModule)) })
                .AsClosedTypesOf(typeof(ICommandHandler<>));

            builder.RegisterType<CommandDispatcher>().AsImplementedInterfaces();
            base.Load(builder);
        }
    }

    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterCommandDecorators(builder);

            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(configuration.GetConnectionString("AppDatabase")).Options;
                return new AppDbContext(options);
            }).AsSelf().InstancePerLifetimeScope();

            base.Load(builder);
        }

        private static void RegisterCommandDecorators(ContainerBuilder builder)
        {
            builder.RegisterGenericDecorator(typeof(TransactionCommandHandlerDecorator<>), typeof(ICommandHandler<>));
        }
    }
}