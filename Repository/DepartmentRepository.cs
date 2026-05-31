using DatabaseTutorials.Data;
using DatabaseTutorials.DTO;
using DatabaseTutorials.Entities;
using DatabaseTutorials.Repository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTutorials.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<DepartmentResponseDTO> GetDepartments()
        {
            return _context.Departments
                .Select(d => new DepartmentResponseDTO
                {
                    DepartmentId = d.DepartmentId,
                    Name = d.Name
                })
                .ToList();
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);

            _context.SaveChanges();
        }
    }
}