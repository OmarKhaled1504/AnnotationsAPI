using System;
using ImageAnnotationAPI.Entities;

namespace ImageAnnotationAPI.Repositories;

public interface IImageRepository
{
    public Task AddImageAsync(Image image);

}
