using GameStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class GameStoreContex(DbContextOptions<GameStoreContex> options) 
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new {ID = 1, Name = "Sports"},
            new {ID = 2, Name = "RPG"},
            new {ID = 3, Name = "Fighting"},
            new {ID = 4, Name = "Racing"},
            new {ID = 5, Name = "Kids and Family"}
        );
    }

}
