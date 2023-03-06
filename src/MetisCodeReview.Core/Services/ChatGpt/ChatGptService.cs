using MetisCodeReview.Core.DependencyInjection;
using MetisCodeReview.Core.Services.Http;
using MetisCodeReview.Core.Settings;
using MetisCodeReview.Messages.Dtos.ChatGpt;

namespace MetisCodeReview.Core.Services.ChatGpt;

public class ChatGptService
{
    
}

public interface IChatGptClient : IScopedDependency
{
    Task<ChatGptResponseDto> PostAsChatGptAsync(string text, CancellationToken cancellationToken);
}

public class OpenAiClient : IChatGptClient
{
    private readonly OpenAiSettings _openAiSettings;
    private readonly ChatGptUrlSetting _chatGptUrlSetting;
    private readonly IMetisHttpClientFactory _httpClientFactory;

    public OpenAiClient(OpenAiSettings openAiSettings, ChatGptUrlSetting chatGptUrlSetting, IMetisHttpClientFactory httpClientFactory)
    {
        _openAiSettings = openAiSettings;
        _chatGptUrlSetting = chatGptUrlSetting;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ChatGptResponseDto> PostAsChatGptAsync(string text, CancellationToken cancellationToken)
    {
        return await _httpClientFactory
            .PostAsJsonAsync<ChatGptResponseDto>(_chatGptUrlSetting.Value, new
            {
                text = text
            }, cancellationToken).ConfigureAwait(false);
    }
}