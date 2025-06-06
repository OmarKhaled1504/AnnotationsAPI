using System;
using ImageAnnotationAPI.Data;
using ImageAnnotationAPI.Repositories.UserRepositories;

namespace ImageAnnotationAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AnnotationContext _context;
    public IUserRepository Users { get; }
    public IImageRepository Images { get; }
    public IAnnotationsRepository Annotations { get; }

    public UnitOfWork(AnnotationContext context, IUserRepository users, IAnnotationsRepository annotations, IImageRepository images)
    {
        _context = context;
        Users = users;
        Annotations = annotations;
        Images = images;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
