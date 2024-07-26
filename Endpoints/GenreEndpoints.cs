﻿using GameStore.API.Data;
using GameStore.API.Entities;
using GameStore.API.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres");

        group.MapGet("/",async (GameStoreContex dbContext) =>
        await dbContext.Genres
                       .Select(genre => genre.ToDto())
                       .AsNoTracking()
                       .ToListAsync());

        return group;
    }
}
