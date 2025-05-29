using System;
using ImageAnnotationAPI.Entities;

namespace ImageAnnotationAPI.Services.UserServices;

public interface ITokenService
{
    string GenerateToken(User user);
}
