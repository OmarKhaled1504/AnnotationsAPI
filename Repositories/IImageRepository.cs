using System;
using ImageAnnotationAPI.Entities;

namespace ImageAnnotationAPI.Repositories;

public interface IImageRepository
{
    public Task AddImageAsync(Image image);
    public Task<Image?> GetImageAsync(int id);
    public void DeleteImage(Image image);

}
