using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int? ProductId { get; set; }

    public int? ImageId { get; set; }

    public bool? IsUnique { get; set; }

    public virtual Image? Image { get; set; }

    public virtual Product? Product { get; set; }
}
