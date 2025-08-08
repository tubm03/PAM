using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Language
{
    public string LanguageCode { get; set; } = null!;

    public string? Detail { get; set; }

    public virtual ICollection<BlogTranslation> BlogTranslations { get; set; } = new List<BlogTranslation>();

    public virtual ICollection<BrandTranslation> BrandTranslations { get; set; } = new List<BrandTranslation>();

    public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; } = new List<CategoryTranslation>();

    public virtual ICollection<DiscountTypeTranslation> DiscountTypeTranslations { get; set; } = new List<DiscountTypeTranslation>();

    public virtual ICollection<ProductTranslation> ProductTranslations { get; set; } = new List<ProductTranslation>();

    public virtual ICollection<PromotionTypeTranslation> PromotionTypeTranslations { get; set; } = new List<PromotionTypeTranslation>();

    public virtual ICollection<TagTranslation> TagTranslations { get; set; } = new List<TagTranslation>();
}
