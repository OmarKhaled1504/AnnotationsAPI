using System;
using ImageAnnotationAPI.Dtos.ImageDtos;
using ImageAnnotationAPI.Entities;

namespace ImageAnnotationAPI.Mapping;

public static class ImagesMappingExtenstions
{
    public static Image ToEntity(this ImageCreateDto dto, string fileName, string filePath)
    {
        return new Image
        {
            FileName = fileName,
            FilePath = filePath,
            Description = dto.Description
        };
    }
    public static ImageDto ToDto(this Image image, HttpRequest request)
    {
        var url = $"{request.Scheme}://{request.Host}/uploads/{image.FileName}";
        return new ImageDto(image.Id,
        image.FileName,
        url,
        image.Description);
    }
}
