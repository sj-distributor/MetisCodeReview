using Microsoft.Extensions.Configuration;

namespace MetisCodeReview.Core.Settings;

public class OpenAiSettings : IConfigurationSetting
{
    public OpenAiSettings(IConfiguration configuration)
    {
        ApiKey = configuration.GetValue<string>("OpenAi:ApiKey");
        Organization = configuration.GetValue<string>("OpenAi:Organization");
    }
    
    public string ApiKey { get; set; }
    
    public string Organization { get; set; }
}