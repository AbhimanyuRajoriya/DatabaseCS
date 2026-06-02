using AutoMapper;
using DatabaseTutorials.DTO;
using DatabaseTutorials.Entities;
namespace DatabaseTutorials.Mapper
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