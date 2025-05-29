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

        //GET /api/annotations/id
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AnnotationDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]


        public async Task<ActionResult<AnnotationDto>> GetAnnotation(int id)
        {

            var dto = await _annotationsService.GetAnnotationAsync(Request, id);
            return dto is null ? NotFound("Image not found.") : Ok(dto);
        }

        //PUT /api/annotations/1
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AnnotationDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]

        public async Task<ActionResult<AnnotationDto>> UpdateAnnotation(int id, AnnotationUpdateDto dto)
        {
            try
            {
                var updatedDto = await _annotationsService.UpdateAnnotation(Request, id, dto);
                return updatedDto is null ? NotFound("Image not found.") : Ok(updatedDto);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
        }


    }
}
