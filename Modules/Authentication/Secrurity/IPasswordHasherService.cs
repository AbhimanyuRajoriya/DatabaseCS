namespace DatabaseTutorials.Modules.Authentication.Secrurity
{
    public interface IPasswordHasherService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
