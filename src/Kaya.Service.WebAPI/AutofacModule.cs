using Autofac;
using AutoMapper;
using Kaya.Service.Application.Commands;
using Kaya.Service.Application.Pipelines;
using Kaya.Service.Application.Services;
using Kaya.Service.Application.Services.Interfaces;
using Kaya.Service.Domain;
using Kaya.Service.WebAPI.Filters;
using Kaya.Service.WebAPI.Settings;
using MediatR;

namespace Kaya.Service.WebAPI;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(c =>
                new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperProfile());
                }).CreateMapper())
            .As<IMapper>()
            .SingleInstance();
        
        builder.RegisterType<ProjectAuthService>()
            .As<IProjectAuthService>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<AuthService>()
            .As<IAuthService>()
            .InstancePerLifetimeScope();
        
        builder.RegisterGeneric(typeof(AuthorizationBehaviour<,>))
            .As(typeof(IPipelineBehavior<,>))
            .InstancePerLifetimeScope();

        builder.RegisterType<DatabaseSettings>()
            .As<IDatabaseSettings>()
            .SingleInstance();

        builder.RegisterType<KayaDbContext>()
            .AsSelf()
            .InstancePerLifetimeScope();

        builder.RegisterType<AddEventCommand>()
            .AsSelf()
            .InstancePerDependency();

        builder.RegisterType<AuthFilter>()
            .AsSelf()
            .InstancePerLifetimeScope();
    }
}