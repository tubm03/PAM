using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class TagTranslation
{
    public int TagId { get; set; }

    public string? Name { get; set; }

    public string LanguageCode { get; set; } = null!;

    public virtual Language LanguageCodeNavigation { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
