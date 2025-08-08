using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models;

public partial class PamMedicineContext : DbContext
{
    public PamMedicineContext()
    {
    }

    public PamMedicineContext(DbContextOptions<PamMedicineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogTranslation> BlogTranslations { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<BrandTranslation> BrandTranslations { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryTranslation> CategoryTranslations { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<DiscountType> DiscountTypes { get; set; }

    public virtual DbSet<DiscountTypeTranslation> DiscountTypeTranslations { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductTranslation> ProductTranslations { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PromotionType> PromotionTypes { get; set; }

    public virtual DbSet<PromotionTypeTranslation> PromotionTypeTranslations { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagTranslation> TagTranslations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PAM_Medicine;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.ToTable("Blog");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Slug).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Image).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_Blog_Image");

            entity.HasOne(d => d.Tag).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("FK_Blog_Tag");
        });

        modelBuilder.Entity<BlogTranslation>(entity =>
        {
            entity.HasKey(e => new { e.BlogId, e.LanguageCode });

            entity.ToTable("BlogTranslation");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .IsFixedLength();

            entity.HasOne(d => d.Blog).WithMany(p => p.BlogTranslations)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogTranslation_Blog");

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.BlogTranslations)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogTranslation_Language");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<BrandTranslation>(entity =>
        {
            entity.HasKey(e => new { e.BrandId, e.LanguageCode });

            entity.ToTable("BrandTranslation");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Brand).WithMany(p => p.BrandTranslations)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BrandTranslation_Brand");

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.BrandTranslations)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BrandTranslation_Language");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsFixedLength();
            entity.Property(e => e.Slug).HasMaxLength(250);
        });

        modelBuilder.Entity<CategoryTranslation>(entity =>
        {
            entity.HasKey(e => new { e.CategoryId, e.LanguageCode });

            entity.ToTable("CategoryTranslation");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryTranslations)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryTranslation_Category");

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.CategoryTranslations)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryTranslation_Language");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(250);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.ToTable("Discount");

            entity.Property(e => e.DiscountId).ValueGeneratedNever();
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreateAt).HasColumnType("datetime");

            entity.HasOne(d => d.DiscountType).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.DiscountTypeId)
                .HasConstraintName("FK_Discount_DiscountType");
        });

        modelBuilder.Entity<DiscountType>(entity =>
        {
            entity.HasKey(e => e.DiscoutTypeId);

            entity.ToTable("DiscountType");

            entity.Property(e => e.DiscoutTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<DiscountTypeTranslation>(entity =>
        {
            entity.HasKey(e => new { e.DiscountTypeId, e.LanguageCode });

            entity.ToTable("DiscountTypeTranslation");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.DiscountType).WithMany(p => p.DiscountTypeTranslations)
                .HasForeignKey(d => d.DiscountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountTypeTranslation_DiscountType");

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.DiscountTypeTranslations)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscountTypeTranslation_Language");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.Data).HasColumnType("image");
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageCode);

            entity.ToTable("Language");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Detail).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_Order\\");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Order_Customer");

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DiscountId)
                .HasConstraintName("FK_Order_Discount");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId).ValueGeneratedNever();

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItem_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderItem_Product");

            entity.HasOne(d => d.Promotion).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK_OrderItem_Promotion");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Slug).HasMaxLength(250);
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.ToTable("ProductImage");

            entity.HasOne(d => d.Image).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("FK_ProductImage_Image");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductImage_Product");
        });

        modelBuilder.Entity<ProductTranslation>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.LanguageCode });

            entity.ToTable("ProductTranslation");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.ProductTranslations)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTranslation_Language");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTranslations)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTranslation_Product");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.ToTable("Promotion");

            entity.Property(e => e.PromotionId).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Promotion_Product");

            entity.HasOne(d => d.PromotionType).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.PromotionTypeId)
                .HasConstraintName("FK_Promotion_PromotionType");
        });

        modelBuilder.Entity<PromotionType>(entity =>
        {
            entity.ToTable("PromotionType");

            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<PromotionTypeTranslation>(entity =>
        {
            entity.HasKey(e => new { e.PromotionTypeId, e.LanguageCode });

            entity.ToTable("PromotionTypeTranslation");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.PromotionTypeTranslations)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PromotionTypeTranslation_Language");

            entity.HasOne(d => d.PromotionType).WithMany(p => p.PromotionTypeTranslations)
                .HasForeignKey(d => d.PromotionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PromotionTypeTranslation_PromotionType");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("Tag");

            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<TagTranslation>(entity =>
        {
            entity.HasKey(e => new { e.TagId, e.LanguageCode });

            entity.ToTable("TagTranslation");

            entity.Property(e => e.LanguageCode)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.TagTranslations)
                .HasForeignKey(d => d.LanguageCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TagTranslation_Language");

            entity.HasOne(d => d.Tag).WithMany(p => p.TagTranslations)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TagTranslation_Tag");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
