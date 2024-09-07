using AppFakeStore.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using AppFakeStore.Utils;
using System.Net.Http.Json;

namespace AppFakeStore.Services;

public class UsuarioService : IUsuarioService
{
    HttpClient client;

    private static JsonSerializerOptions options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public UsuarioService()
    {
        client = new HttpClient();

        client.BaseAddress = new Uri(Constants.ApiDataServer);
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<IEnumerable<Usuario>> GetUsersAsync()
    {
        var response = await client.GetAsync(Constants.UsersEndpoint);

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<IEnumerable<Usuario>>(options);

        return default;
    }


    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        var response = await client.GetAsync($"{Constants.UsersEndpoint}/{id}");

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<Usuario>(options);

        return default;
    }

    
}
