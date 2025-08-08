using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public int? Value { get; set; }

    public float? MaxValue { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? ValidProductId { get; set; }

    public string? ExceptProductId { get; set; }

    public bool? IsDeleted { get; set; }

    public string? ValidBrandId { get; set; }

    public string? ExceptBrandId { get; set; }

    public string? ValidCateId { get; set; }

    public string? ExceptCateId { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? ProductId { get; set; }

    public int? PromotionTypeId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product? Product { get; set; }

    public virtual PromotionType? PromotionType { get; set; }
}
