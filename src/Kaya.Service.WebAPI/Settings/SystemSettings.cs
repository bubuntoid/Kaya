namespace Kaya.Service.WebAPI.Settings;

public class SystemSettings : SettingsBase
{
    public bool EnableRegistration => GetValue<bool>("EnableRegistration");

    public SystemSettings(IConfiguration config) : base(config, "System")
    {
    }
}