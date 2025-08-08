using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class BlogTranslation
{
    public int BlogId { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Summary { get; set; }

    public virtual Blog Blog { get; set; } = null!;

    public virtual Language LanguageCodeNavigation { get; set; } = null!;
}
