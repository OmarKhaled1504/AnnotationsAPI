using System;
using ImageAnnotationAPI.Dtos.ImageDtos;

namespace ImageAnnotationAPI.Services.ImageServices;

public interface IImageService
{
    public Task<ImageDto> AddImageAsync(ImageCreateDto dto, HttpRequest request);
    public Task<bool> DeleteImageAsync(int id);
}
