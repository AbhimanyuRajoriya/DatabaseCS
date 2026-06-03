using DatabaseTutorials.Modules.Authentication.DTOs;

namespace DatabaseTutorials.Modules.Authentication.Service
{
    public interface IAuthService
    {
        bool Register(RegisterDTO dto);
        LoginResponseDTO? Login (LoginDTO dto);
    }
}
