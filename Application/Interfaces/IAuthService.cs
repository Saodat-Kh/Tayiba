using Application.Dtos.Auth;
using Application.Responses;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<Response<string>> Login(LoginDto login);
}