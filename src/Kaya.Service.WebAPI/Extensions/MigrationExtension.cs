using FluentMigrator.Runner;

namespace Kaya.Service.WebAPI.Extensions;

public static class MigrationExtension
{
    public static void Migrate(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
        runner!.ListMigrations();
        runner.MigrateUp();
    }
}