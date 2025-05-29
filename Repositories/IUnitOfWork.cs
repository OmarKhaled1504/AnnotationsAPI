using System;
using ImageAnnotationAPI.Repositories.UserRepositories;

namespace ImageAnnotationAPI.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IAnnotationsRepository Annotations { get; }
    IImageRepository Images { get; }
    Task<int> SaveChangesAsync();
}
