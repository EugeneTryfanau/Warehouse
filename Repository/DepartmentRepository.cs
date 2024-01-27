using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateDepartment(Department department)
        {
            Create(department);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await GetAll(includeProperties: "Products").OrderBy(d => d.Name).ToListAsync();
        }

        public async Task<Department?> GetDepartmentAsync(Guid departmentId)
        {
            return await GetByCondition(d => d.Id.Equals(departmentId), includeProperties: "Products").SingleOrDefaultAsync();
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
