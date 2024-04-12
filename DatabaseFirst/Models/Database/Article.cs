using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models.Database;

public partial class Article
{
    public int Id { get; set; }

    public string Headline { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Created { get; set; }

    public string Author { get; set; } = null!;

    public string ImageFile { get; set; } = null!;
}
