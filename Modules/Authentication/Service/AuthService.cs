using AutoMapper;
using DatabaseTutorials.Modules.Authentication.DTOs;
using DatabaseTutorials.Modules.Authentication.Secrurity;
using DatabaseTutorials.Modules.Departments.Repository;
using DatabaseTutorials.Modules.Students.Entity;
using DatabaseTutorials.Modules.Students.Services.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatabaseTutorials.Modules.Authentication.Service
{
    public class AuthService : IAuthService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IPasswordHasherService _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public AuthService(IStudentRepository studentRepository, IPasswordHasherService passwordHasher, IConfiguration configuration, IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public bool Register(RegisterDTO dto)
        {
            
            if (_studentRepository.GetStudentByUsername(dto.UserName) != null)
            {
                return false;
            }
            if (!_departmentRepository.DepartmentExists(dto.DepartmentId))
            {
                throw new ArgumentException("Department Does Not Exist");
            }

            var student = _mapper.Map<Student>(dto);

            student.PasswordHash = _passwordHasher.HashPassword(dto.Password);
            student.Role = "User";

            _studentRepository.AddStudent(student);

            return true;
        }

        public LoginResponseDTO? Login(LoginDTO dto)
        {
            var student = _studentRepository.GetStudentByUsername(dto.UserName);

            if (student == null)
            {
                return null;
            }

            if (!_passwordHasher.VerifyPassword(student.PasswordHash, dto.Password))
            {
                return null;
            }

            var token = GenerateJwtToken(student);

            return new LoginResponseDTO
            {
                Token = token,
                UserName = student.Username,
                Role = student.Role
            };
        }

        private string GenerateJwtToken(Student student)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];
            var expiryMinutes = _configuration.GetValue<int>("Jwt:ExpiryMinutes");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey!)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    student.Id.ToString()
                ),
                new Claim(
                    ClaimTypes.Name,
                    student.Username
                ),
                new Claim(
                    ClaimTypes.Role,
                    student.Role
                )
            };

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}