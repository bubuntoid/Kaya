using Kaya.AspNetCore;

namespace Kaya.Service.WebAPI.Settings;

public class KayaSettings : SettingsBase, IKayaCredentials
{
    public string Endpoint => GetValue<string>("Endpoint");
    public string ProjectPrivateKey => GetValue<string>("ProjectPrivateKey");

    public KayaSettings(IConfiguration config) : base(config, "Kaya")
    {
    }
}