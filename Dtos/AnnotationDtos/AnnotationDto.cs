namespace ImageAnnotationAPI.Dtos;

public record class AnnotationDto(int Id, string FileName, string Url, string? Description, bool Annotated, string? AnnotationType);
