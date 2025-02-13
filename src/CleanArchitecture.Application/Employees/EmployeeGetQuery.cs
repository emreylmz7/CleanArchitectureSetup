using ClenaArchitecture.Domain.Abstractions;
using ClenaArchitecture.Domain.Employees;
using MediatR;
using TS.Result;

namespace CleanArchitecture.Application.Employees;

public sealed record EmployeeGetQuery(Guid Id) : IRequest<Result<Employee>>;

public sealed class EmployeeGetQueryResponse : EntityDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly BirthOfDate { get; set; }
    public decimal Salary { get; set; }
    public string TcNo { get; set; } = default!;
}

internal sealed class EmployeeGetQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<EmployeeGetQuery, Result<Employee>>
{
    public async Task<Result<Employee>> Handle(EmployeeGetQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (employee is null)
            return Result<Employee>.Failure("Personel bulunamadı");

        return employee;
    }
}
