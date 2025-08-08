using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class DiscountType
{
    public int DiscoutTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DiscountTypeTranslation> DiscountTypeTranslations { get; set; } = new List<DiscountTypeTranslation>();

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}
