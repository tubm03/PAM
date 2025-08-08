using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class DiscountTypeTranslation
{
    public int DiscountTypeId { get; set; }

    public string LanguageCode { get; set; } = null!;

    public string? Name { get; set; }

    public virtual DiscountType DiscountType { get; set; } = null!;

    public virtual Language LanguageCodeNavigation { get; set; } = null!;
}
