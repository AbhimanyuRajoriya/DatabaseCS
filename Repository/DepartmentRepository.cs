using DatabaseTutorials.Data;
using DatabaseTutorials.DTO;
using AutoMapper;
using DatabaseTutorials.Entities;
using DatabaseTutorials.Repository;

namespace DatabaseTutorials.Repositories
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
    }
}