using System.Reflection;
using System.Runtime.CompilerServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using Hangfire;
using Hangfire.PostgreSql;
using Kaya.Service.Application.Commands;
using Kaya.AspNetCore;
using Kaya.Service.Domain.Migrations;
using Kaya.Service.WebAPI;
using Kaya.Service.WebAPI.Extensions;
using Kaya.Service.WebAPI.Settings;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(b =>
    {
        b.RegisterModule(new AutofacModule());
    });

var dbSettings = new DatabaseSettings(builder.Configuration);
var kayaSettings = new KayaSettings(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(dbSettings.ConnectionString));
builder.Services.AddHangfireServer();
builder.Services.AddMediatR(typeof(AddEventCommand));
builder.Services.AddKayaLogging(kayaSettings);

builder.Services
    .AddLogging(c => c.AddFluentMigratorConsole())
    .AddFluentMigratorCore()
    .ConfigureRunner(c => c
        .AddPostgres11_0()
        .WithGlobalConnectionString(dbSettings.ConnectionString)
        .ScanIn(typeof(InitializeDatabaseMigration).Assembly).For.All());

// ==================================================================== //

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var autofacContainer = app.Services.GetAutofacRoot();

GlobalConfiguration.Configuration.UsePostgreSqlStorage(dbSettings.ConnectionString)
    .UseMediatR(autofacContainer.Resolve<IMediator>());

app.UseKayaLogging();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToAreaController("Index", "Index", "");
});

app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.MapControllers();

app.Migrate();

app.Run();
