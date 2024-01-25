using Contracts;
using Entities.Models;

namespace Repository
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateDepartment(Department department)
        {
            Create(department);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return GetAll().OrderBy(d => d.Name).ToList();
        }

        public Department? GetDepartment(Guid departmentId)
        {
            return GetByCondition(d => d.Id.Equals(departmentId)).SingleOrDefault();
        }

        public void UpdateDepartment(Department department)
        {
            Update(department);
        }

        public void DeleteDepartment(Department department)
        {
            Delete(department);
        }
    }
}
