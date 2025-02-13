using ClenaArchitecture.Domain.Abstractions;
using ClenaArchitecture.Domain.Employees;
using ClenaArchitecture.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Application.Employees;

public sealed record EmployeeGetAllQuery() : IRequest<IQueryable<EmployeeGetAllQueryResponse>>;

public sealed class EmployeeGetAllQueryResponse : EntityDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly BirthOfDate { get; set; }
    public decimal Salary { get; set; }
    public string TcNo { get; set; } = default!;
}

internal sealed class EmployeeGetAllQueryHandler(
    IEmployeeRepository employeeRepository,
    UserManager<AppUser> userManager) : IRequestHandler<EmployeeGetAllQuery, IQueryable<EmployeeGetAllQueryResponse>>
{
    public Task<IQueryable<EmployeeGetAllQueryResponse>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = (from employee in employeeRepository.GetAll()
                        join create_user in userManager.Users.AsQueryable() on employee.CreateUserId equals create_user.Id
                        join update_user in userManager.Users.AsQueryable() on employee.CreateUserId equals update_user.Id into update_user
                        from update_users in update_user.DefaultIfEmpty()
                        select new EmployeeGetAllQueryResponse
                        {
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Salary = employee.Salary,
                            BirthOfDate = employee.BirthOfDate,
                            CreatedAt = employee.CreatedAt,
                            DeleteAt = employee.DeleteAt,
                            Id = employee.Id,
                            IsDeleted = employee.IsDeleted,
                            TcNo = employee.PersonalInformation.TcNo,
                            UpdateAt = employee.UpdateAt,
                            CreateUserId = employee.CreateUserId,
                            CreateUserName = create_user.FirstName + " " + create_user.LastName + " (" + create_user.Email + ")",
                            UpdateUserId = employee.UpdateUserId,
                            UpdateUserName = employee.UpdateUserId == null ? null : update_users.FirstName + " " + update_users.LastName + " (" + update_users.Email + ")",
                        });

        return Task.FromResult(response);
    }
}
