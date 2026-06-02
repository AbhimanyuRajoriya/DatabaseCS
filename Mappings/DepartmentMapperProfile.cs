using AutoMapper;
using DatabaseTutorials.DTO;
using DatabaseTutorials.Entities;
namespace DatabaseTutorials.Mapper
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {
            CreateMap<Department, DepartmentResponseDTO>();
            CreateMap<DepartmentDTO, Department>();
        }
    }
}
