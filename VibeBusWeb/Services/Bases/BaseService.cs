using Newtonsoft.Json;

namespace VibeBusWeb.Services.Bases;

public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
{
    private readonly HttpClient _httpClient;

#if (DEBUG)

    protected virtual string BasePath => $"{nameof(TEntity).ToLower()}";

#elif (RELEASE)

    protected virtual string BasePath => $"vibe-bus/{nameof(TEntity).ToLower()}";

#endif

    protected BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<IEnumerable<TEntity>>($"{BasePath}/GetAll");
        return result!;
    }

    public virtual async Task<HttpResponseMessage> CreateAsync(TEntity entity)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BasePath}/Add", entity);
        var result = JsonConvert.DeserializeObject<HttpResponseMessage>(await response.Content.ReadAsStringAsync());

        return result!;
    }

    public virtual async Task<HttpResponseMessage> UpdateAsync(TEntity entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"{BasePath}/Update", entity);
        var result = JsonConvert.DeserializeObject<HttpResponseMessage>(await response.Content.ReadAsStringAsync());

        return result!;
    }

    public virtual async Task<HttpResponseMessage> DeleteAsync(int id)
    {
        var result = await _httpClient.DeleteAsync($"{BasePath}/Delete?Id={id}");
        return result;
    }
}