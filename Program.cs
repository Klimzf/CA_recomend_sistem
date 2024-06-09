
using CA_recomend_sistem.Application.Services;
using CA_recomend_sistem.Core.Interfaces;
using CA_recomend_sistem.Core.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Регистрация зависимостей
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieRecommendationService, MovieRecommendationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserMovieRatingRepository, UserMovieRatingRepository>();
builder.Services.AddScoped<IUserRecommendationService, MovieRecommendationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/api/movies/recommendations", async (IMovieRecommendationService recommendationService) =>
    {
        var recommendedMovies = await recommendationService.GetRecommendedMoviesAsync();
        return Results.Ok(recommendedMovies);
    });

    endpoints.MapGet("/api/users/{userId}/recommendations", async (int userId, IMovieRecommendationService recommendationService) =>
    {
        var recommendedMovies = await recommendationService.GetRecommendedMoviesForUserAsync(userId);
        return Results.Ok(recommendedMovies);
    });
});

app.Run();