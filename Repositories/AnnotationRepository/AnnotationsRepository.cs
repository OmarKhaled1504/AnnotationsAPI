using System;
using ImageAnnotationAPI.Data;
using ImageAnnotationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImageAnnotationAPI.Repositories;

public class AnnotationsRepository : IAnnotationsRepository
{
    private readonly AnnotationContext _context;
    public AnnotationsRepository(AnnotationContext context)
    {
        _context = context;
    }
    public async Task<int> GetCountAnnotationsById(string userId)
    {
        return await _context.Annotations.CountAsync(ann => ann.UserId == userId);
    }
    public async Task<List<Annotation>> GetAnnotationsAsync(string id, int pageNumber, int pageSize)
    {
        return await _context.Annotations.Include(ann =>ann.Image).Where(ann => ann.UserId == id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<Annotation?> GetAnnotationAsync(int id, string userId)
    {
        return await _context.Annotations.Include(ann => ann.Image).FirstOrDefaultAsync(ann => ann.ImageId == id && ann.UserId == userId);
    }

    public async Task AddAnnotationAsync(Annotation annotation)
    {
        await _context.Annotations.AddAsync(annotation);
    }

    public async Task<List<Annotation>> GetAllAnnotationsByImageIdAsync(int imageId)
    {
        return await _context.Annotations.Where(ann => ann.ImageId == imageId).ToListAsync();
    }

    public void DeleteAnnotation(Annotation annotation)
    {
        _context.Annotations.Remove(annotation);
    }

}
