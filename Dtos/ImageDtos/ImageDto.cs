namespace ImageAnnotationAPI.Dtos.ImageDtos;

public record class ImageDto(
    int Id,
    string FileName,
    string FilePath,
    string? Description
);
