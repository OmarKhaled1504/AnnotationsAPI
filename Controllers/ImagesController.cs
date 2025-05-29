using ImageAnnotationAPI.Dtos.ImageDtos;
using ImageAnnotationAPI.Services.ImageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageAnnotationAPI.Controllers
{   [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        //POST /api/images
        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(ImageDto), 201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ImageDto>> AddImage(ImageCreateDto dto)
        {
            if (dto.File.Length == 0)
                return BadRequest("Empty File.");

            var createdImage = await _imageService.AddImageAsync(dto);
            return CreatedAtAction(nameof(AddImage), new { id = createdImage.Id }, createdImage);
        }

    }
}
