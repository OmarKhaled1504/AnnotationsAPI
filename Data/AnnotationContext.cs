using System;
using ImageAnnotationAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageAnnotationAPI.Data;

public class AnnotationContext : IdentityDbContext<User>
{
    public DbSet<Image> Images => Set<Image>();
    public DbSet<Annotation> Annotations => Set<Annotation>();

    public AnnotationContext(DbContextOptions<AnnotationContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder); // Make sure Identity works

    builder.Entity<Annotation>()
        .HasKey(a => new { a.UserId, a.ImageId });

    builder.Entity<Annotation>()
        .HasOne(a => a.User)
        .WithMany(u => u.Annotations)
        .HasForeignKey(a => a.UserId);

    builder.Entity<Annotation>()
        .HasOne(a => a.Image)
        .WithMany(i => i.Annotations)
        .HasForeignKey(a => a.ImageId);
}
}
