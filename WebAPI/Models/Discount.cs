using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Discount
{
    public int DiscountId { get; set; }

    public int? DiscountTypeId { get; set; }

    public string? Code { get; set; }

    public float? Value { get; set; }

    public float? MaxValue { get; set; }

    public float? MinPurchase { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? Quantity { get; set; }

    public int? MaxUse { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsPrivate { get; set; }

    public int? QuantityUsed { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual DiscountType? DiscountType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
