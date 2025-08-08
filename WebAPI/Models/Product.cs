using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public float? Price { get; set; }

    public int? Quantity { get; set; }

    public int? BrandId { get; set; }

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsSoldOut { get; set; }

    public string? Slug { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductTranslation> ProductTranslations { get; set; } = new List<ProductTranslation>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();
}
