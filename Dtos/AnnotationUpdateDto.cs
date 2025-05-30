using System.ComponentModel.DataAnnotations;

namespace ImageAnnotationAPI.Dtos;

public record class AnnotationUpdateDto([Required][StringLength(40)]string AnnotationType);
