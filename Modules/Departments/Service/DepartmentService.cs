using AutoMapper;
using DatabaseTutorials.Modules.Departments.DTOs;
using DatabaseTutorials.Modules.Departments.Entity;
using DatabaseTutorials.Modules.Departments.Repository;
namespace DatabaseTutorials.Modules.Departments.Service
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<DepartmentResponseDTO> GetDepartments()
        {
            return _repository.GetDepartments();
        }
        public void AddDepartment(DepartmentDTO dto)
        {
            var department = _mapper.Map<Department>(dto);
            if (_repository.DepartmentExistsByName(department.Name))
            {
                throw new ArgumentException("Department Aready Exists");
            }
            _repository.AddDepartment(department);
        }
    }
}
