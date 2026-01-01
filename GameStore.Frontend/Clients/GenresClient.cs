using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient(HttpClient client)
{
    public async Task<Genre[]> GetGenresAsync()
    {
        return await client.GetFromJsonAsync<Genre[]>("genres") ?? [];
    }
}
