using System;
using System.Collections.Generic;

namespace elozo2.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public string? Rating { get; set; }
}
