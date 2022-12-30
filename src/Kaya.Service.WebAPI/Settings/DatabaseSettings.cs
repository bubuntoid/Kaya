using Kaya.Service.Domain;

namespace Kaya.Service.WebAPI.Settings;

public class DatabaseSettings : SettingsBase, IDatabaseSettings
{
    public string ConnectionString => GetValue<string>("ConnectionString");

    public DatabaseSettings(IConfiguration config) : base(config, "Database")
    {
    }
}