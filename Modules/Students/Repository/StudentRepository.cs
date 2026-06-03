using AutoMapper;
using DatabaseTutorials.Modules.Shared.Data;
using DatabaseTutorials.Modules.Students.DTOs;
using DatabaseTutorials.Modules.Students.Entity;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTutorials.Modules.Students.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<StudentResponseDTO> GetStudents()
        {
            var student = _context.Students
                .Include(s => s.Department).ToList();

            return _mapper.Map<List<StudentResponseDTO>>(student);
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public Student? GetStudentByUsername(string username)
        {
            return _context.Students.FirstOrDefault(s => s.Username == username);
        }
    }

}