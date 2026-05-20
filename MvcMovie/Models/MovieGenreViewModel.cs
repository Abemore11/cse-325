using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models;

public class MovieGenreViewModel
{
    public List<Movie>? Movies { get; set; }
    public SelectList? Genres { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }

    // Meets Requirement 2.4:
    // Add the ability to select a year which filters 
    // the displayed movies on that year or newer to the search options.
    public int? MinYear { get; set; }
}