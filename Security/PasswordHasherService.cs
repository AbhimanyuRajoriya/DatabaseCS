using DatabaseTutorials.Entities;
using Microsoft.AspNetCore.Identity;
namespace DatabaseTutorials.Security
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly IPasswordHasher<Student> _passwordHasher;
        public PasswordHasherService(IPasswordHasher<Student> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null!, password);
        }
        public bool VerifyPassword(string hash, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(
                null!,
                hash,
                password);

            return result == PasswordVerificationResult.Success ||
                   result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
