using AutoMapper;
using DatabaseTutorials.DTO;
using DatabaseTutorials.Entities;
using DatabaseTutorials.Repository;
namespace DatabaseTutorials.Service
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
