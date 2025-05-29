using System;
using ImageAnnotationAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageAnnotationAPI.Data;

public class AnnotationContext : IdentityDbContext<User>
{
    public AnnotationContext(DbContextOptions<AnnotationContext> options) : base(options) { }

}
