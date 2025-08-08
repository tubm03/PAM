using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class ProductTranslation
{
    public int ProductId { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual Language LanguageCodeNavigation { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
