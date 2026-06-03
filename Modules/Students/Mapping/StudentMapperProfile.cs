using AutoMapper;
using DatabaseTutorials.Modules.Authentication.DTOs;
using DatabaseTutorials.Modules.Students.DTOs;
using DatabaseTutorials.Modules.Students.Entity;
namespace DatabaseTutorials.Modules.Students.Mapping
{
    public class StudentMapperProfile : Profile
    {
        public StudentMapperProfile()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentResponseDTO>().ForMember(
                dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null)
            );
            CreateMap<RegisterDTO, Student>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore());
        }
    }
}