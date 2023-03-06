using Microsoft.Extensions.Configuration;

namespace MetisCodeReview.Core.Settings;

public class ChatGptUrlSetting : IConfigurationSetting<string>
{
    public ChatGptUrlSetting(IConfiguration configuration)
    {
        Value = configuration.GetValue<string>("ChatGptUrl");
    }
    
    public string Value { get; set; }
}