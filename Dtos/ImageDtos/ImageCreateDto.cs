namespace ImageAnnotationAPI.Dtos.ImageDtos;

public class ImageCreateDto
{
    public IFormFile File { get; set; } = null!;
    public string? Description { get; set; }
}
