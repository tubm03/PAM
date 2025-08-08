using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public float? Price { get; set; }

    public int? PromotionId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Promotion? Promotion { get; set; }
}
