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
}
