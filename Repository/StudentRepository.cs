using DatabaseTutorials.Data;
using DatabaseTutorials.DTO;
using DatabaseTutorials.Entities;
using DatabaseTutorials.Repository;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTutorials.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<StudentResponseDTO> GetStudents()
        {
            return _context.Students
                .Include(s => s.Department)
                .Select(s => new StudentResponseDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    DepartmentName = s.Department != null
                                     ? s.Department.Name
                                     : null
                })
                .ToList();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);

            _context.SaveChanges();
        }
    }
}