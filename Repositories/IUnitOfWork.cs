using System;
using ImageAnnotationAPI.Repositories.UserRepositories;

namespace ImageAnnotationAPI.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IAnnotationsRepository Annotations { get; }
    Task<int> SaveChangesAsync();
}
