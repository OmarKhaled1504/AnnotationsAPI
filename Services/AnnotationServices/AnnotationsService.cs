using System;
using ImageAnnotationAPI.Dtos;
using ImageAnnotationAPI.Entities;
using ImageAnnotationAPI.Mapping;
using ImageAnnotationAPI.Repositories;
using ImageAnnotationAPI.Responses;

namespace ImageAnnotationAPI.Services.UserServices;

public class AnnotationsService : IAnnotationsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AnnotationsService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }
    private string GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;
    }
    public async Task<PagedResponse<AnnotationDto>> GetAnnotationsAsync(HttpRequest request, int pageNumber, int pageSize)
    {
        var annotations = await _unitOfWork.Annotations.GetAnnotationsAsync(GetUserId(), pageNumber, pageSize);
        var dtos = annotations.Select(ann => ann.ToDto(request)).ToList();
        return new PagedResponse<AnnotationDto>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = await _unitOfWork.Annotations.GetCountAnnotationsById(GetUserId()),
            Data = dtos
        };

    }

    public async Task<AnnotationDto?> GetAnnotationAsync(HttpRequest request, int id)
    {
        var annotation = await _unitOfWork.Annotations.GetAnnotationAsync(id, GetUserId());
        if (annotation is null)
            return null;
        return annotation.ToDto(request);

    }

    public async Task<AnnotationDto?> UpdateAnnotation(HttpRequest request, int id, AnnotationUpdateDto dto)
    {
        var annotation = await _unitOfWork.Annotations.GetAnnotationAsync(id,GetUserId());
        if (annotation is null)
            return null;
        annotation.AnnotationType = dto.AnnotationType;
        annotation.Annotated = true;
        await _unitOfWork.SaveChangesAsync();
        return annotation.ToDto(request);
    }
}
