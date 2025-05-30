using System;
using ImageAnnotationAPI.Entities;

namespace ImageAnnotationAPI.Repositories;

public interface IAnnotationsRepository
{
    public Task AddAnnotationAsync(Annotation annotation);
    public void DeleteAnnotation(Annotation annotation);
    public Task<List<Annotation>> GetAllAnnotationsByImageIdAsync(int imageId);
    public Task<Annotation?> GetAnnotationAsync(int id, string userId);
    public Task<List<Annotation>> GetAnnotationsAsync(string id, int pageNumber, int pageSize);


    public Task<int> GetCountAnnotationsById(string userId);
}
