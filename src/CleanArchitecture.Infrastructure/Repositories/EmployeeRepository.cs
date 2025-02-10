using CleanArchitecture.Infrastructure.Context;
using ClenaArchitecture.Domain.Employees;
using GenericRepository;

namespace CleanArchitecture.Infrastructure.Repositories;

internal sealed class EmployeeRepository : Repository<Employee, ApplicationDbContext>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
