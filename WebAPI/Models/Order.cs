using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? Note { get; set; }

    public int? DiscountId { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? CreateAt { get; set; }

    public string? Status { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
