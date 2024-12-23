using BlazorApp.Frontend.Models;
using BlazorApp.Models;

namespace BlazorApp.Frontend.Clients;


public class GamesClient
{
    private List<GameSummary> games = [
    new () { Id = 1, Name = "The Witcher 3: Wild Hunt", Genre = "RPG", Price = 29.99m, ReleaseDate = new DateOnly(2015, 5, 19) },
    new () { Id = 2, Name = "Grand Theft Auto V", Genre = "Action", Price = 29.99m, ReleaseDate = new DateOnly(2013, 9, 17) },
    new () { Id = 3, Name = "Red Dead Redemption 2", Genre = "Action", Price = 59.99m, ReleaseDate = new DateOnly(2018, 10, 26) },
    new () { Id = 4, Name = "The Elder Scrolls V: Skyrim", Genre = "RPG", Price = 19.99m, ReleaseDate = new DateOnly(2011, 11, 11) },
    new () { Id = 5, Name = "The Legend of Zelda: Breath of the Wild", Genre = "Action", Price = 59.99m, ReleaseDate = new DateOnly(2017, 3, 3) }
];

    private readonly Genre[] genres = new GenresClient().GetGenres();
    public GameSummary[] GetGames()
    {
        return [.. games];
    }

    public GameDetails GetGame(int id)
    {

        GameSummary game = GetGameSummaryById(id);

        var genre = genres.First(g => string.Equals(g.Name, game.Genre, StringComparison.OrdinalIgnoreCase));
        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void AddGame(GameDetails game)
    {

        Genre genre = GetGenrebyId(game.GenreId);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenrebyId(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(int id)
    {
        games.RemoveAll(game => game.Id == id);
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(el => el.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenrebyId(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.First(g => g.Id == int.Parse(id));
    }
}