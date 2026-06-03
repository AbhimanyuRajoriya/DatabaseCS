using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using DatabaseTutorials.Modules.Departments.DTOs;
using DatabaseTutorials.Modules.Departments.Entity;
using DatabaseTutorials.Modules.Shared.Data;

namespace DatabaseTutorials.Modules.Departments.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DepartmentResponseDTO> GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return _mapper.Map<List<DepartmentResponseDTO>>(departments);
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);

            _context.SaveChanges();
        }

        public bool DepartmentExists(int departmentId)
        {
            return _context.Departments.Any(d => d.DepartmentId == departmentId);
        }
        public bool DepartmentExistsByName(string name)
        {
            name = name.Trim().ToLower();
            return _context.Departments
                .Any(d => d.Name.Trim().ToLower() == name);
        }
    }
}