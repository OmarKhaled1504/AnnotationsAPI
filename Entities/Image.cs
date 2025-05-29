using System;

namespace ImageAnnotationAPI.Entities;

public class Image
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<Annotation> Annotations { get; set; } = new();
}
