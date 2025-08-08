using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class PromotionType
{
    public int PromotionTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PromotionTypeTranslation> PromotionTypeTranslations { get; set; } = new List<PromotionTypeTranslation>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
