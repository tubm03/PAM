using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class CategoryTranslation
{
    public int CategoryId { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string? Name { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Language LanguageCodeNavigation { get; set; } = null!;
}
