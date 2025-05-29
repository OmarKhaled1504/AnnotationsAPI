using System;
using ImageAnnotationAPI.Data;

namespace ImageAnnotationAPI.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AnnotationContext _context;
    public UnitOfWork(AnnotationContext context)
    {
        _context = context;
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
