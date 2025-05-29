using System;
using ImageAnnotationAPI.Dtos;
using ImageAnnotationAPI.Responses;

namespace ImageAnnotationAPI.Services;

public interface IAnnotationsService
{
    public Task<PagedResponse<AnnotationDto>> GetAnnotationsAsync(HttpRequest request, int pageNumber, int pageSize);
}
