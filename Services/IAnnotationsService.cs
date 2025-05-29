using System;
using ImageAnnotationAPI.Dtos;
using ImageAnnotationAPI.Responses;

namespace ImageAnnotationAPI.Services;

public interface IAnnotationsService
{
    public Task<AnnotationDto?> GetAnnotationAsync(HttpRequest request, int id);
    public Task<PagedResponse<AnnotationDto>> GetAnnotationsAsync(HttpRequest request, int pageNumber, int pageSize);
}
