using System.ComponentModel.DataAnnotations;

namespace ImageAnnotationAPI.Dtos.ImageDtos;

public class ImageCreateDto
{
    [Required] public IFormFile File { get; set; } = null!;
    public string? Description { get; set; }
}
