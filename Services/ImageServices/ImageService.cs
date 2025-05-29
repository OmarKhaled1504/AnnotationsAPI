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

        var users = await _unitOfWork.Users.GetAllUsersAsync();
        foreach (var user in users)
        {
            var annotation = new Annotation
            {
                UserId = user.Id,
                Image = created,
                Annotated = false,
                AnnotationType = string.Empty
            };
            await _unitOfWork.Annotations.AddAnnotationAsync(annotation);
        }


        await _unitOfWork.SaveChangesAsync();

        return created.ToDto();
    }

    public async Task<bool> DeleteImageAsync(int id)
    {
        var image = await _unitOfWork.Images.GetImageAsync(id);
        if (image is null)
        {
            return false;
        }
        var annotations = await _unitOfWork.Annotations.GetAllAnnotationsByImageIdAsync(image.Id);
        foreach (var ann in annotations)
        {
            _unitOfWork.Annotations.DeleteAnnotation(ann);
        }
        _unitOfWork.Images.DeleteImage(image);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
