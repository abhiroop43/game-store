using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GameClients
{
    private readonly List<GameSummary> _games =
    [
        new()
        {
            Id = 1,
            Name = "Adventure Quest",
            Genre = "Adventure",
            Price = 29.99m,
            ReleaseDate = new DateOnly(2022, 5, 15),
        },
        new()
        {
            Id = 2,
            Name = "Racing Pro",
            Genre = "Racing",
            Price = 49.99m,
            ReleaseDate = new DateOnly(2021, 11, 20),
        },
        new()
        {
            Id = 3,
            Name = "Puzzle Master",
            Genre = "Puzzle",
            Price = 19.99m,
            ReleaseDate = new DateOnly(2023, 2, 10),
        },
    ];

    public GameSummary[] GetGames() => [.. _games];
}
