using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class PromotionTypeTranslation
{
    public int PromotionTypeId { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string? Name { get; set; }

    public virtual Language LanguageCodeNavigation { get; set; } = null!;

    public virtual PromotionType PromotionType { get; set; } = null!;
}
