using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public int? TagId { get; set; }

    public int? ImageId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateOnly? PostedDate { get; set; }

    public string? Summary { get; set; }

    public bool? IsDelete { get; set; }

    public string? Slug { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<BlogTranslation> BlogTranslations { get; set; } = new List<BlogTranslation>();

    public virtual Image? Image { get; set; }

    public virtual Tag? Tag { get; set; }
}
