using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient client)
{
    public async Task<GameSummary[]> GetGamesAsync()
    {
        return await client.GetFromJsonAsync<GameSummary[]>("games") ?? [];
    }

    public async Task AddGameAsync(GameDetails game)
    {
        await client.PostAsJsonAsync("games", game);
    }

    public async Task UpdateGameAsync(GameDetails game)
    {
        await client.PutAsJsonAsync($"games/{game.Id}", game);
    }

    public async Task DeleteGameAsync(int id)
    {
        await client.DeleteAsync($"games/{id}");
    }

    public async Task<GameDetails> GetGameByIdAsync(int id)
    {
        return await client.GetFromJsonAsync<GameDetails>($"games/{id}")
            ?? throw new Exception("Game not found");
    }
}
