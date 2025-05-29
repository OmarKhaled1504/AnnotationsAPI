using System.ComponentModel.DataAnnotations;

namespace ImageAnnotationAPI.Dtos.UserDtos;

public record class LoginDto(
    [Required]string Username,
    [Required]string Password
);
