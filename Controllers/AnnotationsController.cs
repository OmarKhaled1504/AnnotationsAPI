using ImageAnnotationAPI.Dtos;
using ImageAnnotationAPI.Entities;
using ImageAnnotationAPI.Responses;
using ImageAnnotationAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageAnnotationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnotationsController : ControllerBase
    {
        private readonly IAnnotationsService _annotationsService;
        public AnnotationsController(IAnnotationsService annotationsService)
        {
            _annotationsService = annotationsService;
        }

        //GET /api/annotations
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<AnnotationDto>), 200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<PagedResponse<AnnotationDto>>> GetAnnotations(int pageNumber = 1, int pageSize = 10)
        {
            var response = await _annotationsService.GetAnnotationsAsync(Request, pageNumber, pageSize);
            return Ok(response);
        }
    }
}
