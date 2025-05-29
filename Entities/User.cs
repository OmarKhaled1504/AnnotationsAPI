using System;
using Microsoft.AspNetCore.Identity;

namespace ImageAnnotationAPI.Entities;

public class User : IdentityUser
{
    public List<Annotation> Annotations { get; set; } = new();
}
