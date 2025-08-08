using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class BrandTranslation
{
    public int BrandId { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string? Name { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Language LanguageCodeNavigation { get; set; } = null!;
}
