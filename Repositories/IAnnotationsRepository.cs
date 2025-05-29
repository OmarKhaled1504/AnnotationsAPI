using System;
using ImageAnnotationAPI.Entities;

namespace ImageAnnotationAPI.Repositories;

public interface IAnnotationsRepository
{
    public Task<Annotation?> GetAnnotationAsync(int id);
    public Task<List<Annotation>> GetAnnotationsAsync(string id, int pageNumber, int pageSize);


    public Task<int> GetCountAnnotationsById(string userId);
}
