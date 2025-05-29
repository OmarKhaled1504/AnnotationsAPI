using ImageAnnotationAPI.Dtos;
using ImageAnnotationAPI.Entities;

namespace ImageAnnotationAPI.Mapping;

public static class AnnotationsMappingExtenstions
{
    public static AnnotationDto ToDto(this Annotation annotation, HttpRequest request)
    {
        var url = $"{request.Scheme}://{request.Host}/images/{annotation.Image.FileName}";
        return new AnnotationDto(
            annotation.Image.Id,
            annotation.Image.FileName,
            url,
            annotation.Image.Description,
            annotation.Annotated,
            annotation.AnnotationType
        );
    }
}
