using System;
using ImageAnnotationAPI.Dtos.UserDtos;

namespace ImageAnnotationAPI.Services.UserServices;

public interface IAuthService
{
    public Task<(TokenDto? Token, IEnumerable<string>? Errors)> RegisterAsync(RegisterDto dto);
    public Task<(TokenDto? Token, IEnumerable<string>? Errors)> LoginAsync(LoginDto dto);
}
