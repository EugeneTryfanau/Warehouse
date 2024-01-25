using Contracts;
using Entities.Models;

namespace Repository
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return GetAll().OrderBy(d => d.Name).ToList();
        }

        public Department GetDepartment(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
