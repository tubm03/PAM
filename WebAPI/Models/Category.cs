using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; } = new List<CategoryTranslation>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
