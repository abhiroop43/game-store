using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
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

    private readonly Genre[] _genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames()
    {
        return [.. _games];
    }

    public void AddGame(GameDetails game)
    {
        var genre = _genres.FirstOrDefault(g => g.Id == game.GenreId);
        var gameSummary = new GameSummary
        {
            Id = _games.Count + 1,
            Name = game.Name,
            Genre = genre != null ? genre.Name : "Unknown",
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
        _games.Add(gameSummary);
    }

    public void UpdateGame(GameDetails game)
    {
        var genre = _genres.FirstOrDefault(g => g.Id == game.GenreId);
        var existingGame = _games.Find(g => g.Id == game.Id);
        if (existingGame is null)
            return;

        existingGame.Name = game.Name;
        existingGame.Genre = genre != null ? genre.Name : "Unknown";
        existingGame.Price = game.Price;
        existingGame.ReleaseDate = game.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        var existingGame = _games.Find(g => g.Id == id);

        if (existingGame is null)
            return;

        _games.Remove(existingGame);
    }

    public GameDetails GetGameById(int id)
    {
        var game = _games.Find(g => g.Id == id);

        if (game == null)
            return null!;

        var genre = _genres.FirstOrDefault(g =>
            string.Equals(g.Name, game.Genre, StringComparison.OrdinalIgnoreCase)
        );

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre?.Id,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
    }
}
