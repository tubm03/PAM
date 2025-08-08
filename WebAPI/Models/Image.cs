using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public byte[]? Data { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}
