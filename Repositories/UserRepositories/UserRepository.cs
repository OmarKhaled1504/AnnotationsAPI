using System;
using ImageAnnotationAPI.Entities;
using Microsoft.AspNetCore.Identity;

namespace ImageAnnotationAPI.Repositories.UserRepositories;
public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<(User? User, IEnumerable<string>? Errors)> CreateAsync(User user, string password)
    {
        if (string.IsNullOrWhiteSpace(user.UserName))
        {
            throw new ArgumentException("Username must not be null or empty");
        }
        var existingUser = await _userManager.FindByNameAsync(user.UserName);
        if (existingUser != null)
        {
            return (null, new[] { "Username already exists." });
        }
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return (null, result.Errors.Select(e => e.Description));
        }
        await _userManager.AddToRoleAsync(user, "Annotator");
        return (user, null);
    }
    public async Task<User?> GetUserByUserNameAsync(string username)
{
    return await _userManager.FindByNameAsync(username);
}

    public async Task<bool> CheckPasswordAsync(User user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
}
