namespace ImageAnnotationAPI.Dtos.ImageDtos;

public record class ImageCreateDto(IFormFile File, string? Description);
