using System;
using ImageAnnotationAPI.Dtos.ImageDtos;

namespace ImageAnnotationAPI.Services.ImageServices;

public interface IImageService
{
    public Task<ImageDto> AddImageAsync(ImageCreateDto dto);
}
