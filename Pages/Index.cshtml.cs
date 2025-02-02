using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieRecommendationWeb.Models;
using MovieRecommendationWeb.Services;

namespace MovieRecommendationWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CsvReaderService _csvReaderService;
        private readonly MovieRecommendationService _recommendationService;

        [BindProperty]
        public string Genres { get; set; }

        [BindProperty]
        public int MaxResults { get; set; }

        public List<Movie> Recommendations { get; set; }

        // Constructor
        public IndexModel()
        {
            _csvReaderService = new CsvReaderService();
            var movies = _csvReaderService.ReadMovies("/Users/anamay/Documents/Personal/Projects_personal/MovieRecommendationWeb/IMDB-Movie-Data.csv");  // Ensure the file path is correct
            _recommendationService = new MovieRecommendationService(movies);
        }

        // Handles GET request
        public void OnGet()
        {
        }

        // Handles POST request
        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Genres))
            {
                var selectedGenres = Genres.Split(',')
                                           .Select(g => g.Trim())
                                           .Where(g => !string.IsNullOrEmpty(g))
                                           .ToList();

                Recommendations = _recommendationService.GetRecommendations(selectedGenres, MaxResults);
            }
        }
    }
}
