using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using MovieRecommendationWeb.Models;

namespace MovieRecommendationWeb.Services
{
    public class CsvReaderService
    {
        public List<Movie> ReadMovies(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture));
            return csv.GetRecords<Movie>().ToList();
        }
    }
}