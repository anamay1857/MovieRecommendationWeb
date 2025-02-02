using System.Collections.Generic;
using System.Linq;
using MovieRecommendationWeb.Models;
using CsvHelper;

namespace MovieRecommendationWeb.Services
{
    public class MovieRecommendationService
    {
        private List<Movie> _movies;

        public MovieRecommendationService(List<Movie> movies)
        {
            _movies = movies;
        }

        public List<Movie> GetRecommendations(List<string> selectedGenres, int maxResults)
        {
            var recommendedMovies = _movies
                .Where(movie => selectedGenres.Contains(movie.Genre.Trim(), StringComparer.OrdinalIgnoreCase))
                .Take(maxResults)
                .ToList();

            return recommendedMovies;
        }
    }
}
