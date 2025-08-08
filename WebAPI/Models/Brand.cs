using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BrandTranslation> BrandTranslations { get; set; } = new List<BrandTranslation>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
