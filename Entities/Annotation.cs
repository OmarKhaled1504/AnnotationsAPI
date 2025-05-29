using System;

namespace ImageAnnotationAPI.Entities;

public class Annotation
{
    public User User { get; set; } = null!;
    public string UserId { get; set; } = string.Empty;
    public Image Image { get; set; } = null!;
    public int ImageId { get; set; }

    public bool Annotated { get; set; } = false;
    public string AnnotationType { get; set; } = string.Empty;
}
