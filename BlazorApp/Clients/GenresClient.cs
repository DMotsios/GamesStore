namespace BlazorApp.Frontend.Models;

public class GenresClient
{
    private readonly Genre[] genres = [
        new() { Id = 1, Name = "Action" },
        new() { Id = 2, Name = "RPG" },
        new() { Id = 3, Name = "Adventure" },
        new() { Id = 4, Name = "Simulation" },
        new() { Id = 5, Name = "Strategy" }
    ];

    public Genre[] GetGenres()
    {
        return genres;
    }
}