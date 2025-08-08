using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<TagTranslation> TagTranslations { get; set; } = new List<TagTranslation>();
}
