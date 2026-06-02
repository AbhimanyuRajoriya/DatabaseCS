using DatabaseTutorials.DTO;
namespace DatabaseTutorials.Service
{
    public interface IAuthService
    {
        bool Register(RegisterDTO dto);
        LoginResponseDTO? Login (LoginDTO dto);
    }
}
