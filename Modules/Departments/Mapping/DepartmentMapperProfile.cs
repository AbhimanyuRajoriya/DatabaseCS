using AutoMapper;
using DatabaseTutorials.Modules.Departments.DTOs;
using DatabaseTutorials.Modules.Departments.Entity;
namespace DatabaseTutorials.Modules.Departments.Repository.Mapping
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
