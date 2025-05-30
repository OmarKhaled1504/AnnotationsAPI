using System;
using ImageAnnotationAPI.Data;
using ImageAnnotationAPI.Entities;

namespace ImageAnnotationAPI.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly AnnotationContext _context;
    public ImageRepository(AnnotationContext context)
    {
        _context = context;
    }

    public async Task AddImageAsync(Image image)
    {
        await _context.Images.AddAsync(image);
    }

    public async Task<Image?> GetImageAsync(int id)
    {
        return await _context.Images.FindAsync(id);
    }
    public void DeleteImage(Image image)
    {
        _context.Images.Remove(image);
    }
}
