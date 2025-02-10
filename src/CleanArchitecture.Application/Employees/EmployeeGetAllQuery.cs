using ClenaArchitecture.Domain.Abstractions;
using ClenaArchitecture.Domain.Employees;
using MediatR;

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

internal sealed class EmployeeGetAllQueryHandler(IEmployeeRepository employeeRepository ) : IRequestHandler<EmployeeGetAllQuery, IQueryable<EmployeeGetAllQueryResponse>>
{
    public Task<IQueryable<EmployeeGetAllQueryResponse>> Handle(EmployeeGetAllQuery request, CancellationToken cancellationToken)
    {
        var response = employeeRepository.GetAll()
            .Select(s => new EmployeeGetAllQueryResponse
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                BirthOfDate = s.BirthOfDate,
                Salary = s.Salary,
                Id = s.Id,
                CreatedAt = s.CreatedAt,
                UpdateAt = s.UpdateAt,
                DeleteAt = s.DeleteAt,
                IsDeleted = s.IsDeleted,
                TcNo = s.PersonalInformation.TcNo

            }).AsQueryable();

        return Task.FromResult(response);
 
    }
}
