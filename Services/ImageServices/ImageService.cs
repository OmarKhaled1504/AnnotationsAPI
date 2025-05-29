using System;
using ImageAnnotationAPI.Dtos.ImageDtos;
using ImageAnnotationAPI.Entities;
using ImageAnnotationAPI.Mapping;
using ImageAnnotationAPI.Repositories;

namespace ImageAnnotationAPI.Services.ImageServices;

public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;
    public ImageService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ImageDto> AddImageAsync(ImageCreateDto dto)
    {
        var uploadsFolder = Path.Combine("wwwroot", "uploads");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = Guid.NewGuid() + Path.GetExtension(dto.File.FileName);
        var filePath = Path.Combine(uploadsFolder, fileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await dto.File.CopyToAsync(stream);
        }

        var created = new Image
        {
            FileName = fileName,
            FilePath = filePath,
            Description = dto.Description
        };
        await _unitOfWork.Images.AddImageAsync(created);
        await _unitOfWork.SaveChangesAsync();
        return created.ToDto();
    }
}
